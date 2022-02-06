using Bogus;
using Iwentys.EntityManager.DataSeeding.Tools;
using Iwentys.EntityManager.Domain.Entities.Users;

namespace Iwentys.EntityManager.DataSeeding;

public class UniversitySystemUserFaker<T> : Faker<T>
    where T : UniversitySystemUser
{
    public UniversitySystemUserFaker(UserIdentifierProvider identifierProvider)
    {
        RuleFor(u => u.Id, identifierProvider.GetIdentifier);
        RuleFor(u => u.FirstName, f => f.Name.FirstName());
        RuleFor(u => u.LastName, f => f.Name.LastName());
        RuleFor(u => u.MiddleName, f => f.Name.Suffix());
    }
}