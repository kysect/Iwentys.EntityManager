namespace Iwentys.EntityManager.WebApiDtos;

public class GroupTeachersResponseDto
{
    public int GroupId { get; set; }
    public string GroupName { get; set; }
    public IReadOnlyList<TeacherDto> Teachers { get; set; }

    public GroupTeachersResponseDto()
    {
    }

    public GroupTeachersResponseDto(int groupId, string name, IReadOnlyList<TeacherDto> teachers)
    {
        GroupId = groupId;
        GroupName = name;
        Teachers = teachers;
    }
}