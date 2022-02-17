using Iwentys.EntityManager.Domain;

namespace Iwentys.EntityManager.WebApiDtos;

public class StudentDto : IwentysUserDto
{
    public StudentType Type { get; init; }
    public int? GroupId { get; set; }

    //public string SocialStatus { get; set; }
    //public string AdditionalLink { get; set; }
}