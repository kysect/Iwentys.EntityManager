using Bogus;
using Iwentys.EntityManager.Common;
using Iwentys.EntityManager.Domain;

namespace Iwentys.EntityManager.DataSeeding;

public class UniversitySystemUserFaker<T> : Faker<T>
    where T : UniversitySystemUser
{
    public UniversitySystemUserFaker(IdentifierGenerator identifierProvider)
    {
        RuleFor(u => u.Id, identifierProvider.Next);
        RuleFor(u => u.FirstName, f => f.Name.FirstName());
        RuleFor(u => u.SecondName, f => f.Name.LastName());
        RuleFor(u => u.MiddleName, f => f.Name.Suffix());
    }
}