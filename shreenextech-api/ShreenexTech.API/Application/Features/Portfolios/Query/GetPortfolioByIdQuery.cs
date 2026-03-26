using MediatR;
using ShreenexTech.API.Application.Common.DTO_s;
using ShreenexTech.API.Domain.Entities;

namespace ShreenexTech.API.Application.Features.Portfolios.Query
{
    public class GetPortfolioByIdQuery : IRequest<GetPortfolioByIdDto>
    {
        public Guid Id { get; set; }
    }
}
