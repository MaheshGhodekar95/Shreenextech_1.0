using MediatR;
using ShreenexTech.API.Application.Common.DTO_s;
using ShreenexTech.API.Application.Common.Exceptions;
using ShreenexTech.API.Application.Features.Portfolios.Query;
using ShreenexTech.API.Application.Interfaces;
using ShreenexTech.API.Domain.Entities;
using ShreenexTech.API.Infrastructure.Data;

namespace ShreenexTech.API.Application.Handlers
{
    public class GetPortfolioByIdHandler : IRequestHandler<GetPortfolioByIdQuery, GetPortfolioByIdDto>
    {
        private readonly IRepository<Portfolio> _repository;
        private readonly AppDbContext _context;
        ILogger<GetPortfolioByIdHandler> _logger;
        public GetPortfolioByIdHandler(IRepository<Portfolio> repository, AppDbContext context, ILogger<GetPortfolioByIdHandler> logger) 
        {
            _repository = repository;
            _context = context;
            _logger = logger;
        }

        public async Task<GetPortfolioByIdDto> Handle(GetPortfolioByIdQuery request, CancellationToken cancellationToken)
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
                    throw new NotFoundException("Portfolio", request.Id);
                }
                else
                {
                   var portfolio= new GetPortfolioByIdDto()
                    {
                        Id = result.Id,
                        Technologies = result.Technologies,
                        Title = result.Title,
                        ImageUrl = result.ImageUrl,
                        ProjectUrl = result.ProjectUrl,
                        ClientName = result.ClientName,
                        Description = result.Description,
                        CreatedDate = result.CreatedDate,
                    };
                    _logger.LogInformation("Record fetched for Id :{Id}", request.Id);
                    return portfolio;
                }
            }
              
        }
    }
}
