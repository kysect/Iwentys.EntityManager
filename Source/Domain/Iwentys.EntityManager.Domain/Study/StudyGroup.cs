using Iwentys.EntityManager.Common;

namespace Iwentys.EntityManager.Domain;

public class StudyGroup
{
    private readonly List<Student> _students;
    private readonly List<GroupSubject> _groupSubjects;

    public int Id { get; set; }
    public virtual GroupName GroupName { get; set; }

    public int StudyCourseId { get; set; }
    public virtual StudyCourse StudyCourse { get; set; }

    public int? GroupAdminId { get; set; }
    //public Student GroupAdmin { get; set; }

    public virtual IReadOnlyList<Student> Students => _students.AsReadOnly();
    public virtual IReadOnlyList<GroupSubject> GroupSubjects => _groupSubjects.AsReadOnly();

    protected StudyGroup()
    {
    }

    public StudyGroup(GroupName groupName, StudyCourse studyCourse)
    {
        ArgumentNullException.ThrowIfNull(groupName);
        ArgumentNullException.ThrowIfNull(studyCourse);

        GroupName = groupName;
        StudyCourse = studyCourse;
        StudyCourseId = studyCourse.Id;
        _students = new List<Student>();
        _groupSubjects = new List<GroupSubject>();
    }

    //TODO: remove this ctor
    public StudyGroup(GroupName groupName, int studyCourseId)
    {
        ArgumentNullException.ThrowIfNull(groupName);

        GroupName = groupName;
        StudyCourseId = studyCourseId;
        _students = new List<Student>();
        _groupSubjects = new List<GroupSubject>();
    }

    public static StudyGroup MakeGroupAdmin(IwentysUser initiatorProfile, Student newGroupAdmin)
    {
        ArgumentNullException.ThrowIfNull(initiatorProfile);
        ArgumentNullException.ThrowIfNull(newGroupAdmin);

        if (newGroupAdmin.Group is null)
        {
            throw new InnerLogicException(
                $"Cannot set user {newGroupAdmin.Id} group admin. User do not have study group.");
        }

        newGroupAdmin.Group.MakeAdmin(initiatorProfile, newGroupAdmin);

        return newGroupAdmin.Group;
    }

    public void AddStudent(Student student)
    {
        ArgumentNullException.ThrowIfNull(student);

        _students.Add(student);
    }

    public void MakeAdmin(IwentysUser initiatorProfile, Student newGroupAdmin)
    {
        ArgumentNullException.ThrowIfNull(initiatorProfile);
        ArgumentNullException.ThrowIfNull(newGroupAdmin);

        initiatorProfile.EnsureIsAdmin();
        GroupAdminId = newGroupAdmin.Id;
    }
}