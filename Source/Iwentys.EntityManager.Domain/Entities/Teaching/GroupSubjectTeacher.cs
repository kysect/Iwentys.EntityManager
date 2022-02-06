using Iwentys.EntityManager.Domain.Entities.Users;
using Iwentys.EntityManager.Domain.ValueObjects.Study;

namespace Iwentys.EntityManager.Domain.Entities.Teaching;

public class GroupSubjectTeacher : IEquatable<GroupSubjectTeacher>
{
    public GroupSubjectTeacher(Teacher teacher, TeacherType teacherType, GroupSubject groupSubject)
    {
        Teacher = teacher;
        TeacherType = teacherType;
        GroupSubject = groupSubject;
    }

    protected GroupSubjectTeacher() { }

    public Guid Id { get; protected init; }
    public virtual Teacher Teacher { get; protected init; }
    public virtual TeacherType TeacherType { get; protected init; }
    public virtual GroupSubject GroupSubject { get; protected init; }

    public bool Equals(GroupSubjectTeacher? other)
        => other is not null && other.Id.Equals(Id);

    public sealed override bool Equals(object? obj)
        => Equals(obj as GroupSubjectTeacher);

    public sealed override int GetHashCode()
        => Id.GetHashCode();
}