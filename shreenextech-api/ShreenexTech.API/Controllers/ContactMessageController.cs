using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ShreenexTech.API.Application.Features.Portfolios.Command;
using ShreenexTech.API.Application.Features.Portfolios.Query;
using Microsoft.AspNetCore.Http;
using ShreenexTech.API.Application.Features.ContactUs.Command;
using ShreenexTech.API.Application.Features.ContactUs.Query;

namespace ShreenexTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactMessageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactMessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateContactMessage([FromBody] CreateContactMessageCommand command)
        {
            var result = await _mediator.Send(command);
            return Created("Contact Message Saved Successfully.", result);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllContactMessages()
        {
            var result = await _mediator.Send(new GetAllContactMessagesQuery());
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
