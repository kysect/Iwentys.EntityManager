using System.Text.RegularExpressions;
using Iwentys.EntityManager.Domain.ValueObjects.Exceptions;

namespace Iwentys.EntityManager.Domain.ValueObjects.Study;

public record GroupName
{
    public GroupName(string name)
    {
        if (!Regex.IsMatch(name))
            throw new InvalidGroupNameException(name);

        Course = int.Parse(name.AsSpan(2, 1));
        Number = int.Parse(name.AsSpan(3, 2));
        Name = name;
    }

    public GroupName(int course, int number)
    {
        if (course is < 0 or > 9 || number is < 0 or > 99)
            throw new InvalidGroupNameException(course, number);

        Course = course;
        Number = number;
        Name = $"M3{course}{number:00}";
    }

    public static Regex Regex { get; } = new Regex("M3[0-9]{3}", RegexOptions.Compiled);

    public int Course { get; }
    public int Number { get; }
    public string Name { get; }

    public override string ToString()
        => Name;
}