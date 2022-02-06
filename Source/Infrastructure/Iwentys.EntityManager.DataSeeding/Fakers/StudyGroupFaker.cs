using Bogus;
using Iwentys.EntityManager.Domain;
using Iwentys.EntityManager.Domain.Entities.Study;
using Iwentys.EntityManager.Domain.ValueObjects.Study;

namespace Iwentys.EntityManager.DataSeeding;

public class StudyGroupFaker : Faker<StudyGroup>
{
    public StudyGroupFaker()
    {
        CustomInstantiator(f => new StudyGroup(MakeGroupName(f), null));
    }

    private static GroupName MakeGroupName(Faker faker)
        => new GroupName(faker.Random.Int(0, 10), faker.Random.Int(10, 100));
}