using MediatR;
using ShreenexTech.API.Application.Common.DTO_s;
using ShreenexTech.API.Application.Features.ContactUs.Query;
using ShreenexTech.API.Application.Features.Portfolios.Query;
using ShreenexTech.API.Application.Interfaces;
using ShreenexTech.API.Domain.Entities;

namespace ShreenexTech.API.Application.Handlers
{
    public class GetAllContactMessagesHandler : IRequestHandler<GetAllContactMessagesQuery, GetAllContactMessagesDto>
    {
        private readonly IRepository<ContactMessage> _repository;
        private readonly ILogger<GetAllContactMessagesHandler> _logger;

        public GetAllContactMessagesHandler(IRepository<ContactMessage> repository, ILogger<GetAllContactMessagesHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<GetAllContactMessagesDto> Handle(GetAllContactMessagesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching all Contact Message records started....");

            List<ContactMessage>? messages = await _repository.GetAllAsync();

            _logger.LogInformation("Total Contact Message records fetched and Count : {Count}", messages.Count);
            GetAllContactMessagesDto result = new GetAllContactMessagesDto();
            if (messages.Any())
            {
                foreach (var message in messages)
                {
                    result.Messages.Add(new AllMessage
                    {
                        Id = message.Id,
                        Name = message.Name,
                        Email = message.Email,
                        Phone = message.Phone,
                        Message = message.Message,
                        IsReplied = message.IsReplied,
                        CreatedDate = message.CreatedDate
                    });
                }
            }
            return result;
        }
    }
}
