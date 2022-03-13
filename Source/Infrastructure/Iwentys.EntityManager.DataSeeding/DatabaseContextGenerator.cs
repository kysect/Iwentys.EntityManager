using Bogus;
using Iwentys.EntityManager.DataAccess;

namespace Iwentys.EntityManager.DataSeeding;

public class DatabaseContextGenerator : IDbContextSeeder
{
    private readonly List<IDbContextSeeder> _generators;

    public DatabaseContextGenerator()
    {
        _generators = new List<IDbContextSeeder>();

        StudyProgramFaker studyProgramFaker = new StudyProgramFaker();
        StudyProgramCourseGenerator studyProgramCourseGenerator = Register(new StudyProgramCourseGenerator(studyProgramFaker));
        StudyGroupGenerator studyGroupGenerator = Register(new StudyGroupGenerator(new StudyGroupFaker(studyProgramCourseGenerator), studyProgramCourseGenerator));
    }

    public void Seed(IwentysEntityManagerDbContext context)
    {
        _generators.ForEach(eg => eg.Seed(context));
        context.SaveChanges();
    }

    private T Register<T>(T entityGenerator) where T : IDbContextSeeder
    {
        _generators.Add(entityGenerator);
        return entityGenerator;
    }
}