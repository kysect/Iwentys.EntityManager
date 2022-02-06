using Iwentys.EntityManager.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.DataAccess;

public interface IUsersDatabaseContext
{
    DbSet<UniversitySystemUser> UniversitySystemUsers { get; }
    DbSet<IwentysUser> IwentysUsers { get; }
    DbSet<AdminIwentysUser> AdminIwentysUsers { get; }
    DbSet<Student> Students { get; }
    DbSet<Teacher> Teachers { get; }
}