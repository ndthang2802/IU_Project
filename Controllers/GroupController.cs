using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjectBE.Models;
using MediatR;
using Project.UseCases.Groups;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace ProjectBE.Controllers;
[Route("api/group")]
public class GroupController : Controller
{
    private readonly ILogger<GroupController> _logger;
    private readonly IMediator _mediator;
    public GroupController(ILogger<GroupController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }
    [HttpPost("add")]
    [AuthorizeAttribute]
    [DecryptedAttribute] // Chỉ sử dụng attribute này cho những route cần Encrypt request!!
    public async Task<IActionResult> AddGroup([FromBody] AddGroupCommand command, [FromServices] IMediator mediator)
    {
        var result = await mediator.Send(command);
        return StatusCode((int)result.STATUSCODE, result);
    }
    [HttpPost("query")]
    public async Task<IActionResult> GetListGroup([FromBody] GetGroupCommand command, [FromServices] IMediator mediator)
    {
        var result = await mediator.Send(command);
        return StatusCode((int)result.STATUSCODE, result);
    }
    [HttpPost("update")]
    [AuthorizeAttribute]
    public async Task<IActionResult> UpdateGroup([FromBody] UpdateGroupCommand command, [FromServices] IMediator mediator)
    {
        var result = await mediator.Send(command);
        return StatusCode((int)result.STATUSCODE, result);
    }
}
