namespace Iwentys.EntityManager.Application.Abstractions;

public interface IIwentysEntityManagerDbContext : IAccountManagementDbContext, IStudyDbContext
{
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}