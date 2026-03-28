using MediatR;
using Microsoft.EntityFrameworkCore;
using ShreenexTech.API.Application.Common.Exceptions;
using ShreenexTech.API.Application.Features.Portfolios.Command;
using ShreenexTech.API.Application.Features.Testimonial.Command;
using ShreenexTech.API.Application.Interfaces;
using ShreenexTech.API.Domain.Entities;
using ShreenexTech.API.Infrastructure.Data;

namespace ShreenexTech.API.Application.Handlers
{
    public class UpdateTestimonialHandler : IRequestHandler<UpdateTestimonialCommand, Guid>
    {
        private readonly IRepository<Testimonial> _repository;
        private readonly AppDbContext _context;
        private readonly ILogger<UpdateTestimonialHandler> _logger;


        public UpdateTestimonialHandler(IRepository<Testimonial> repository, AppDbContext context, ILogger<UpdateTestimonialHandler> logger)
        {
            _repository = repository;
            _context = context;
            _logger = logger;
        }

        public async Task<Guid> Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                _logger.LogWarning("Required fields are Empty or Null...");
                throw new BadRequestException("Required parameters should not empty...");
            }
            else
            {
                _logger.LogInformation("Updating record started for : {Id}", request.Id);
                var result = await _context.Testimonials.AsNoTracking().FirstOrDefaultAsync(p => p.Id == request.Id);

                if (result is null)
                {
                    _logger.LogInformation("Record with Id : {Id} not found.", request.Id);
                    throw new NotFoundException("Portfolio not found", request.Id);
                }
                else
                {

                    var testimonial = new Testimonial
                    {
                        Feedback = request.Feedback != String.Empty && request.Feedback is not null ? request.Feedback : result.Feedback,
                        Rating = request.Rating is not null ? request.Rating : result.Rating,
                        ClientImage = result.ClientImage,
                        ClientName = result.ClientImage,
                        CreatedDate = result.CreatedDate,
                        CompanyName = result.CompanyName
                    };

                    await _repository.UpdateAsync(testimonial);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Record updated successfully fo ID : {Id}.", testimonial.Id);
                    return testimonial.Id;
                }
            }
        }
    }
}
