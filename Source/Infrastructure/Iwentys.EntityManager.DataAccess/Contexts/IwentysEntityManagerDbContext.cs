using Iwentys.EntityManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Iwentys.EntityManager.DataAccess;

public class IwentysEntityManagerDbContext : DbContext, IAccountManagementDbContext, IStudyDbContext
{
    private readonly IDbContextSeeder _dbContextSeeder;

    public DbSet<IwentysUser> IwentysUsers { get; set; } = null!;
    public DbSet<UniversitySystemUser> UniversitySystemUsers { get; set; } = null!;

    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<StudyGroup> StudyGroups { get; set; } = null!;
    public DbSet<StudyProgram> StudyPrograms { get; set; } = null!;
    public DbSet<Subject> Subjects { get; set; } = null!;
    public DbSet<GroupSubject> GroupSubjects { get; set; } = null!;
    public DbSet<GroupSubjectTeacher> GroupSubjectTeacher { get; set; } = null!;
    public DbSet<StudyCourse> StudyCourses { get; set; } = null!;

    public IwentysEntityManagerDbContext(
        DbContextOptions<IwentysEntityManagerDbContext> options,
        IDbContextSeeder dbContextSeeder)
        : base(options)
    {
        _dbContextSeeder = dbContextSeeder;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.OnStudyModelCreating();

        _dbContextSeeder.Seed(modelBuilder);

        RemoveCascadeDeleting(modelBuilder);
        base.OnModelCreating(modelBuilder);
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