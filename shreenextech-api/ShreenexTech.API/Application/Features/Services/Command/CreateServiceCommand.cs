using MediatR;

namespace ShreenexTech.API.Application.Features.Services.Command
{
    public class CreateServiceCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Icon {  get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
