namespace Iwentys.EntityManager.Dtos;

public record StudyGroupInnerDto(
    int Id,
    string GroupName,
    int? GroupAdminId);