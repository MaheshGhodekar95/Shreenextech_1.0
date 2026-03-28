namespace ShreenexTech.API.Application.Common.DTO_s
{
    public class GetAllContactMessagesDto
    {
       public List<AllMessage> Messages { get; set; } = new List<AllMessage>();
    }
    
    public class AllMessage
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public bool IsReplied { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
