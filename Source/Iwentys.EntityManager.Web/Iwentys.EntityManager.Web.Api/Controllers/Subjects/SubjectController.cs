using Iwentys.EntityManager.WebApiDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Iwentys.EntityManager.WebApi;

[Route("api/[controller]")]
[ApiController]
public class SubjectController : ControllerBase
{
    private readonly IMediator _mediator;

    public SubjectController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(nameof(Get))]
    public async Task<ActionResult<IReadOnlyCollection<SubjectProfileDto>>> Get()
    {
        var response = await _mediator.Send(new GetSubjects.Query());
        return Ok(response.Subjects);
    }

    [HttpGet(nameof(GetSubjectById))]
    public async Task<ActionResult<SubjectProfileDto>> GetSubjectById(int subjectId)
    {
        GetSubjectById.Response response = await _mediator.Send(new GetSubjectById.Query(subjectId));
        var result = response?.Subject;

        return result is not null ? Ok(result) : NotFound();
    }

    [HttpGet(nameof(GetSubjectsByStudentId))]
    public async Task<ActionResult<IReadOnlyCollection<SubjectProfileDto>>> GetSubjectsByStudentId(int studentId)
    {
        GetSubjectsByStudentId.Response response = await _mediator.Send(new GetSubjectsByStudentId.Query(studentId));
        return Ok(response.Subjects);
    }

    [HttpGet(nameof(GetSubjectsByGroupId))]
    public async Task<ActionResult<IReadOnlyCollection<SubjectProfileDto>>> GetSubjectsByGroupId(Guid groupId)
    {
        GetSubjectsByGroupId.Response response = await _mediator.Send(new GetSubjectsByGroupId.Query(groupId));
        return Ok(response.Subjects);
    }

    [HttpGet(nameof(GetSubjectsByCourseId))]
    public async Task<ActionResult<IReadOnlyCollection<SubjectProfileDto>>> GetSubjectsByCourseId(Guid courseId)
    {
        GetSubjectsByCourseId.Response response = await _mediator.Send(new GetSubjectsByCourseId.Query(courseId));
        return Ok(response.Subjects);
    }

    [HttpGet(nameof(GetSubjectsBySemester))]
    public async Task<ActionResult<IReadOnlyCollection<SubjectProfileDto>>> GetSubjectsBySemester(string semester)
    {
        GetSubjectsBySemester.Response response = await _mediator.Send(new GetSubjectsBySemester.Query(semester));
        return Ok(response.Subjects);
    }
}