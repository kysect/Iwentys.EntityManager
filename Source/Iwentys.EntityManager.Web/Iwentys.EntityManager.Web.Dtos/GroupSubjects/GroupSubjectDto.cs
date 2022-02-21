namespace Iwentys.EntityManager.WebApiDtos;

public record GroupSubjectDto(
    SubjectDto Subject,
    StudyGroupInnerDto StudyGroup,
    string TableLink);