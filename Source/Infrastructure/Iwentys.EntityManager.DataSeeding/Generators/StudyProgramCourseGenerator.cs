using Bogus;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.Domain;

namespace Iwentys.EntityManager.DataSeeding;

public class StudyProgramCourseGenerator : IDbContextSeeder
{
    private const int CourseCount = 3;

    public StudyProgramCourseGenerator(Faker<StudyProgram> studyProgramFaker)
    {
        StudyPrograms = new[] { new StudyProgram("ИС") { Id = 1 } };
        var courses = new List<StudyCourse>();
        var identifierGenerator = new IdentifierGenerator();

        for (int i = 0; i < CourseCount; i++)
        {
            var course = new StudyCourse()
            {
                Id = identifierGenerator.Next(),
                GraduationYear = StudentGraduationYear.Y22,
                StudyProgramId = FakerSingleton.Instance.PickRandom(StudyPrograms).Id
            };

            courses.Add(course);
        }

        StudyCourses = courses.ToArray();
    }

    public StudyProgram[] StudyPrograms { get; }
    public StudyCourse[] StudyCourses { get; }

    public void Seed(IwentysEntityManagerDbContext context)
    {
        context.StudyPrograms.AddRange(StudyPrograms);
        context.StudyCourses.AddRange(StudyCourses);
        context.SaveChanges();
    }
}