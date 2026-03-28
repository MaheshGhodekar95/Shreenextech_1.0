using MediatR;
using ShreenexTech.API.Application.Interfaces;
using ShreenexTech.API.Domain.Entities;
using ShreenexTech.API.Infrastructure.Data;
using ShreenexTech.API.Application.Features.Services.Command;
using ShreenexTech.API.Application.Common.Exceptions;

namespace ShreenexTech.API.Application.Handlers
{
    public class CreateServiceHandler : IRequestHandler<CreateServiceCommand,Guid>
    {
        private readonly IRepository<Service> _repository;
        private readonly AppDbContext _context;
        private readonly ILogger<CreateServiceHandler> _logger;

        public CreateServiceHandler(IRepository<Service> repository, AppDbContext context, ILogger<CreateServiceHandler> logger)
        {
            _repository = repository;
            _context = context;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            if (request is null || request.Title == string.Empty)
            {
                _logger.LogInformation("Required parameters are not provided.: {request}", request);
                throw new BadRequestException("Required params are missing...");
            }
            else
            {
                _logger.LogInformation("Inserting record started...");
                Service service = new Service()
                {
                    Id = Guid.NewGuid(),
                    Title = request.Title,
                    Icon = request.Icon == null ? string.Empty : request.Icon,
                    Description = request.Description == null ? string.Empty : request.Description,
                    IsActive = request.IsActive,
                    OurOffers = request.OurOffers,
                    Technologies = request.Technologies,
                    CreatedDate = DateTime.UtcNow,
                };

                await _repository.AddAsync(service);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Service with ID : {service.Id} inserted.");
                return service.Id;
            }
        }
    }
}
