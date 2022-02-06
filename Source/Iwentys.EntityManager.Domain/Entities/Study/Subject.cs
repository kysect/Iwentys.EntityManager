using Iwentys.EntityManager.Domain.Entities.Teaching;

namespace Iwentys.EntityManager.Domain.Entities.Study;

public class Subject : IEquatable<Subject>
{
    private readonly List<GroupSubject> _groupSubjects;

    public Subject(string title)
    {
        Id = Guid.NewGuid();
        _groupSubjects = new List<GroupSubject>();
        Title = title;
    }

    protected Subject() { }

    public Guid Id { get; protected init; }

    public string Title { get; protected init; }
    public virtual IReadOnlyCollection<GroupSubject> GroupSubjects => _groupSubjects;

    public bool Equals(Subject? other)
        => other is not null && other.Id.Equals(Id);

    public sealed override bool Equals(object? obj)
        => Equals(obj as Subject);

    public sealed override int GetHashCode()
        => Id.GetHashCode();
}