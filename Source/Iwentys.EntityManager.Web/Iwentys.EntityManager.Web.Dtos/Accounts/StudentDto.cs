using Iwentys.EntityManager.Domain;

namespace Iwentys.EntityManager.WebApiDtos;

public record StudentDto(
        int Id,
        string FirstName,
        string MiddleName,
        string SecondName,
        bool IsAdmin,
        string GithubUsername,
        DateTime CreationTime,
        DateTime LastOnlineTime,
        string AvatarUrl,
        StudentType Type,
        int? GroupId)
    : IwentysUserDto(Id, FirstName, MiddleName, SecondName, IsAdmin, GithubUsername, CreationTime, LastOnlineTime, AvatarUrl);