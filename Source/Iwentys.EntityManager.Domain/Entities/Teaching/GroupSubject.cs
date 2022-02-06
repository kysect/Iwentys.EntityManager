using Iwentys.EntityManager.Domain.Entities.Exception;
using Iwentys.EntityManager.Domain.Entities.Study;
using Iwentys.EntityManager.Domain.Entities.Users;
using Iwentys.EntityManager.Domain.ValueObjects.Study;

namespace Iwentys.EntityManager.Domain.Entities.Teaching;

public class GroupSubject : IEquatable<GroupSubject>
{
    private readonly List<GroupSubjectTeacher> _groupSubjectTeachers;

    public GroupSubject(Subject subject, StudySemester studySemester, StudyGroup studyGroup, Teacher lecturer)
    {
        Id = Guid.NewGuid();
        _groupSubjectTeachers = new List<GroupSubjectTeacher>();
        Subject = subject;
        StudySemester = studySemester;
        StudyGroup = studyGroup;

        AddTeacher(lecturer, TeacherType.Lecturer);
    }

    protected GroupSubject() { }

    public Guid Id { get; init; }

    public virtual Subject Subject { get; protected init; }
    public virtual StudySemester StudySemester { get; protected init; }
    public virtual StudyGroup StudyGroup { get; protected init; }
    public virtual IReadOnlyCollection<GroupSubjectTeacher> Teachers => _groupSubjectTeachers;

    public void AddPracticeTeacher(Teacher practiceTeacher)
        => AddTeacher(practiceTeacher, TeacherType.Practice);

    public void AddMentorTeacher(Teacher mentorTeacher)
        => AddTeacher(mentorTeacher, TeacherType.Mentor);

    public void ChangeLecturer(Teacher lecturer)
    {
        var currentLecturer = _groupSubjectTeachers
            .Single(g => g.TeacherType.Equals(TeacherType.Lecturer));

        _groupSubjectTeachers.Remove(currentLecturer);
        AddTeacher(lecturer, TeacherType.Lecturer);
    }

    public bool Equals(GroupSubject? other)
        => other is not null && other.Id.Equals(Id);

    public sealed override bool Equals(object? obj)
        => Equals(obj as GroupSubject);

    public sealed override int GetHashCode()
        => Id.GetHashCode();

    // TODO: Fix controller, then make private
    public void AddTeacher(Teacher teacher, TeacherType teacherType)
    {
        if (HasTeacherOfType(teacher, teacherType))
            throw new InvalidGroupSubjectTeacherRelationshipException(
                this, teacher, $"This teacher is already has a {teacherType} position.");

        var gst = new GroupSubjectTeacher(teacher, teacherType, this);
        _groupSubjectTeachers.Add(gst);
    }

    private bool HasTeacherOfType(Teacher teacher, TeacherType type)
        => _groupSubjectTeachers.Any(g => g.Teacher.Equals(teacher) && g.TeacherType.Equals(type));
}