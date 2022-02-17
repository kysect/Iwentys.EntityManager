namespace Iwentys.EntityManager.WebApiDtos;

public record IwentysUserDto(
        int Id,
        string FirstName,
        string MiddleName,
        string SecondName,
        bool IsAdmin,
        string GithubUsername,
        DateTime CreationTime,
        DateTime LastOnlineTime,
        string AvatarUrl)
    : UniversitySystemUserDto(Id, FirstName, MiddleName, SecondName);