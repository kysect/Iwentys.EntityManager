namespace Iwentys.EntityManager.Dtos;

public record GroupSubjectDto(
    SubjectDto Subject,
    StudyGroupInnerDto StudyGroup,
    string? GithubOrganization,
    string TableLink);