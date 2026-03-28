using System.ComponentModel.DataAnnotations;

namespace ShreenexTech.API.Application.Common.DTO_s
{
    public class GetServiceByIdDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public bool IsActive { get; set; }
        public string OurOffers { get; set; }
        public string Technologies { get; set; }
        public DateTime CreatedDate { get; set; } 
    }
}
