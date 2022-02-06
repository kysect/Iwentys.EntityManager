namespace Iwentys.EntityManager.Domain.Entities.Users;

public class Teacher : IwentysUser
{
    public Teacher(
        int id,
        string firstName,
        string middleName,
        string lastName,
        string githubUsername,
        DateTime creationTime,
        DateTime lastOnlineTime,
        string avatarUrl)
        : base(id, firstName, middleName, lastName, githubUsername, creationTime, lastOnlineTime, avatarUrl) { }

    protected Teacher() { }
}