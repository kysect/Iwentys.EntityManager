using Iwentys.EntityManager.Common;

namespace Iwentys.EntityManager.Domain;

public class GroupSubject
{
    private List<GroupSubjectTeacher> _teachers;

    public int Id { get; init; }

    public int SubjectId { get; init; }
    public virtual Subject Subject { get; init; }
    public StudySemester StudySemester { get; init; }

    public int StudyGroupId { get; init; }
    public virtual StudyGroup StudyGroup { get; init; }
    public virtual IReadOnlyList<GroupSubjectTeacher> Teachers => _teachers.AsReadOnly();

    public GroupSubject(Subject subject, StudyGroup studyGroup, StudySemester studySemester, IwentysUser lecturer)
    {
        ArgumentNullException.ThrowIfNull(subject);
        ArgumentNullException.ThrowIfNull(studyGroup);
        ArgumentNullException.ThrowIfNull(lecturer);
        
        Subject = subject;
        SubjectId = subject.Id;
        StudyGroup = studyGroup;
        StudyGroupId = studyGroup.Id;
        StudySemester = studySemester;
        _teachers = new List<GroupSubjectTeacher>
        {
            new GroupSubjectTeacher(lecturer, this, TeacherType.Lecturer),
        };
    }

    protected GroupSubject() { }

    public void AddPracticeTeacher(IwentysUser practiceTeacher)
    {
        AddTeacher(practiceTeacher, TeacherType.Practice);
    }

    public void AddTeacher(IwentysUser teacher, TeacherType teacherType)
    {
        ArgumentNullException.ThrowIfNull(teacher);
        
        if (!IsUserAlreadyAdded(teacher, teacherType))
        {
            throw new IwentysException("User is already practice teacher");
        }

        _teachers.Add(new GroupSubjectTeacher(teacher, this, teacherType));
    }

    private bool IsUserAlreadyAdded(IwentysUser teacher, TeacherType teacherType)
    {
        ArgumentNullException.ThrowIfNull(teacher);
        return !_teachers.Any(t => t.TeacherId == teacher.Id && t.TeacherType.HasFlag(teacherType));
    }

    public bool HasTeacherPermission(IwentysUser user)
    {
        ArgumentNullException.ThrowIfNull(user);
        return _teachers.Any(t => t.TeacherId == user.Id);
    }
}