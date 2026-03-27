using MediatR;

namespace ShreenexTech.API.Application.Features.Services.Command
{
    public class UpdateServiceCommand : IRequest<Guid>
    { 
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsActive { get; set; }

    }
}
