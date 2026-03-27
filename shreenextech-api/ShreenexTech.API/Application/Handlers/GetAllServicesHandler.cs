using MediatR;
using ShreenexTech.API.Application.Common.DTO_s;
using ShreenexTech.API.Application.Features.Portfolios.Query;
using ShreenexTech.API.Application.Features.Services.Query;
using ShreenexTech.API.Application.Interfaces;
using ShreenexTech.API.Domain.Entities;
using ShreenexTech.API.Infrastructure.Data;

namespace ShreenexTech.API.Application.Handlers
{
    public class GetAllServicesHandler : IRequestHandler<GetAllServicesQuery, GetAllServicesDto>
    {
        private readonly IRepository<Service> _repository;
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<GetAllServicesHandler> _logger;
        public GetAllServicesHandler( IRepository<Service> repository, AppDbContext appDbContext, ILogger<GetAllServicesHandler> looger) 
        {
            _repository = repository;
            _appDbContext = appDbContext;
            _logger = looger;
        }

        public async Task<GetAllServicesDto> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching all portfolio records started....");

            List<Service>? services = await _repository.GetAllAsync();

            _logger.LogInformation("Total portfolio records fetched and Count : {Count}", services.Count);
            GetAllServicesDto? result = new GetAllServicesDto();
            if (services.Any())
            {
                foreach (var service in services)
                {
                    result.services.Add(service);
                }
            }
            return result;
        }
    }
}
