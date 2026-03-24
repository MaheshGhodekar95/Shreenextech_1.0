using MediatR;
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
    public async Task<IActionResult> Create([FromBody] CreatePortfolio command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllPortfolios());
        return Ok(result);
    }
}