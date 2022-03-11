using Bogus;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.Domain;

namespace Iwentys.EntityManager.DataSeeding;

public class SubjectGenerator : IDbContextSeeder
{
    private const int SubjectCount = 10;
    
    public SubjectGenerator(Faker<Subject> subjectFaker)
    {
        Subjects = subjectFaker.Generate(SubjectCount).ToArray();
        Console.WriteLine();
    }
    
    public Subject[] Subjects { get; }
    
    public void Seed(IwentysEntityManagerDbContext context)
    {
        context.Subjects.AddRange(Subjects);
    }
}