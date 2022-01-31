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
    public async Task<ActionResult<StudyGroupProfileResponseDto>> Get()
    {
        GetStudyGroups.Response response = await _mediator.Send(new GetStudyGroups.Query());
        return Ok(response.Groups);
    }

    [HttpGet(nameof(GetStudyGroupById))]
    public async Task<ActionResult<StudyGroupProfileResponseDto>> GetStudyGroupById(int groupId)
    {
        GetStudyGroupById.Response response = await _mediator.Send(new GetStudyGroupById.Query(groupId));
        return Ok(response.StudyGroup);
    }

    [HttpPost(nameof(GetStudyGroupsByIdList))]
    public async Task<ActionResult<StudyGroupProfileResponseDto>> GetStudyGroupsByIdList([FromBody] List<int> groupIdList)
    {
        GetStudyGroupsByIdList.Response response = await _mediator.Send(new GetStudyGroupsByIdList.Query(groupIdList.ToList()));
        return Ok(response.StudyGroups);
    }

    [HttpGet(nameof(GetStudyGroupsByCourseId))]
    public async Task<ActionResult<List<StudyGroupProfileResponseDto>>> GetStudyGroupsByCourseId([FromQuery] int? courseId)
    {
        GetStudyGroupByCourseId.Response response = await _mediator.Send(new GetStudyGroupByCourseId.Query(courseId));
        return Ok(response.Groups);
    }

    [HttpGet(nameof(GetStudyGroupByGroupName))]
    public async Task<ActionResult<StudyGroupProfileResponseDto>> GetStudyGroupByGroupName(string groupName)
    {
        GetStudyGroupByName.Response response = await _mediator.Send(new GetStudyGroupByName.Query(groupName));
        return Ok(response.StudyGroup);
    }

    [HttpGet(nameof(GetStudyGroupByStudentId))]
    public async Task<ActionResult<StudyGroupProfileResponseDto>> GetStudyGroupByStudentId(int studentId)
    {
        GetStudyGroupByStudent.Response response = await _mediator.Send(new GetStudyGroupByStudent.Query(studentId));
        StudyGroupProfileResponseDto result = response.StudyGroup;

        if (result is null) return NotFound();

        return Ok(result);
    }
}