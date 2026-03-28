using MediatR;

namespace ShreenexTech.API.Application.Features.Services.Command
{
    public class CreateServiceCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Icon {  get; set; }
        public bool IsActive { get; set; }
        public string Technologies { get; set; }
        public string OurOffers { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
