using MediatR;
using ShreenexTech.API.Application.Common.Exceptions;
using ShreenexTech.API.Application.Features.ContactUs.Command;
using ShreenexTech.API.Application.Features.Portfolios.Command;
using ShreenexTech.API.Application.Interfaces;
using ShreenexTech.API.Domain.Entities;
using ShreenexTech.API.Infrastructure.Data;

namespace ShreenexTech.API.Application.Handlers
{
    public class CreateContactMessageHnadler : IRequestHandler<CreateContactMessageCommand, Guid>
    {
        private readonly IRepository<ContactMessage> _repository;
        private readonly AppDbContext _context;
        private readonly ILogger<CreateContactMessageHnadler> _logger;


        public CreateContactMessageHnadler(IRepository<ContactMessage> repository, AppDbContext context, ILogger<CreateContactMessageHnadler> logger)
        {
            _repository = repository;
            _context = context;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateContactMessageCommand request, CancellationToken cancellationToken)
        {
            if (request.Name == string.Empty || request.Email == string.Empty || request.Message == string.Empty || request.Phone == string.Empty)
            {
                _logger.LogWarning("Required fields are Empty or Null...");
                throw new BadRequestException("Required parameters should not empty...");
            }
            else
            {
                _logger.LogInformation("Inserting record started for : {request}", request);
                var message = new ContactMessage
                {
                    Id = Guid.NewGuid(),
                    Name = request.Name,
                    Email = request.Email,
                    Message = request.Message,
                    Phone = request.Phone,
                    IsReplied = false,
                    CreatedDate = DateTime.Now
                };

                await _repository.AddAsync(message);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Record inserted Successfully with ID : {Id}.", message.Id);
                return message.Id;
            }
        }
    }
}
    