using Bogus;
using Iwentys.EntityManager.Domain;

namespace Iwentys.EntityManager.DataSeeding;

public class StudyProgramFaker : Faker<StudyProgram>
{
    public StudyProgramFaker()
    {
        RuleFor(p => p.Name, f => f.Commerce.Department());
    }
}