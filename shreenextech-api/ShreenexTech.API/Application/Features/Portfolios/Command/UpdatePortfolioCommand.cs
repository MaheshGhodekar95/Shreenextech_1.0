using MediatR;
namespace ShreenexTech.API.Application.Features.Portfolios.Command
{
    public class UpdatePortfolioCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? ClientName { get; set; }
        public string? ProjectUrl { get; set; }
        public string? Technologies { get; set; }
    }

}

