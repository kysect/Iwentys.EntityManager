﻿using Iwentys.EntityManager.Application;
using Iwentys.EntityManager.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Iwentys.EntityManager.Web.Controllers;

[Route("api/study-courses")]
[ApiController]
public class StudyCourseController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudyCourseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<StudyCourseDto>>> Get()
    {
        GetStudyCourses.Response response = await _mediator.Send(new GetStudyCourses.Query());
        return Ok(response.Courses);
    }
}