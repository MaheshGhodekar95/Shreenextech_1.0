using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShreenexTech.API.Application.Features.Services.Command;
using ShreenexTech.API.Application.Features.Services.Query;
using ShreenexTech.API.Application.Features.Testimonial.Command;
using ShreenexTech.API.Application.Features.Testimonial.Query;

namespace ShreenexTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TestimonialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateTestimonial([FromBody] CreateTestimonialCommand command)
        {
            var result = await _mediator.Send(command);
            return Created("Testimonial Created Successfully.", result);
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTestimonial([FromBody] UpdateTestimonialCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == Guid.Empty)
                return NotFound("Testimonial not found");

            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTestimonial([FromQuery] DeleteTestimonialCommand command)
        {
            bool result = await _mediator.Send(command);
            if (!result)
                return NotFound("Testimonial not found");

            return Ok("Testimonial deleted successfully");
        }

        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTestimonialById([FromQuery] GetTestimonialByIdQuery query)
        {
            var result = await _mediator.Send(query);
            if (result is null)
                return NotFound("Testimonial not found");

            return Ok(result);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllTestimonials()
        {
            var result = await _mediator.Send(new GetAllTestimonialQuery());
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
