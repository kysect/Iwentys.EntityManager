namespace Iwentys.EntityManager.Domain;

public class StudyProgram
{
    public StudyProgram(string name)
    {
        ArgumentNullException.ThrowIfNull(name);
        Name = name;
    }

    public int Id { get; init; }
    public string Name { get; init; }
}