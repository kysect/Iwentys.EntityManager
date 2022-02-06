using Bogus;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.Domain.Entities.Study;
using Iwentys.EntityManager.Domain.ValueObjects.Study;
using Microsoft.EntityFrameworkCore;

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
            studyGroup.StudyCourse = course;
        }

        var frediGroup = new StudyGroup(
            new GroupName("M3505"), FakerSingleton.Instance.PickRandom(studyProgramCourseGenerator.StudyCourses));
        groups.Add(frediGroup);

        StudyGroups = groups.ToArray();
    }

    public StudyGroup[] StudyGroups { get; }

    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudyGroup>().HasData(StudyGroups);
    }
}