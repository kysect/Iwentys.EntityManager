namespace Iwentys.EntityManager.WebApiDtos;

public record GroupTeachersResponseDto(
    int GroupId,
    string GroupName,
    IReadOnlyList<TeacherDto> Teachers);