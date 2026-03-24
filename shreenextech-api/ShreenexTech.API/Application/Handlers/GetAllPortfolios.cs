using MediatR;
using ShreenexTech.API.Application.Features.Portfolios.Query;
using ShreenexTech.API.Application.Interfaces;
using ShreenexTech.API.Domain.Entities;

namespace ShreenexTech.API.Application.Handlers
{
    public class GetAllPortfolioHandler : IRequestHandler<GetAllPortfolios, List<Portfolio>>
    {
        private readonly IRepository<Portfolio> _repository;

        public GetAllPortfolioHandler(IRepository<Portfolio> repository)
        {
            _repository = repository;
        }

        public async Task<List<Portfolio>> Handle(GetAllPortfolios request, CancellationToken cancellationToken)
        {
            var portfolios = await _repository.GetAllAsync();
            return portfolios;
        }
    }
}
