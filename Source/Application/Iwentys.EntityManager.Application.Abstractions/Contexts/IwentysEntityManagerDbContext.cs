namespace Iwentys.EntityManager.Application.Abstractions;

public interface IwentysEntityManagerDbContext : IAccountManagementDbContext, IStudyDbContext
{
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}