using MediatR;
using ShreenexTech.API.Application.Interfaces;
using ShreenexTech.API.Domain.Entities;
using ShreenexTech.API.Infrastructure.Data;
using ShreenexTech.API.Application.Features.Portfolios.Command;
using ShreenexTech.API.Application.Common.Exceptions;

namespace ShreenexTech.API.Application.Handlers
{   
    public class CreatePortfolioHandler : IRequestHandler<CreatePortfolioCommand, Guid>
    {
        private readonly IRepository<Portfolio> _repository;
        private readonly AppDbContext _context;
        private readonly ILogger<CreatePortfolioHandler> _logger;


        public CreatePortfolioHandler(IRepository<Portfolio> repository, AppDbContext context, ILogger<CreatePortfolioHandler> logger)
        {
            _repository = repository;
            _context = context;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreatePortfolioCommand request, CancellationToken cancellationToken)
        {
            if (request.Title == string.Empty || request.Description == string.Empty || request.ClientName == string.Empty || request.Technologies == string.Empty)
            {
                _logger.LogWarning("Required fields are Empty or Null...");
                throw new BadRequestException("Required parameters should not empty...");
            }
            else
            {
                _logger.LogInformation("Inserting record started for : {request}",request);
                var portfolio = new Portfolio
                {
                    Id = Guid.NewGuid(),
                    Title = request.Title,
                    Description = request.Description,
                    ImageUrl = request.ImageUrl,
                    ProjectUrl = request.ProjectUrl,
                    ClientName = request.ClientName,
                    Technologies = request.Technologies,
                    CreatedDate = DateTime.Now
                };

                await _repository.AddAsync(portfolio);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Record inserted Successfully with ID : {Id}.", portfolio.Id);
                return portfolio.Id;
            }
        }
    }
}
