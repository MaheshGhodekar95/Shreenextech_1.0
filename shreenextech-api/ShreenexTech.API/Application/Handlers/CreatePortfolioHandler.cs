using MediatR;
using ShreenexTech.API.Application.Interfaces;
using ShreenexTech.API.Domain.Entities;
using ShreenexTech.API.Infrastructure.Data;
using ShreenexTech.API.Application.Features.Portfolios.Command;

namespace ShreenexTech.API.Application.Handlers
{   
    public class 
    CreatePortfolioHandler : IRequestHandler<CreatePortfolio, Guid>
    {
        private readonly IRepository<Portfolio> _repository;
        private readonly AppDbContext _context;

        public CreatePortfolioHandler(IRepository<Portfolio> repository, AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<Guid> Handle(CreatePortfolio request, CancellationToken cancellationToken)
        {
            var portfolio = new Portfolio
            {
                Id = request.Id,
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

            return portfolio.Id;
        }
    }
}
