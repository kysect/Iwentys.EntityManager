using Bogus;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.DataSeeding;

public class TeacherGenerator : IDbContextSeeder
{
    private const int TeacherCount = 10;
    
    public TeacherGenerator(Faker<Teacher> teacherFaker)
    {
        Teachers = teacherFaker.Generate(TeacherCount).ToArray();
    }

    public Teacher[] Teachers { get; }
    
    public void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Teacher>().HasData(Teachers);
    }
}