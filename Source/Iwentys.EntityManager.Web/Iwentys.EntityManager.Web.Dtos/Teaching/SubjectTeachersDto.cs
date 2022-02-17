namespace Iwentys.EntityManager.WebApiDtos;

public record SubjectTeachersDto
{
    public int SubjectId { get; set; }
    public string Name { get; set; }
    public IReadOnlyList<GroupTeachersResponseDto> GroupTeachers { get; set; }

    public SubjectTeachersDto()
    {

    }

    public SubjectTeachersDto(int subjectId, string name, IReadOnlyList<GroupTeachersResponseDto> groupTeachers)
    {
        SubjectId = subjectId;
        Name = name;
        GroupTeachers = groupTeachers;
    }
}