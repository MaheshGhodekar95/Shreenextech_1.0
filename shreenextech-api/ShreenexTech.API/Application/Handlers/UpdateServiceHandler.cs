using MediatR;
using Microsoft.EntityFrameworkCore;
using ShreenexTech.API.Application.Common.Exceptions;
using ShreenexTech.API.Application.Features.Services.Command;
using ShreenexTech.API.Application.Interfaces;
using ShreenexTech.API.Domain.Entities;
using ShreenexTech.API.Infrastructure.Data;

namespace ShreenexTech.API.Application.Handlers
{
    public class UpdateServiceHandler : IRequestHandler<UpdateServiceCommand, Guid>
    {
        private readonly IRepository<Service> _repository;
        private readonly ILogger<UpdateServiceHandler> _logger;
        private readonly AppDbContext _context;
        public UpdateServiceHandler( IRepository<Service> repository, AppDbContext context, ILogger<UpdateServiceHandler> logger) 
        { 
           _logger = logger;
           _repository = repository;
            _context = context;
        }

        public async Task<Guid> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            if(request is null || request.Id == Guid.Empty)
            {
                _logger.LogInformation("Request/ Id is Null : {request}", request);
                throw new BadRequestException("Required parameters should not empty...");
            }
            else
            {
                _logger.LogInformation("Updating record started for : {Id}", request.Id);
                var result = await _context.Services.AsNoTracking().FirstOrDefaultAsync(p => p.Id == request.Id);

                if (result is null)
                {
                    _logger.LogInformation("Record with Id : {Id} not found.", request.Id);
                    throw new NotFoundException("Service not found.", request.Id);
                }
                else
                {

                    var service = new Service
                    {
                        Id = result.Id != Guid.Empty ? result.Id : Guid.Empty,
                        Title = request.Title != String.Empty && request.Title is not null ? request.Title : result.Title,
                        Description = request.Description != String.Empty && request.Description is not null ? request.Description : result.Description,
                        Icon = request.Icon != String.Empty && request.Icon is not null ? request.Icon : result.Icon,
                        IsActive = request.IsActive ,
                        CreatedDate = result.CreatedDate != DateTime.MinValue ? result.CreatedDate : DateTime.UtcNow,
                        OurOffers = request.OurOffers != String.Empty && request.OurOffers is not null ? request.OurOffers : result.OurOffers,
                        Technologies = request.Technologies != String.Empty && request.Technologies is not null ? request.Technologies : result.Technologies
                    };

                    await _repository.UpdateAsync(service);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Record updated successfully fo ID : {Id}.", service.Id);
                    return service.Id;
                }
            }
        }
    }
}
