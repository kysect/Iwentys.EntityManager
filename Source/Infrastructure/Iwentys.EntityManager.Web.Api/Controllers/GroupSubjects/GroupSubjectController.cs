﻿using Iwentys.EntityManager.Application;
using Iwentys.EntityManager.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Iwentys.EntityManager.WebApi;

[Route("api/group-subject")]
[ApiController]
public class GroupSubjectController : ControllerBase
{
    private readonly IMediator _mediator;

    public GroupSubjectController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(nameof(GetGroupSubjectByTeacherId))]
    public async Task<ActionResult<List<GroupSubjectDto>>> GetGroupSubjectByTeacherId(int teacherId)
    {
        GetGroupSubjectByTeacherId.Response response = await _mediator.Send(new GetGroupSubjectByTeacherId.Query(teacherId));
        return Ok(response.Groups);
    }
}