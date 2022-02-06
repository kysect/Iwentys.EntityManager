using Bogus;
using Iwentys.EntityManager.Domain;
using Iwentys.EntityManager.Domain.Entities.Study;

namespace Iwentys.EntityManager.DataSeeding;

public class SubjectFaker : Faker<Subject>
{
    private SubjectFaker()
    {
        RuleFor(t => t.Title, f => f.Hacker.Noun());
    }
}