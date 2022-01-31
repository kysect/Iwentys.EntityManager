using Iwentys.EntityManager.PublicTypes;
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
    public async Task<ActionResult<List<SubjectProfileDto>>> Get()
    {
        var response = await _mediator.Send(new GetSubjects.Query());
        return Ok(response.Subjects);
    }

    [HttpGet(nameof(SearchSubjects))]
    public async Task<ActionResult<List<SubjectProfileDto>>> SearchSubjects(int? courseId, StudySemester? semester, int? skip, int? take)
    {
        var studySearchParameters = new SubjectSearchParametersDto(null, null, null, courseId, semester, skip, take);
        SearchSubjects.Response response = await _mediator.Send(new SearchSubjects.Query(studySearchParameters));

        return Ok(response.Subjects);
    }

    [HttpGet(nameof(GetSubjectByStudentId))]
    public async Task<ActionResult<List<SubjectProfileDto>>> GetSubjectByStudentId(int studentId)
    {
        GetSubjectsByStudentId.Response response = await _mediator.Send(new GetSubjectsByStudentId.Query(studentId));
        return Ok(response.Subjects);
    }

    [HttpGet(nameof(GetSubjectById))]
    public async Task<ActionResult<SubjectProfileDto>> GetSubjectById(int subjectId)
    {
        GetSubjectById.Response response = await _mediator.Send(new GetSubjectById.Query(subjectId));
        return Ok(response.Subject);
    }

    [HttpGet(nameof(GetSubjectsByGroupId))]
    public async Task<ActionResult<List<SubjectProfileDto>>> GetSubjectsByGroupId(int groupId)
    {
        GetSubjectsByGroupId.Response response = await _mediator.Send(new GetSubjectsByGroupId.Query(groupId));
        return Ok(response.Subjects);
    }
}