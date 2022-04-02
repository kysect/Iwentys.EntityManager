using Iwentys.EntityManager.Domain;

namespace Iwentys.EntityManager.Dtos;

public record CreateSubjectTeacherRequestDto(
    int SubjectId,
    int TeacherId,
    TeacherType TeacherType,
    IReadOnlyList<int> GroupSubjectIds);