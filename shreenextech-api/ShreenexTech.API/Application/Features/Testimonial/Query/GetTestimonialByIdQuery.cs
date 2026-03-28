using MediatR;
using ShreenexTech.API.Application.Common.DTO_s;

namespace ShreenexTech.API.Application.Features.Testimonial.Query
{
    public class GetTestimonialByIdQuery : IRequest<GetTestimonialByIdDto>
    {
        public Guid Id { get; set; }
    }
}
