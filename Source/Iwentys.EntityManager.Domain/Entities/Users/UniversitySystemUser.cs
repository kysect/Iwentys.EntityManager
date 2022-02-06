namespace Iwentys.EntityManager.Domain.Entities.Users;

public class UniversitySystemUser : IEquatable<UniversitySystemUser>
{
    public UniversitySystemUser(int id, string firstName, string middleName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
    }

    protected UniversitySystemUser() { }

    public int Id { get; protected init; }

    public string FirstName { get; protected init; }
    public string MiddleName { get; protected init; }
    public string LastName { get; protected init; }

    public bool Equals(UniversitySystemUser? other)
        => other is not null && other.Id.Equals(Id);

    public sealed override bool Equals(object? obj)
        => Equals(obj as UniversitySystemUser);

    public sealed override int GetHashCode()
        => Id;
}