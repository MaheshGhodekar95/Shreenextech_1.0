using MediatR;
using Microsoft.EntityFrameworkCore;
using ShreenexTech.API.Application.Common.Exceptions;
using ShreenexTech.API.Application.Features.Services.Command;
using ShreenexTech.API.Application.Interfaces;
using ShreenexTech.API.Domain.Entities;
using ShreenexTech.API.Infrastructure.Data;

namespace ShreenexTech.API.Application.Handlers
{
    public class DeleteServiceHandler : IRequestHandler<DeleteServiceCommand, bool>
    {
        private readonly IRepository<Service> _repository;
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<DeleteServiceHandler> _logger;
        public DeleteServiceHandler(IRepository<Service> repository, AppDbContext appDbContext, ILogger<DeleteServiceHandler> logger)
        {
            _appDbContext = appDbContext;
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            if (request == null || request.Id == Guid.Empty)
            {
                _logger.LogWarning("ID is Empty or Null.");
                throw new BadRequestException("Id is Required.");
            }
            else
            {
                _logger.LogInformation("Record deleting started with ID : {Id}.", request.Id);
                await _repository.DeleteAsync(request.Id);
                await _appDbContext.SaveChangesAsync();
                _logger.LogInformation("Record deleted Successfully with ID : {Id}.", request.Id);
                return true;
            }
        }
    }
}
