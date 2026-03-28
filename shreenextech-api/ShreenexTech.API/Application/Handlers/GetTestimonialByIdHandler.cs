using MediatR;
using ShreenexTech.API.Application.Common.DTO_s;
using ShreenexTech.API.Application.Common.Exceptions;
using ShreenexTech.API.Application.Features.Portfolios.Query;
using ShreenexTech.API.Application.Features.Testimonial.Query;
using ShreenexTech.API.Application.Interfaces;
using ShreenexTech.API.Domain.Entities;
using ShreenexTech.API.Infrastructure.Data;

namespace ShreenexTech.API.Application.Handlers
{
    public class GetTestimonialByIdHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdDto>
    {
        private readonly IRepository<Testimonial> _repository;
        ILogger<GetTestimonialByIdHandler> _logger;
        public GetTestimonialByIdHandler(IRepository<Testimonial> repository, ILogger<GetTestimonialByIdHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<GetTestimonialByIdDto> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                _logger.LogWarning("Required Id is Empty or Null...");
                throw new BadRequestException("Required parameters should not empty...");
            }
            else
            {
                _logger.LogInformation("Fetching record started for : {Id}", request.Id);
                var result = await _repository.GetByIdAsync(request.Id);
                if (result == null)
                {
                    throw new NotFoundException("Testimonial Not Found.", request.Id);
                }
                else
                {
                    var testimonial = new GetTestimonialByIdDto()
                    {
                        Id = result.Id,
                        ClientImage = result.ClientImage,
                        CompanyName = result.CompanyName,
                        Feedback = result.Feedback,
                        Rating = result.Rating,
                        ClientName = result.ClientName,
                        CreatedDate = result.CreatedDate,
                    };
                    _logger.LogInformation("Record fetched for Id :{Id}", request.Id);
                    return testimonial;
                }
            }

        }
    }
}

