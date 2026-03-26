using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShreenexTech.API.Application.Common.DTO_s
{
    public class GetPortfolioByIdDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public string? ImageUrl { get; set; }

        
        public string ClientName { get; set; }

        
        public string? ProjectUrl { get; set; }

        
        public string Technologies { get; set; }

        
        public DateTime CreatedDate { get; set; }
    }
}

