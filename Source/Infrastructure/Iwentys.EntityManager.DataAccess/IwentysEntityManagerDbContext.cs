using Iwentys.EntityManager.Application.Abstractions;
using Iwentys.EntityManager.Domain;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.DataAccess;

public class IwentysEntityManagerDbContext : DbContext, IIwentysEntityManagerDbContext
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

        modelBuilder.Entity<GroupSubject>().Navigation(gs => gs.Teachers).HasField("_teachers");
        modelBuilder.Entity<GroupSubject>().HasMany(gs => gs.Teachers).WithOne(t => t.GroupSubject);
        modelBuilder.Entity<StudyGroup>().Navigation(sg => sg.Students).HasField("_students");
        modelBuilder.Entity<StudyGroup>().HasMany(sg => sg.Students).WithOne(s => s.Group);
        modelBuilder.Entity<Subject>().Navigation(s => s.GroupSubjects).HasField("_groupSubjects");
        modelBuilder.Entity<Subject>().HasMany(s => s.GroupSubjects).WithOne(gs => gs.Subject);

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