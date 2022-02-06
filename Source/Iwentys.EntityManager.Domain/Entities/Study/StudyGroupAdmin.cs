using Iwentys.EntityManager.Domain.Entities.Users;

namespace Iwentys.EntityManager.Domain.Entities.Study;

public class StudyGroupAdmin : IEquatable<StudyGroupAdmin>
{
    public StudyGroupAdmin(StudyGroup group, Student? admin = null)
    {
        Id = Guid.NewGuid();
        Group = group;
        Admin = admin;
    }

    protected StudyGroupAdmin() { }

    public Guid Id { get; protected init; }

    public virtual StudyGroup Group { get; protected init; }
    public virtual Student? Admin { get; set; }

    public bool Equals(StudyGroupAdmin? other)
        => other is not null && other.Id.Equals(Id);

    public sealed override bool Equals(object? obj)
        => Equals(obj as StudyGroupAdmin);

    public sealed override int GetHashCode()
        => Id.GetHashCode();
}