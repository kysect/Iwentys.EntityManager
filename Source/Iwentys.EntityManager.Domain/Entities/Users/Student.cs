using Iwentys.EntityManager.Domain.Entities.Study;

namespace Iwentys.EntityManager.Domain.Entities.Users;

public class Student : IwentysUser
{
    public Student(
        int id,
        string firstName,
        string middleName,
        string lastName,
        string githubUsername,
        DateTime creationTime,
        DateTime lastOnlineTime,
        string avatarUrl)
        : base(id, firstName, middleName, lastName, githubUsername, creationTime, lastOnlineTime, avatarUrl) { }

    protected Student() { }

    public virtual StudyGroup? Group { get; protected init; }
}