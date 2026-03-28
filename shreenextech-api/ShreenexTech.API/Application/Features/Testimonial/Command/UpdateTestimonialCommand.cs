using MediatR;

namespace ShreenexTech.API.Application.Features.Testimonial.Command
{
    public class UpdateTestimonialCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Feedback { get; set; }
        public int? Rating { get; set; }
    }
}
