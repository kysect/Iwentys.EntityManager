namespace Iwentys.EntityManager.DataAccess;

public interface IDbContextSeeder
{
    void Seed(IwentysEntityManagerDbContext context);
}

public class EmptyDbContextSeeder : IDbContextSeeder
{
    public void Seed(IwentysEntityManagerDbContext context)
    {
    }
}