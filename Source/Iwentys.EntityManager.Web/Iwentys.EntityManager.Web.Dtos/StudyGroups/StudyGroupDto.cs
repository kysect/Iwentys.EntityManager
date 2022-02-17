namespace Iwentys.EntityManager.WebApiDtos;

public record StudyGroupDto
{
    public int Id { get; init; }
    public string GroupName { get; init; }
    public int? GroupAdminId { get; set; }
    public List<StudentDto> Students { get; set; }
    public List<SubjectDto> Subjects { get; init; }

    public StudentDto? GroupAdmin => GroupAdminId is null ? null : Students.Find(s => s.Id == GroupAdminId);
}