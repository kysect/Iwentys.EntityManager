using Iwentys.EntityManager.Domain.Entities.Exception;
using Iwentys.EntityManager.Domain.Entities.Teaching;
using Iwentys.EntityManager.Domain.Entities.Users;
using Iwentys.EntityManager.Domain.ValueObjects.Study;

namespace Iwentys.EntityManager.Domain.Entities.Study;

public class StudyGroup : IEquatable<StudyGroup>
{
    private readonly List<Student> _students;
    private readonly List<GroupSubject> _groupSubjects;
    private readonly StudyGroupAdmin _studyGroupAdmin;

    public StudyGroup(GroupName groupName, StudyCourse studyCourse)
    {
        Id = Guid.NewGuid();
        _students = new List<Student>();
        _groupSubjects = new List<GroupSubject>();
        _studyGroupAdmin = new StudyGroupAdmin(this);
        Id = Guid.NewGuid();
        GroupName = groupName;
        StudyCourse = studyCourse;
    }

    protected StudyGroup() { }

    public Guid Id { get; protected init; }

    public Student? Admin => _studyGroupAdmin.Admin;
    public virtual GroupName GroupName { get; protected init; }
    public virtual StudyCourse StudyCourse { get; set; }
    public virtual IReadOnlyCollection<Student> Students => _students;
    public virtual IReadOnlyCollection<GroupSubject> GroupSubjects => _groupSubjects;

    public void AddStudent(Student student)
    {
        if (_students.Contains(student))
            throw new InvalidGroupStudentRelationshipException(
                this, student, "Student already being member of the group.");

        _students.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        if (!_students.Remove(student))
            throw new InvalidGroupStudentRelationshipException(
                this, student, "Student is not a member of the group.");
    }

    public void MakeAdmin(Student student)
    {
        if (!_students.Contains(student))
            throw new InvalidGroupStudentRelationshipException(
                this, student, "Student must be a member of the group to be it's admin");

        _studyGroupAdmin.Admin = student;
    }

    public bool Equals(StudyGroup? other)
        => other is not null && other.Id.Equals(Id);

    public sealed override bool Equals(object? obj)
        => Equals(obj as StudyGroup);

    public sealed override int GetHashCode()
        => Id.GetHashCode();
}