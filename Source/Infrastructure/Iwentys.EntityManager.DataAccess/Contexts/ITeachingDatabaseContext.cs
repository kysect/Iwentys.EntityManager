using Iwentys.EntityManager.Domain.Entities.Teaching;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.DataAccess;

public interface ITeachingDatabaseContext
{
    DbSet<GroupSubject> GroupSubjects { get; }
    DbSet<GroupSubjectTeacher> GroupSubjectTeachers { get; }
}