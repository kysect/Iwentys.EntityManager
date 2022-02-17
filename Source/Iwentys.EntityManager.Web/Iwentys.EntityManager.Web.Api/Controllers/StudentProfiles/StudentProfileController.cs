using Iwentys.EntityManager.WebApiDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Iwentys.EntityManager.WebApi;

[Route("api/student-profile")]
[ApiController]
public class StudentProfileController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentProfileController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(nameof(Get))]
    public async Task<ActionResult<IReadOnlyCollection<StudentInfoDto>>> Get()
    {
        GetStudentProfiles.Response response = await _mediator.Send(new GetStudentProfiles.Query());
        return Ok(response.Students);
    }

    [HttpGet(nameof(GetStudentProfileByGithubUsername))]
    public async Task<ActionResult<StudentInfoDto>> GetStudentProfileByGithubUsername(string githubUsername)
    {
        GetStudentProfileByGithubUsername.Response response = await _mediator.Send(new GetStudentProfileByGithubUsername.Query(githubUsername));
        var result = response.Student;

        return result is not null ? Ok(result) : NotFound();
    }

    [HttpGet(nameof(GetStudentProfileById))]
    public async Task<ActionResult<StudentInfoDto>> GetStudentProfileById(int id)
    {
        GetStudentProfileById.Response response = await _mediator.Send(new GetStudentProfileById.Query(id));
        var result = response.Student;

        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost(nameof(GetStudentProfilesByIdList))]
    public async Task<ActionResult<IReadOnlyCollection<StudyGroupProfileResponseDto>>> GetStudentProfilesByIdList(
        List<int> studentIdList)
    {
        GetStudentProfilesByIdList.Response response = await _mediator.Send(new GetStudentProfilesByIdList.Query(studentIdList));

        return Ok(response.Students);
    }

    [HttpPost(nameof(GetStudentProfilesByGithubUsernamesList))]
    public async Task<ActionResult<IReadOnlyCollection<StudentInfoDto>>> GetStudentProfilesByGithubUsernamesList(
        List<string> githubUsernamesList)
    {
        GetStudentProfilesByGithubUsernamesList.Response response = await _mediator.Send(new GetStudentProfilesByGithubUsernamesList.Query(githubUsernamesList));

        return Ok(response.Students);
    }

    [HttpGet(nameof(GetStudentProfilesByGroupId))]
    public async Task<ActionResult<IReadOnlyCollection<StudentInfoDto>>> GetStudentProfilesByGroupId(int groupId)
    {
        GetStudentProfilesByGroupId.Response response = await _mediator.Send(new GetStudentProfilesByGroupId.Query(groupId));

        return Ok(response.Students);
    }

    [HttpGet(nameof(GetStudentProfilesByCourseId))]
    public async Task<ActionResult<IReadOnlyCollection<StudentInfoDto>>> GetStudentProfilesByCourseId(int courseId)
    {
        GetStudentProfilesByCourseId.Response response = await _mediator.Send(new GetStudentProfilesByCourseId.Query(courseId));

        return Ok(response.Students);
    }

    [HttpGet(nameof(GetStudentProfilesByCredentials))]
    public async Task<ActionResult<IReadOnlyCollection<StudentInfoDto>>> GetStudentProfilesByCredentials(
        string credentials)
    {
        GetStudentProfilesByCredentials.Response response = await _mediator.Send(new GetStudentProfilesByCredentials.Query(credentials));

        return Ok(response.Students);
    }

    // TODO: To fix GroupSubjects list cause it's null and method doesn't work properly
    [HttpGet(nameof(GetStudentProfilesBySubjectId))]
    public async Task<ActionResult<IReadOnlyCollection<StudentInfoDto>>> GetStudentProfilesBySubjectId(int subjectId)
    {
        GetStudentProfilesBySubjectId.Response response = await _mediator.Send(new GetStudentProfilesBySubjectId.Query(subjectId));

        return Ok(response.Students);
    }
}