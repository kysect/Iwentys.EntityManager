using Bogus;
using Iwentys.EntityManager.Domain.Entities.Study;
using Iwentys.EntityManager.Domain.ValueObjects.Users;

namespace Iwentys.EntityManager.DataSeeding;

public class StudyProgramFaker : Faker<StudyProgram>
{
    public StudyProgramFaker()
    {
        RuleFor(p => p.Name, f => f.Commerce.Department());
    }
}