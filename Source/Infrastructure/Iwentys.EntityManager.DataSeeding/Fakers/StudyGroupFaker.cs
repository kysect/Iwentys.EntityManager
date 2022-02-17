using Bogus;
using Bogus.DataSets;
using Iwentys.EntityManager.Domain;

namespace Iwentys.EntityManager.DataSeeding;

public class StudyGroupFaker : Faker<StudyGroup>
{
    private static readonly Faker _faker = new Faker();

    public StudyGroupFaker(StudyProgramCourseGenerator studyProgramCourseGenerator)
    {
// TODO: Proper StudyCourse seeding injection
        StudyCourse studyCourse = new Faker().PickRandom(studyProgramCourseGenerator.StudyCourses);
        CustomInstantiator(f => new StudyGroup(MakeGroupName(f).Name, studyCourse.Id) {Id = GetId() });
    }

    private int GetId()
    {
        return _faker.IndexVariable++ + 1;
    }

    private static GroupName MakeGroupName(Faker faker)
        => new GroupName(faker.Random.Int(0, 10), faker.Random.Int(10, 100));
}