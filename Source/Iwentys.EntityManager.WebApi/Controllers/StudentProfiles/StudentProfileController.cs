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
        GetStudents.Response response = await _mediator.Send(new GetStudents.Query());
        return Ok(response.Students);
    }

    [HttpGet(nameof(GetStudentProfileById))]
    public async Task<ActionResult<StudentInfoDto>> GetStudentProfileById(int id)
    {
        GetStudentById.Response response = await _mediator.Send(new GetStudentById.Query(id));
        return Ok(response.Student);
    }

    [HttpPost(nameof(GetStudentsByIdList))]
    public async Task<ActionResult<StudyGroupProfileResponseDto>> GetStudentsByIdList([FromBody] List<int> studentIdList)
    {
        GetStudentsByIdList.Response response = await _mediator.Send(new GetStudentsByIdList.Query(studentIdList));
        return Ok(response.Students);
    }

    [HttpGet(nameof(GetStudentProfileByGithubUsername))]
    public async Task<ActionResult<StudentInfoDto>> GetStudentProfileByGithubUsername(string githubUsername)
    {
        GetStudentByGithubUsername.Response response
            = await _mediator.Send(new GetStudentByGithubUsername.Query(githubUsername));

        return Ok(response.Student);
    }

    [HttpPost(nameof(GetStudentProfilesByGithubUsernamesList))]
    public async Task<ActionResult<StudentInfoDto>> GetStudentProfilesByGithubUsernamesList(List<string> githubUsernamesList)
    {
        GetStudentByGithubUsernamesList.Response response
            = await _mediator.Send(new GetStudentByGithubUsernamesList.Query(githubUsernamesList));

        return Ok(response.Students);
    }

    [HttpGet(nameof(GetStudentProfileByGroupId))]
    public async Task<ActionResult<IReadOnlyCollection<StudentInfoDto>>> GetStudentProfileByGroupId(int groupId)
    {
        GetStudentByGroupId.Response response = await _mediator.Send(new GetStudentByGroupId.Query(groupId));
        return Ok(response.Students);
    }

    [HttpGet(nameof(GetStudentProfileByCourseId))]
    public async Task<ActionResult<IReadOnlyCollection<StudentInfoDto>>> GetStudentProfileByCourseId(int courseId)
    {
        GetStudentByCourseId.Response response = await _mediator.Send(new GetStudentByCourseId.Query(courseId));
        return Ok(response.Students);
    }

    // TODO: To fix GroupSubjects list cause it's null and method doesn't work properly
    [HttpGet(nameof(GetStudentProfilesBySubjectId))]
    public async Task<ActionResult<IReadOnlyCollection<StudentInfoDto>>> GetStudentProfilesBySubjectId(int subjectId)
    {
        GetStudentProfilesBySubjectId.Response response
            = await _mediator.Send(new GetStudentProfilesBySubjectId.Query(subjectId));

        return Ok(response.Students);
    }
}