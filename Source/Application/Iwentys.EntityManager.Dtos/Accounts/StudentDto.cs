using Iwentys.EntityManager.Domain;

namespace Iwentys.EntityManager.Dtos;

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
        int? GroupId,
        StudentStatus StudentStatus);