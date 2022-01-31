using Iwentys.EntityManager.PublicTypes;

namespace Iwentys.EntityManager.WebApiDtos;

public record SubjectSearchParametersDto
{
    private const int DefaultSkipValue = 0;
    private const int DefaultTakeValue = 20;

    public SubjectSearchParametersDto(
        int? studentId,
        int? groupId,
        int? subjectId,
        int? courseId,
        StudySemester? studySemester,
        int? skip = DefaultSkipValue,
        int? take = DefaultTakeValue)
        : this()
    {
        StudentId = studentId;
        GroupId = groupId;
        SubjectId = subjectId;
        CourseId = courseId;
        StudySemester = studySemester;
        Skip = skip;
        Take = take;
    }

    public SubjectSearchParametersDto()
    {
    }

    public int? StudentId { get; init; }
    public int? GroupId { get; init; }
    public int? SubjectId { get; init; }
    public int? CourseId { get; init; }
    public StudySemester? StudySemester { get; init; }
    public int? Skip { get; init; }
    public int? Take { get; init; }

    public static SubjectSearchParametersDto ForGroup(int groupId)
    {
        return new SubjectSearchParametersDto(null, groupId, null, null, null);
    }

    public static SubjectSearchParametersDto ForStudent(int studentId)
    {
        return new SubjectSearchParametersDto(studentId, null, null, null, null);
    }
}