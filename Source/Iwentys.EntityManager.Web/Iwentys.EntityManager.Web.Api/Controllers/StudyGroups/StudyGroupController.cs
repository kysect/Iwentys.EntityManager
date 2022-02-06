using Iwentys.EntityManager.WebApiDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Iwentys.EntityManager.WebApi;

[Route("api/study-group")]
[ApiController]
public class StudyGroupController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudyGroupController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(nameof(Get))]
    public async Task<ActionResult<IReadOnlyCollection<StudyGroupProfileResponseDto>>> Get()
    {
        GetStudyGroups.Response response = await _mediator.Send(new GetStudyGroups.Query());
        return Ok(response.StudyGroups);
    }

    [HttpGet(nameof(GetStudyGroupByGroupName))]
    public async Task<ActionResult<StudyGroupProfileResponseDto>> GetStudyGroupByGroupName(string groupName)
    {
        GetStudyGroupByGroupName.Response response = await _mediator.Send(new GetStudyGroupByGroupName.Query(groupName));
        var result = response?.StudyGroup;

        return result is not null ? Ok(result) : NotFound();
    }

    [HttpGet(nameof(GetStudyGroupByStudentId))]
    public async Task<ActionResult<StudyGroupProfileResponseDto>> GetStudyGroupByStudentId(int studentId)
    {
        GetStudyGroupByStudentId.Response response = await _mediator.Send(new GetStudyGroupByStudentId.Query(studentId));
        var result = response?.StudyGroup;

        return result is not null ? Ok(result) : NotFound();
    }

    [HttpGet(nameof(GetStudyGroupById))]
    public async Task<ActionResult<StudyGroupProfileResponseDto>> GetStudyGroupById(int groupId)
    {
        GetStudyGroupById.Response response = await _mediator.Send(new GetStudyGroupById.Query(groupId));
        var result = response?.StudyGroup;

        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost(nameof(GetStudyGroupsByIdList))]
    public async Task<ActionResult<IReadOnlyCollection<StudyGroupProfileResponseDto>>> GetStudyGroupsByIdList(
        List<int> groupIdList)
    {
        GetStudyGroupsByIdList.Response response = await _mediator.Send(new GetStudyGroupsByIdList.Query(groupIdList));
        return Ok(response.StudyGroups);
    }

    [HttpGet(nameof(GetStudyGroupsByCourseId))]
    public async Task<ActionResult<IReadOnlyCollection<StudyGroupProfileResponseDto>>> GetStudyGroupsByCourseId(Guid courseId)
    {
        GetStudyGroupsByCourseId.Response response = await _mediator.Send(new GetStudyGroupsByCourseId.Query(courseId));
        return Ok(response.StudyGroups);
    }
}