using Iwentys.EntityManager.Dtos.ValueObjects;

namespace Iwentys.EntityManager.Dtos;

public record StudyGroupDto(
    int Id,
    GroupNameDto GroupName,
    int? GroupAdminId,
    List<StudentDto> Students,
    List<SubjectDto> Subjects)
{
    public StudentDto? GroupAdmin => GroupAdminId is null ? null : Students.Find(s => s.Id == GroupAdminId);
}