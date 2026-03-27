using MediatR;
using ShreenexTech.API.Application.Common.DTO_s;
using ShreenexTech.API.Application.Common.Exceptions;
using ShreenexTech.API.Application.Features.Portfolios.Query;
using ShreenexTech.API.Application.Features.Services.Query;
using ShreenexTech.API.Application.Interfaces;
using ShreenexTech.API.Domain.Entities;
using ShreenexTech.API.Infrastructure.Data;

namespace ShreenexTech.API.Application.Handlers
{
    public class GetServiceByIdHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdDto>
    {
        private readonly IRepository<Service> _repository;
        private readonly AppDbContext _context;
        ILogger<GetServiceByIdHandler> _logger;
        public GetServiceByIdHandler(IRepository<Service> repository, AppDbContext context, ILogger<GetServiceByIdHandler> logger)
        {
            _repository = repository;
            _context = context;
            _logger = logger;
        }

        public async Task<GetServiceByIdDto> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                _logger.LogWarning("Required Id is Empty or Null...");
                throw new BadRequestException("Required parameters should not empty...");
            }
            else
            {
                _logger.LogInformation("Fetching record started for : {Id}", request.Id);
                var result = await _repository.GetByIdAsync(request.Id);
                if (result == null)
                {
                    throw new NotFoundException("Service Not Found.", request.Id);
                }
                else
                {
                    var service = new GetServiceByIdDto()
                    {
                        Id = result.Id,
                        Icon= result.Icon,
                        Title = result.Title,
                        IsActive = result.IsActive,
                        Description = result.Description,
                        CreatedDate = result.CreatedDate,
                    };
                    _logger.LogInformation("Record fetched for Id :{Id}", request.Id);
                    return service;
                }
            }

        }
    }
}
