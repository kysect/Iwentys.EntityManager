using Iwentys.EntityManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Application.Abstractions;

public interface IStudyDbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<StudyGroup> StudyGroups { get; set; }
    public DbSet<StudyProgram> StudyPrograms { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<GroupSubject> GroupSubjects { get; set; }
    public DbSet<GroupSubjectTeacher> GroupSubjectTeacher { get; set; }
    public DbSet<StudyCourse> StudyCourses { get; set; }
}