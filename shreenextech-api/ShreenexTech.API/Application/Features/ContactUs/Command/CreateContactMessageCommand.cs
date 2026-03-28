using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ShreenexTech.API.Application.Features.ContactUs.Command
{
    public class CreateContactMessageCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
    }
}
