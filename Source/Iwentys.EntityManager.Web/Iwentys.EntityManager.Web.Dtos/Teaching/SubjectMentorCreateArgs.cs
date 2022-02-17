using Iwentys.EntityManager.Domain;

namespace Iwentys.EntityManager.WebApiDtos;

public record CreateSubjectTeacherRequestDto(
    int SubjectId,
    int TeacherId,
    TeacherType TeacherType,
    IReadOnlyList<int> GroupSubjectIds);