using MediatR;
using ShreenexTech.API.Domain.Entities;

namespace ShreenexTech.API.Application.Features.Portfolios.Query
{   

    public class GetAllPortfoliosQuery : IRequest<List<Portfolio>>
    {
    }
}
