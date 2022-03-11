using Bogus;
using Iwentys.EntityManager.Domain;

namespace Iwentys.EntityManager.DataSeeding;

public class SubjectFaker : Faker<Subject>
{
    public static readonly SubjectFaker Instance = new SubjectFaker();

    public SubjectFaker()
    {
        CustomInstantiator(faker => new Subject(faker.Hacker.Noun()));
        RuleFor(t => t.Id, f => f.IndexFaker + 1);
    }
}