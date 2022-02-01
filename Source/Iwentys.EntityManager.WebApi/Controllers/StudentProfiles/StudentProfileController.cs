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

        if (response is null) return NotFound();
        
        return Ok(response.Student);
    }

    [HttpPost(nameof(GetStudentsByIdList))]
    public async Task<ActionResult<IReadOnlyCollection<StudyGroupProfileResponseDto>>> GetStudentsByIdList(
        List<int> studentIdList)
    {
        GetStudentsByIdList.Response response = await _mediator.Send(new GetStudentsByIdList.Query(studentIdList));
        return Ok(response.Students);
    }

    [HttpGet(nameof(GetStudentProfileByGithubUsername))]
    public async Task<ActionResult<StudentInfoDto>> GetStudentProfileByGithubUsername(string githubUsername)
    {
        GetStudentByGithubUsername.Response response
            = await _mediator.Send(new GetStudentByGithubUsername.Query(githubUsername));

        if (response is null) return NotFound();

        return Ok(response.Student);
    }

    [HttpPost(nameof(GetStudentProfilesByGithubUsernamesList))]
    public async Task<ActionResult<IReadOnlyCollection<StudentInfoDto>>> GetStudentProfilesByGithubUsernamesList(
        List<string> githubUsernamesList)
    {
        GetStudentByGithubUsernamesList.Response response
            = await _mediator.Send(new GetStudentByGithubUsernamesList.Query(githubUsernamesList));

        return Ok(response.Students);
    }

    [HttpGet(nameof(GetStudentProfilesByGroupId))]
    public async Task<ActionResult<IReadOnlyCollection<StudentInfoDto>>> GetStudentProfilesByGroupId(int groupId)
    {
        GetStudentByGroupId.Response response = await _mediator.Send(new GetStudentByGroupId.Query(groupId));
        return Ok(response.Students);
    }

    [HttpGet(nameof(GetStudentProfilesByCourseId))]
    public async Task<ActionResult<IReadOnlyCollection<StudentInfoDto>>> GetStudentProfilesByCourseId(int courseId)
    {
        GetStudentByCourseId.Response response = await _mediator.Send(new GetStudentByCourseId.Query(courseId));
        return Ok(response.Students);
    }

    // TODO: To fix GroupSubjects list cause it's null and method doesn't work properly
    [HttpGet(nameof(GetStudentsBySubjectId))]
    public async Task<ActionResult<IReadOnlyCollection<StudentInfoDto>>> GetStudentsBySubjectId(int subjectId)
    {
        GetStudentsBySubjectId.Response response
            = await _mediator.Send(new GetStudentsBySubjectId.Query(subjectId));

        return Ok(response.Students);
    }
}