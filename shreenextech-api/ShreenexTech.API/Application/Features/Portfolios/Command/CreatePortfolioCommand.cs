using MediatR;

namespace ShreenexTech.API.Application.Features.Portfolios.Command
{
    public class CreatePortfolioCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public string ClientName { get; set; }
        public string? ProjectUrl { get; set; }
        public string Technologies { get; set; }
    }
}
