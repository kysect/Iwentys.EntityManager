namespace Iwentys.EntityManager.Domain.ValueObjects.Study;

public record StudySemester
{
    protected StudySemester(string value)
    {
        Value = value;
    }

    protected StudySemester() { }

    public static StudySemester H1 => new StudySemester(nameof(H1));
    public static StudySemester H2 => new StudySemester(nameof(H2));

    public string Value { get; protected init; }

    public override string ToString()
        => Value;

    public StudySemester Copy()
        => new StudySemester(Value);

    public static StudySemester Parse(string value)
    {
        return value switch
        {
            nameof(H1) => H1,
            nameof(H2) => H2,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value),
        };
    }
}