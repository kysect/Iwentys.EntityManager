using Iwentys.EntityManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.DataAccess;

public interface IAccountManagementDbContext
{
    DbSet<UniversitySystemUser> UniversitySystemUsers { get; set; }
    DbSet<IwentysUser> IwentysUsers { get; set; }
}
