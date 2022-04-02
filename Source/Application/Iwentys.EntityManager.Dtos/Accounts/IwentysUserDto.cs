namespace Iwentys.EntityManager.Dtos;

public record IwentysUserDto(
        int Id,
        string FirstName,
        string MiddleName,
        string SecondName,
        bool IsAdmin,
        string GithubUsername,
        DateTime CreationTime,
        DateTime LastOnlineTime,
        string AvatarUrl);