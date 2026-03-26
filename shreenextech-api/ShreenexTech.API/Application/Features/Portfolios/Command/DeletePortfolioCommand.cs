using MediatR;

namespace ShreenexTech.API.Application.Features.Portfolios.Command
{
    public class DeletePortfolioCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
