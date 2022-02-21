namespace Iwentys.EntityManager.WebApiDtos;

public record SubjectTeachersDto(
    int SubjectId,
    string Name,
    IReadOnlyList<GroupTeachersResponseDto> GroupTeachers);