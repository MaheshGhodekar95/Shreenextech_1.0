namespace ShreenexTech.API.Application.Common.DTO_s
{
    public class GetAllTestimonialDto
    {
        public List<Testimonials> getAll {  get; set; } = new List<Testimonials>();
    }

    public class Testimonials
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
