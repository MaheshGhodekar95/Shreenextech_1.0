namespace ShreenexTech.API.Application.Common.DTO_s
{
    using System.ComponentModel.DataAnnotations;

    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
