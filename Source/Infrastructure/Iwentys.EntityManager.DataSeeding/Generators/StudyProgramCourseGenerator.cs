using Bogus;
using Iwentys.EntityManager.Common;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.DataSeeding;

public class StudyProgramCourseGenerator : IDbContextSeeder
{
    private const int CourseCount = 3;

    public StudyProgramCourseGenerator(Faker<StudyProgram> studyProgramFaker)
    {
        StudyPrograms = new[] { new StudyProgram { Id = 1, Name = "ИС" } };
        var courses = new List<StudyCourse>();
        var identifierGenerator = new IdentifierGenerator();

        for (int i = 0; i < CourseCount; i++)
        {
            var course = new StudyCourse(StudentGraduationYear.Y22, FakerSingleton.Instance.PickRandom(StudyPrograms))
            {
                Id = identifierGenerator.Next(),
            };

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