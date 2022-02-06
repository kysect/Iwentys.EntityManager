using Iwentys.EntityManager.Domain.Entities.Study;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.DataAccess;

public interface IStudyDatabaseContext
{
    DbSet<StudyCourse> StudyCourses { get; }
    DbSet<StudyGroup> StudyGroups { get; }
    DbSet<StudyGroupAdmin> StudyGroupAdmins { get; }
    DbSet<StudyProgram> StudyPrograms { get; }
    DbSet<Subject> Subjects { get; }
}