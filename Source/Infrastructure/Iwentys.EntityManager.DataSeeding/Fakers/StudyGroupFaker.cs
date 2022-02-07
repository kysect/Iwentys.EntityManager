using Bogus;
using Iwentys.EntityManager.Domain;

namespace Iwentys.EntityManager.DataSeeding;

public class StudyGroupFaker : Faker<StudyGroup>
{
    private static readonly Faker _faker = new Faker();

    public StudyGroupFaker()
    {
        CustomInstantiator(f => new StudyGroup {Id = GetId(), GroupName = MakeGroupName(f).Name });
    }

    private int GetId()
    {
        return _faker.IndexVariable++ + 1;
    }

    private static GroupName MakeGroupName(Faker faker)
        => new GroupName(faker.Random.Int(0, 10), faker.Random.Int(10, 100));
}