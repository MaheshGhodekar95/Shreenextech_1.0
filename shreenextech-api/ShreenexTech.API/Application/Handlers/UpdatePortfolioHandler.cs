using MediatR;
using Microsoft.EntityFrameworkCore;
using ShreenexTech.API.Application.Common.Exceptions;
using ShreenexTech.API.Application.Features.Portfolios.Command;
using ShreenexTech.API.Application.Interfaces;
using ShreenexTech.API.Domain.Entities;
using ShreenexTech.API.Infrastructure.Data;

namespace ShreenexTech.API.Application.Handlers
{
   public class UpdatePortfolioHandler : IRequestHandler<UpdatePortfolioCommand, Guid>
   {
    private readonly IRepository<Portfolio> _repository;
    private readonly AppDbContext _context;
    private readonly ILogger<UpdatePortfolioHandler> _logger;


    public UpdatePortfolioHandler(IRepository<Portfolio> repository, AppDbContext context, ILogger<UpdatePortfolioHandler> logger)
    {
        _repository = repository;
        _context = context;
        _logger = logger;
    }

    public async Task<Guid> Handle(UpdatePortfolioCommand request, CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty || request.Title == string.Empty)
        {
            _logger.LogWarning("Required fields are Empty or Null...");
            throw new BadRequestException("Required parameters should not empty...");
        }
        else
        {
            _logger.LogInformation("Updating record started for : {Id}", request.Id);
              var result = await _context.Portfolio.AsNoTracking().FirstOrDefaultAsync(p => p.Id == request.Id);

                if (result is null)
                {
                    _logger.LogInformation("Record with Id : {Id} not found.", request.Id);
                    throw new NotFoundException("Portfolio not found",request.Id);
                }
                else
                {

                    var portfolio = new Portfolio
                    {
                        Id = result.Id != Guid.Empty ? result.Id : Guid.Empty,
                        Title = request.Title != String.Empty && request.Title is not null ? request.Title : result.Title,
                        Description = request.Description != String.Empty && request.Description is not null ? request.Description : result.Description,
                        ImageUrl = request.ImageUrl != String.Empty ? request.ImageUrl : result.ImageUrl,
                        ProjectUrl = request.ProjectUrl != String.Empty ? request.ProjectUrl : result.ProjectUrl,
                        ClientName = request.ClientName != String.Empty && request.ClientName is not null ? request.ClientName : result.ClientName,
                        Technologies = request.Technologies != String.Empty && request.Technologies is not null ? request.Technologies : result.Technologies,
                        CreatedDate = result.CreatedDate != DateTime.MinValue ? result.CreatedDate : DateTime.UtcNow
                    };

                    await _repository.UpdateAsync(portfolio);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Record updated successfully fo ID : {Id}.", portfolio.Id);
                    return portfolio.Id;
                }
        }
    }
   }
}
