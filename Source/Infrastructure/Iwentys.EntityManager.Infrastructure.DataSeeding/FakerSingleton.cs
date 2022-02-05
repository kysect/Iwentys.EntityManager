using Bogus;

namespace Iwentys.EntityManager.Infrastructure.DataSeeding;

public class FakerSingleton
{
    public static readonly Faker Instance = new Faker();
}