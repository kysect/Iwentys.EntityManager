using Bogus;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.Domain;

namespace Iwentys.EntityManager.DataSeeding;

public class TeacherGenerator : IDbContextSeeder
{
    private const int TeacherCount = 10;

    public TeacherGenerator(Faker<GroupSubjectTeacher> teacherFaker)
    {
        Teachers = teacherFaker.Generate(TeacherCount).ToArray();
    }

    public GroupSubjectTeacher[] Teachers { get; }

    public void Seed(IwentysEntityManagerDbContext context)
    {
        context.GroupSubjectTeacher.AddRange(Teachers);
        context.SaveChanges();
    }
}