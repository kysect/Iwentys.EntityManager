namespace Iwentys.EntityManager.Domain.Entities.Users;

public class IwentysUser : UniversitySystemUser
{
    public IwentysUser(
        int id,
        string firstName,
        string middleName,
        string lastName,
        string githubUsername,
        DateTime creationTime,
        DateTime lastOnlineTime,
        string avatarUrl)
        : base(id, firstName, middleName, lastName)
    {
        GithubUsername = githubUsername;
        CreationTime = creationTime;
        LastOnlineTime = lastOnlineTime;
        AvatarUrl = avatarUrl;
    }

    protected IwentysUser() { }

    public string GithubUsername { get; set; }
    public DateTime CreationTime { get; protected init; }
    public DateTime LastOnlineTime { get; set; }
    public string AvatarUrl { get; set; }
}