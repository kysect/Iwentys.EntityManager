namespace Iwentys.EntityManager.Dtos;

public record SubjectTeachersDto(
    int SubjectId,
    string Name,
    IReadOnlyList<GroupTeachersResponseDto> GroupTeachers);