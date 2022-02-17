namespace Iwentys.EntityManager.WebApiDtos;

public class GroupSubjectDto
{
    public SubjectDto Subject { get; init; }

    public StudyGroupInnerDto StudyGroup { get; init; }

    public string TableLink { get; set; }
}