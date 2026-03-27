using MediatR;

namespace ShreenexTech.API.Application.Features.Services.Command
{
    public class DeleteServiceCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
