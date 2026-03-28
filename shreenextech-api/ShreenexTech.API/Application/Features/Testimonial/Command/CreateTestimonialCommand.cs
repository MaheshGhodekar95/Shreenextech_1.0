using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ShreenexTech.API.Application.Features.Testimonial.Command
{
    public class CreateTestimonialCommand : IRequest<Guid>
    {
        public string ClientName { get; set; }
        public string CompanyName { get; set; }
        public string Feedback { get; set; }
        public string ClientImage { get; set; }
        public int? Rating { get; set; }


    }
}
