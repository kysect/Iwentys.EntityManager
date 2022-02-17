namespace Iwentys.EntityManager.WebApiDtos;

public record StudyGroupDto(
    int Id,
    string GroupName,
    int? GroupAdminId,
    List<StudentDto> Students,
    List<SubjectDto> Subjects)
{
    public StudentDto? GroupAdmin => GroupAdminId is null ? null : Students.Find(s => s.Id == GroupAdminId);
}