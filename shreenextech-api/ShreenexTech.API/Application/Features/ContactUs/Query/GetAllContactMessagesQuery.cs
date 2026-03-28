using MediatR;
using ShreenexTech.API.Application.Common.DTO_s;

namespace ShreenexTech.API.Application.Features.ContactUs.Query
{
    public class GetAllContactMessagesQuery : IRequest<GetAllContactMessagesDto>
    {
    }
}
