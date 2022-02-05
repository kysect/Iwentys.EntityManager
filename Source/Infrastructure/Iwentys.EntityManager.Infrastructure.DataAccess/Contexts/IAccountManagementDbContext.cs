using Iwentys.EntityManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Infrastructure.DataAccess;

public interface IAccountManagementDbContext
{
    public DbSet<UniversitySystemUser> UniversitySystemUsers { get; set; }
    public DbSet<IwentysUser> IwentysUsers { get; set; }
}