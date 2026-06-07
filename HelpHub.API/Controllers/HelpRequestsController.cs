using HelpHub.Application.Features.HelpRequests.Commands;
using HelpHub.Application.Features.HelpRequests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HelpHub.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelpRequestsController : ControllerBase
{
    private readonly IMediator _mediator;

    public HelpRequestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllHelpRequestsQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateHelpRequestCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetHelpRequestByIdQuery(id));

        if (result == null)
            return NotFound("Help request not found.");

        return Ok(result);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _mediator.Send(new DeleteHelpRequestCommand(id));

        if (!deleted)
            return NotFound("Help request not found.");

        return NoContent();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateHelpRequestCommand command)
    {
        if (id != command.Id)
            return BadRequest("Id in URL does not match Id in body.");

        var updated = await _mediator.Send(command);

        if (!updated)
            return NotFound("Help request not found.");

        return NoContent();
    }
}