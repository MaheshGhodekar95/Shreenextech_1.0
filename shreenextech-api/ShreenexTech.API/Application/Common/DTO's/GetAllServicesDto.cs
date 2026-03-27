using ShreenexTech.API.Domain.Entities;

namespace ShreenexTech.API.Application.Common.DTO_s
{
    public class GetAllServicesDto
    {
        public List<Service> services { get; set; } = new List<Service>();
    }
}
