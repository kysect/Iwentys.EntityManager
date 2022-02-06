using Bogus;
using Iwentys.EntityManager.DataAccess;
using Iwentys.EntityManager.DataSeeding.Tools;
using Iwentys.EntityManager.Domain.Entities.Study;
using Iwentys.EntityManager.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Iwentys.EntityManager.DataSeeding;

[IgnoreAssemblyScanner]
public class DatabaseContextGenerator : IDbContextSeeder
{
    private readonly IReadOnlyCollection<IDbContextSeeder> _generators;

    public DatabaseContextGenerator()
    {
        var collection = new ServiceCollection();

        collection.AddSingleton(new UserIdentifierProvider());

        collection.AddSingleton<Faker<UniversitySystemUser>, UniversitySystemUserFaker<UniversitySystemUser>>();
        collection.AddSingleton<Faker<IwentysUser>, IwentysUserFaker<IwentysUser>>();
        collection.AddSingleton<Faker<Student>, IwentysUserFaker<Student>>();
        collection.AddSingleton<Faker<Teacher>, IwentysUserFaker<Teacher>>();

        collection.AddSingleton<Faker<StudyGroup>, StudyGroupFaker>();
        collection.AddSingleton<Faker<Subject>, SubjectFaker>();

        collection.AddSingleton<Faker<StudyProgram>, StudyProgramFaker>();

        _generators = DatabaseContextSeederAssemblyScanner.GetInstances(collection, typeof(IAssemblyMarker));
    }

    public void Seed(ModelBuilder modelBuilder)
    {
        foreach (var seeder in _generators)
        {
            seeder.Seed(modelBuilder);
        }
    }
}