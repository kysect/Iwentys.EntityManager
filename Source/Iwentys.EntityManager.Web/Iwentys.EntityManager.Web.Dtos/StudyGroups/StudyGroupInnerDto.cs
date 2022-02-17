namespace Iwentys.EntityManager.WebApiDtos;

public record StudyGroupInnerDto(
    int Id,
    string GroupName,
    int? GroupAdminId);