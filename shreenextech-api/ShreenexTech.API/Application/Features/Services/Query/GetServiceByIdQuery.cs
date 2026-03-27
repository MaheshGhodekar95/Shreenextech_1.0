using MediatR;
using ShreenexTech.API.Application.Common.DTO_s;

namespace ShreenexTech.API.Application.Features.Services.Query
{
    public class GetServiceByIdQuery : IRequest<GetServiceByIdDto>
    {
        public Guid Id { get; set; }
    }
}
