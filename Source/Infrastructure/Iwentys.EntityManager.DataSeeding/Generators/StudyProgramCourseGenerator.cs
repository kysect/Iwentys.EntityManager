using Bogus;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.Domain.Entities.Study;
using Iwentys.EntityManager.Domain.ValueObjects.Users;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.DataSeeding;

public class StudyProgramCourseGenerator : IDbContextSeeder
{
    private const int CourseCount = 3;

    public StudyProgramCourseGenerator(Faker<StudyProgram> studyProgramFaker)
    {
        StudyPrograms = new[] { new StudyProgram("ИС") };
        var courses = new List<StudyCourse>();

        for (int i = 0; i < CourseCount; i++)
        {
            var course = new StudyCourse(
                new GraduationYear($"Y{FakerSingleton.Instance.Random.Int(10, 99)}"),
                FakerSingleton.Instance.PickRandom(StudyPrograms));
            courses.Add(course);
        }

        StudyCourses = courses.ToArray();
    }

    public StudyProgram[] StudyPrograms { get; }
    public StudyCourse[] StudyCourses { get; }

    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudyProgram>().HasData(StudyPrograms);
        modelBuilder.Entity<StudyCourse>().HasData(StudyCourses);
    }
}