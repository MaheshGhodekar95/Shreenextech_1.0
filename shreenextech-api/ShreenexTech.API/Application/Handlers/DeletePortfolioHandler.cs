using Azure.Core;
using MediatR;
using ShreenexTech.API.Application.Common.Exceptions;
using ShreenexTech.API.Application.Features.Portfolios.Command;
using ShreenexTech.API.Application.Interfaces;
using ShreenexTech.API.Domain.Entities;
using ShreenexTech.API.Infrastructure.Data;

namespace ShreenexTech.API.Application.Handlers
{
    public class DeletePortfolioHandler : IRequestHandler<DeletePortfolioCommand, bool>
    {
        private readonly IRepository<Portfolio> _repository;
        private readonly AppDbContext _context;
        private readonly ILogger<DeletePortfolioHandler> _logger;

        public DeletePortfolioHandler(IRepository<Portfolio> repository, AppDbContext context, ILogger<DeletePortfolioHandler> logger)
        {
            _repository = repository;
            _context = context;
            _logger = logger;
        }

        public async Task<bool> Handle(DeletePortfolioCommand deletePortfolio, CancellationToken cancellationToken)
        {
            if (deletePortfolio.Id != Guid.Empty && deletePortfolio.Id != null)
            {
                _logger.LogWarning("ID is Empty or Null.");
                throw new BadRequestException("Id is Required.");
            }
            else
            {
                _logger.LogInformation("Record deleting started with ID : {Id}.", deletePortfolio.Id);
                await _repository.DeleteAsync(deletePortfolio.Id);
                var result = await _context.SaveChangesAsync();
                _logger.LogInformation("Record deleted Successfully with ID : {Id}.", deletePortfolio.Id);
                return true;
            }
        }
    }
}
