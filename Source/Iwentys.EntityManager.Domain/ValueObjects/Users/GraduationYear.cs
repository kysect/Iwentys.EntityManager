using System.Text.RegularExpressions;
using Iwentys.EntityManager.Domain.ValueObjects.Exceptions;

namespace Iwentys.EntityManager.Domain.ValueObjects.Users;

public record GraduationYear
{
    public GraduationYear(string value)
    {
        if (!Regex.IsMatch(value))
            throw new InvalidGraduationYearException(value);

        Value = value;
        Year = int.Parse(value.AsSpan(0, 2));
    }

    protected GraduationYear() { }

    public static Regex Regex { get; } = new Regex("Y[0-9]{2}", RegexOptions.Compiled);

    public string Value { get; protected init; }
    public int Year { get; protected init; }

    public GraduationYear Copy()
        => new GraduationYear { Value = Value, Year = Year };
}