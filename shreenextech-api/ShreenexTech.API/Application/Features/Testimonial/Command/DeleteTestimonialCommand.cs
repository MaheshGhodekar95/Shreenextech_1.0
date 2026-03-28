using MediatR;

namespace ShreenexTech.API.Application.Features.Testimonial.Command
{
    public class DeleteTestimonialCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
