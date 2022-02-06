namespace Iwentys.EntityManager.Domain.ValueObjects.Study;

public record TeacherType
{
    protected TeacherType(string value)
    {
        Value = value;
    }

    public static TeacherType Lecturer => new TeacherType(nameof(Lecturer));
    public static TeacherType Practice => new TeacherType(nameof(Practice));
    public static TeacherType Mentor => new TeacherType(nameof(Mentor));

    public string Value { get; protected init; }

    public override string ToString()
        => Value;

    public TeacherType Copy()
        => new TeacherType(Value);

    public static TeacherType Parse(string value)
    {
        return value switch
        {
            nameof(Lecturer) => Lecturer,
            nameof(Practice) => Practice,
            nameof(Mentor) => Mentor,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value),
        };
    }
}