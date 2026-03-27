using MediatR;
using ShreenexTech.API.Application.Common.DTO_s;
using ShreenexTech.API.Application.Common.Exceptions;
using ShreenexTech.API.Application.Features.Portfolios.Query;
using ShreenexTech.API.Application.Interfaces;
using ShreenexTech.API.Domain.Entities;

namespace ShreenexTech.API.Application.Handlers
{
    public class GetAllPortfolioHandler : IRequestHandler<GetAllPortfoliosQuery, GetAllPortfolioDto>
    {
        private readonly IRepository<Portfolio> _repository;
        private readonly ILogger<GetAllPortfolioHandler> _logger;

        public GetAllPortfolioHandler(IRepository<Portfolio> repository, ILogger<GetAllPortfolioHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<GetAllPortfolioDto> Handle(GetAllPortfoliosQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching all portfolio records started....");

            List<Portfolio>? portfolios = await _repository.GetAllAsync();

            _logger.LogInformation("Total portfolio records fetched and Count : {Count}", portfolios.Count);
            GetAllPortfolioDto? result = new GetAllPortfolioDto();
            if (portfolios.Any())
            {
                foreach (var portfolio in portfolios)
                {
                    result.Portfolios.Add(portfolio);
                }
            }
            return result;
        }
    }
}
