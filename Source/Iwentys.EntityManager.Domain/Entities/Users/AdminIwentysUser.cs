namespace Iwentys.EntityManager.Domain.Entities.Users;

public class AdminIwentysUser : IEquatable<AdminIwentysUser>
{
    public AdminIwentysUser(IwentysUser user)
    {
        Id = Guid.NewGuid();
        User = user;
    }

    protected AdminIwentysUser() { }

    public Guid Id { get; protected init; }

    public IwentysUser User { get; protected init; }

    public bool Equals(AdminIwentysUser? other)
        => other is not null && other.Id.Equals(Id);

    public sealed override bool Equals(object? obj)
        => Equals(obj as AdminIwentysUser);

    public sealed override int GetHashCode()
        => Id.GetHashCode();
}