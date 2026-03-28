using System.ComponentModel.DataAnnotations;

namespace ShreenexTech.API.Application.Common.DTO_s
{
    public class GetTestimonialByIdDto
    {
        public Guid Id { get; set; }
        public string ClientName { get; set; }
        public string CompanyName { get; set; }
        public string Feedback { get; set; }
        public string ClientImage { get; set; }
        public int? Rating { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
