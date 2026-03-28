using MediatR;
using ShreenexTech.API.Application.Common.DTO_s;
using ShreenexTech.API.Application.Features.Services.Query;
using ShreenexTech.API.Application.Features.Testimonial.Query;
using ShreenexTech.API.Application.Interfaces;
using ShreenexTech.API.Domain.Entities;
using ShreenexTech.API.Infrastructure.Data;

namespace ShreenexTech.API.Application.Handlers
{
    public class GetAllTestimonialsHandler : IRequestHandler<GetAllTestimonialQuery, GetAllTestimonialDto>
    {
        private readonly IRepository<Testimonial> _repository;
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<GetAllTestimonialsHandler> _logger;
        public GetAllTestimonialsHandler(IRepository<Testimonial> repository, AppDbContext appDbContext, ILogger<GetAllTestimonialsHandler> looger)
        {
            _repository = repository;
            _appDbContext = appDbContext;
            _logger = looger;
        }

        public async Task<GetAllTestimonialDto> Handle(GetAllTestimonialQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching all portfolio records started....");

            List<Testimonial>? testimonials = await _repository.GetAllAsync();

            _logger.LogInformation("Total portfolio records fetched and Count : {Count}", testimonials.Count);
            GetAllTestimonialDto? result = new GetAllTestimonialDto();
            if (testimonials.Any())
            {
                foreach (var testimonial in testimonials)
                {
                    result.getAll.Add(new Testimonials()
                    {
                        ClientName = testimonial.ClientName,
                        ClientImage = testimonial.ClientImage,
                        CompanyName = testimonial.CompanyName,
                        Id = testimonial.Id,
                        Rating = testimonial.Rating,
                        Feedback = testimonial.Feedback,
                        CreatedDate = testimonial.CreatedDate,
                    });
                }
            }
            return result;
        }
    }
}

