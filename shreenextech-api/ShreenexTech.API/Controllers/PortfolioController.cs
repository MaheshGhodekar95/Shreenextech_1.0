using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ShreenexTech.API.Application.Features.Portfolios.Command;
using ShreenexTech.API.Application.Features.Portfolios.Query;

[Route("api/[controller]")]
[ApiController]
public class PortfolioController : ControllerBase
{
    private readonly IMediator _mediator;

    public PortfolioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("Create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreatePortfolio([FromBody] CreatePortfolioCommand command)
    {
        var result = await _mediator.Send(command);
        return Created("Portfolio Created Successfully.", result);
    }

    [HttpPut]
    [Route("Update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdatePortfolio([FromBody] UpdatePortfolioCommand command)
    {
        var result = await _mediator.Send(command);
        if (result == Guid.Empty )
            return NotFound("Portfolio not found");

        return Ok(result);
    }

    [HttpDelete]
    [Route("Delete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeletePortfolio([FromBody] DeletePortfolioCommand command)
    {
        bool result = await _mediator.Send(command);
        if (!result)
            return NotFound("Portfolio not found");

        return Ok("Portfolio deleted successfully");
    }

    [HttpGet]
    [Route("GetAll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllPortfolio()
    {
        var result = await _mediator.Send(new GetAllPortfoliosQuery());
        if (result == null || !result.Any())
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpGet]
    [Route("GetById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPortfolioById([FromQuery] GetPortfolioByIdQuery query)
    {
        var result = await _mediator.Send(query);
        if (result is null)
           return NotFound("Portfolio not found");

        return Ok(result);
    }
}