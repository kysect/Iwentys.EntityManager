using Iwentys.EntityManager.Application.Abstractions;

namespace Iwentys.EntityManager.DataAccess;

public interface IDbContextSeeder
{
    void Seed(IIwentysEntityManagerDbContext context);
}