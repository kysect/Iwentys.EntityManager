using Iwentys.EntityManager.Domain.Entities.Study;
using Iwentys.EntityManager.Domain.Entities.Teaching;
using Iwentys.EntityManager.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Iwentys.EntityManager.DataAccess;

public class IwentysEntityManagerDatabaseContext : DbContext, IUsersDatabaseContext, IStudyDatabaseContext,
    ITeachingDatabaseContext
{
    private readonly IDbContextSeeder _dbContextSeeder;

    public IwentysEntityManagerDatabaseContext(
        DbContextOptions<IwentysEntityManagerDatabaseContext> options, IDbContextSeeder dbContextSeeder) : base(options)
    {
        _dbContextSeeder = dbContextSeeder;
    }

    public DbSet<UniversitySystemUser> UniversitySystemUsers { get; protected init; }
    public DbSet<IwentysUser> IwentysUsers { get; protected init; }
    public DbSet<AdminIwentysUser> AdminIwentysUsers { get; protected init; }
    public DbSet<Student> Students { get; protected init; }
    public DbSet<Teacher> Teachers { get; protected init; }

    public DbSet<StudyCourse> StudyCourses { get; protected init; }
    public DbSet<StudyGroup> StudyGroups { get; protected init; }
    public DbSet<StudyGroupAdmin> StudyGroupAdmins { get; protected init; }
    public DbSet<StudyProgram> StudyPrograms { get; protected init; }
    public DbSet<Subject> Subjects { get; protected init; }

    public DbSet<GroupSubject> GroupSubjects { get; protected init; }
    public DbSet<GroupSubjectTeacher> GroupSubjectTeachers { get; protected init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IAssemblyMarker).Assembly);

        _dbContextSeeder.Seed(modelBuilder);

        RemoveCascadeDeleting(modelBuilder);
    }

    //TODO: temp hack
    private static void RemoveCascadeDeleting(ModelBuilder modelBuilder)
    {
        IEnumerable<IMutableForeignKey> cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

        foreach (IMutableForeignKey fk in cascadeFKs)
            fk.DeleteBehavior = DeleteBehavior.Restrict;
    }
}