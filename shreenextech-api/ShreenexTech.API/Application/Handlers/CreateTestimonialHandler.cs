using MediatR;
using ShreenexTech.API.Application.Common.Exceptions;
using ShreenexTech.API.Application.Features.ContactUs.Command;
using ShreenexTech.API.Application.Features.Testimonial.Command;
using ShreenexTech.API.Application.Interfaces;
using ShreenexTech.API.Domain.Entities;
using ShreenexTech.API.Infrastructure.Data;

namespace ShreenexTech.API.Application.Handlers
{
    public class CreateTestimonialHandler : IRequestHandler<CreateTestimonialCommand, Guid>
    {
        private readonly IRepository<Testimonial> _repository;
        private readonly AppDbContext _context;
        private readonly ILogger<CreateTestimonialHandler> _logger;


        public CreateTestimonialHandler(IRepository<Testimonial> repository, AppDbContext context, ILogger<CreateTestimonialHandler> logger)
        {
            _repository = repository;
            _context = context;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            if (request.ClientName == string.Empty || request.Rating is null || request.ClientImage == string.Empty || request.Feedback == string.Empty)
            {
                _logger.LogWarning("Required fields are Empty or Null...");
                throw new BadRequestException("Required parameters should not empty...");
            }
            else
            {
                _logger.LogInformation("Inserting record started for : {request}", request);
                var testimonial = new Testimonial
                {
                    Id = Guid.NewGuid(),
                    ClientName = request.ClientName,
                    Feedback = request.Feedback,
                    ClientImage = request.ClientImage,
                    CompanyName = request.CompanyName,
                    Rating = request.Rating,
                    CreatedDate = DateTime.Now
                };

                await _repository.AddAsync(testimonial);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Record inserted Successfully with ID : {Id}.", testimonial.Id);
                return testimonial.Id;
            }
        }
    }
}
