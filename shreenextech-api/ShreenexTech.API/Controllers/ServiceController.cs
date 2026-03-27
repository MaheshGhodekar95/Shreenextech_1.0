using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShreenexTech.API.Application.Features.Portfolios.Query;
using ShreenexTech.API.Application.Features.Services.Command;
using ShreenexTech.API.Application.Features.Services.Query;

namespace ShreenexTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ServiceController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateService([FromBody] CreateServiceCommand command)
        {
            var result = await _mediator.Send(command);
            return Created("Service Created Successfully.", result);
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePortfolio([FromBody] UpdateServiceCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == Guid.Empty)
                return NotFound("Service not found");

            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteService([FromQuery] DeleteServiceCommand command)
        {
            bool result = await _mediator.Send(command);
            if (!result)
                return NotFound("Service not found");

            return Ok("Service deleted successfully");
        }

        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetServiceById([FromQuery] GetServiceByIdQuery query)
        {
            var result = await _mediator.Send(query);
            if (result is null)
                return NotFound("Service not found");

            return Ok(result);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllServices()
        {
            var result = await _mediator.Send(new GetAllServicesQuery());
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
