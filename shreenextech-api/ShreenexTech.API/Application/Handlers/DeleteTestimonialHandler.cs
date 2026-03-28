using MediatR;
using ShreenexTech.API.Application.Common.Exceptions;
using ShreenexTech.API.Application.Features.Portfolios.Command;
using ShreenexTech.API.Application.Features.Testimonial.Command;
using ShreenexTech.API.Application.Interfaces;
using ShreenexTech.API.Domain.Entities;
using ShreenexTech.API.Infrastructure.Data;

namespace ShreenexTech.API.Application.Handlers
{
    public class DeleteTestimonialHandler : IRequestHandler<DeleteTestimonialCommand, bool>
    {
        private readonly IRepository<Testimonial> _repository;
        private readonly AppDbContext _context;
        private readonly ILogger<DeleteTestimonialHandler> _logger;

        public DeleteTestimonialHandler(IRepository<Testimonial> repository, AppDbContext context, ILogger<DeleteTestimonialHandler> logger)
        {
            _repository = repository;
            _context = context;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteTestimonialCommand deleteTestimonial, CancellationToken cancellationToken)
        {
            if (deleteTestimonial == null || deleteTestimonial.Id == Guid.Empty)
            {
                _logger.LogWarning("ID is Empty or Null.");
                throw new BadRequestException("Id is Required.");
            }
            else
            {
                _logger.LogInformation("Record deleting started with ID : {Id}.", deleteTestimonial.Id);
                await _repository.DeleteAsync(deleteTestimonial.Id);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Record deleted Successfully with ID : {Id}.", deleteTestimonial.Id);
                return true;
            }
        }
    }
}

