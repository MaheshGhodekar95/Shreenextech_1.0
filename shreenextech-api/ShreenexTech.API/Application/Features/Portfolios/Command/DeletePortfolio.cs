using MediatR;

namespace ShreenexTech.API.Application.Features.Portfolios.Command
{
    public class DeletePortfolio : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
