using Iwentys.EntityManager.Common;
using Iwentys.EntityManager.Domain;

namespace Iwentys.EntityManager.DataSeeding;

public class IwentysUserFaker<T> : UniversitySystemUserFaker<T>
    where T : IwentysUser
{
    public IwentysUserFaker(IdentifierGenerator identifierProvider) : base(identifierProvider)
    {
        RuleFor(u => u.GithubUsername, f => f.Internet.UserName());
        RuleFor(u => u.AvatarUrl, f => f.Image.PicsumUrl());
    }
}