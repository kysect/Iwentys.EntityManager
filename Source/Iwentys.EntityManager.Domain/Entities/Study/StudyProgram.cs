namespace Iwentys.EntityManager.Domain.Entities.Study;

public class StudyProgram : IEquatable<StudyProgram>
{
    public StudyProgram(string name)
    {
        Id = new Guid();
        Name = name;
    }

    protected StudyProgram() { }

    public Guid Id { get; protected init; }

    public string Name { get; protected init; }

    public bool Equals(StudyProgram? other)
        => other is not null && other.Id.Equals(Id);

    public sealed override bool Equals(object? obj)
        => Equals(obj as StudyProgram);

    public sealed override int GetHashCode()
        => Id.GetHashCode();
}