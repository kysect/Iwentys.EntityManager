using Bogus;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.Domain;

namespace Iwentys.EntityManager.DataSeeding;

public class StudyGroupGenerator : IDbContextSeeder
{
    private const int GroupCount = 10;

    public StudyGroupGenerator(Faker<StudyGroup> studyGroupFaker, StudyProgramCourseGenerator studyProgramCourseGenerator)
    {
        List<StudyGroup> groups = studyGroupFaker.Generate(GroupCount);

        foreach (var studyGroup in groups)
        {
            var course = FakerSingleton.Instance.PickRandom(studyProgramCourseGenerator.StudyCourses);
            studyGroup.StudyCourseId = course.Id;
        }

        StudyGroup frediGroup = studyGroupFaker.Generate();
        frediGroup.GroupName = new GroupName("M3505").Name;
        groups.Add(frediGroup);

        StudyGroups = groups.ToArray();
    }

    public StudyGroup[] StudyGroups { get; }

    public void Seed(IwentysEntityManagerDbContext context)
    {
        context.StudyGroups.AddRange(StudyGroups);
    }
}