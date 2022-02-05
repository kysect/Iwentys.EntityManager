using Microsoft.EntityFrameworkCore;

namespace Iwentys.EntityManager.Infrastructure.DataSeeding;

public interface IEntityGenerator
{
    void Seed(ModelBuilder modelBuilder);
}