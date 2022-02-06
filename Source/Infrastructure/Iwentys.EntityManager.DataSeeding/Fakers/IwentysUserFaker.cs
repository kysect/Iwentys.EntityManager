using Iwentys.EntityManager.DataSeeding.Tools;
using Iwentys.EntityManager.Domain.Entities.Users;

namespace Iwentys.EntityManager.DataSeeding;

public class IwentysUserFaker<T> : UniversitySystemUserFaker<T>
    where T : IwentysUser
{
    public IwentysUserFaker(UserIdentifierProvider identifierProvider) : base(identifierProvider)
    {
        RuleFor(u => u.GithubUsername, f => f.Internet.UserName());
        RuleFor(u => u.AvatarUrl, f => f.Image.PicsumUrl());
    }
}