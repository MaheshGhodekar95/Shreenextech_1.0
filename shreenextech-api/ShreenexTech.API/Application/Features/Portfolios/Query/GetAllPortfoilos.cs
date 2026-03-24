using MediatR;
using ShreenexTech.API.Domain.Entities;

namespace ShreenexTech.API.Application.Features.Portfolios.Query
{   

    public class GetAllPortfolios : IRequest<List<Portfolio>>
    {
    }
}
