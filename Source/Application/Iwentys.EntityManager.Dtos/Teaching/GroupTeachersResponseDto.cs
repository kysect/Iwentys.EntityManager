namespace Iwentys.EntityManager.Dtos;

public record GroupTeachersResponseDto(
    int GroupId,
    string GroupName,
    IReadOnlyList<TeacherDto> Teachers);