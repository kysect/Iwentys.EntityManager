using Iwentys.EntityManager.Application;
using Iwentys.EntityManager.WebApiDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Iwentys.EntityManager.WebApi;

[Route("api/iwentys-user-profile")]
[ApiController]
public class IwentysUserProfileController : ControllerBase
{
    private readonly IMediator _mediator;

    public IwentysUserProfileController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(nameof(Get))]
    public async Task<ActionResult<List<IwentysUserDto>>> Get()
    {
        GetIwentysUsers.Response response = await _mediator.Send(new GetIwentysUsers.Query());
        return Ok(response.Users);
    }

    [HttpGet(nameof(GetById))]
    public async Task<ActionResult<IwentysUserDto>> GetById(int id)
    {
        GetIwentysUserById.Response response = await _mediator.Send(new GetIwentysUserById.Query(id));
        var result = response.User;

        return result is not null ? Ok(result) : NotFound();
    }
}