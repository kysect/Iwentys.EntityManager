namespace Iwentys.EntityManager.Domain;

public class IwentysUser : UniversitySystemUser
{
    public IwentysUser(
        string firstName,
        string middleName,
        string lastName,
        bool isAdmin,
        string githubUsername,
        DateTime creationTime,
        DateTime lastOnlineTime,
        string avatarUrl)
        : base(firstName, middleName, lastName)
    {
        ArgumentNullException.ThrowIfNull(githubUsername);
        ArgumentNullException.ThrowIfNull(avatarUrl);

        IsAdmin = isAdmin;
        GithubUsername = githubUsername;
        CreationTime = creationTime;
        LastOnlineTime = lastOnlineTime;
        AvatarUrl = avatarUrl;
    }

    protected IwentysUser() { }

    public bool IsAdmin { get; set; }
    public string GithubUsername { get; set; }
    public DateTime CreationTime { get; init; }
    public DateTime LastOnlineTime { get; set; }
    public string AvatarUrl { get; set; }

    public void UpdateGithubUsername(string githubUsername)
    {
        GithubUsername = githubUsername;
    }
}