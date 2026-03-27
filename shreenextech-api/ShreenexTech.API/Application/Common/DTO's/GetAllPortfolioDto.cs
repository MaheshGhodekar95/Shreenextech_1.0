using ShreenexTech.API.Domain.Entities;

namespace ShreenexTech.API.Application.Common.DTO_s
{
    public class GetAllPortfolioDto
    {
        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
    }
}

