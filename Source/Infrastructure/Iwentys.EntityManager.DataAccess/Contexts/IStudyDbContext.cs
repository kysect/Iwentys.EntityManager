using Iwentys.EntityManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.DataAccess;

public interface IStudyDbContext
{
    DbSet<Student> Students { get; set; }
    DbSet<StudyGroup> StudyGroups { get; set; }
    DbSet<StudyProgram> StudyPrograms { get; set; }
    DbSet<Subject> Subjects { get; set; }
    DbSet<GroupSubject> GroupSubjects { get; set; }
    DbSet<GroupSubjectTeacher> GroupSubjectTeacher { get; set; }
    DbSet<StudyCourse> StudyCourses { get; set; }
}

public static class StudyDbContextExtensions
{
    public static void OnStudyModelCreating(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GroupSubjectTeacher>().HasKey(gsm => new { UserId = gsm.TeacherId, gsm.GroupSubjectId, gsm.TeacherType });
    }
}