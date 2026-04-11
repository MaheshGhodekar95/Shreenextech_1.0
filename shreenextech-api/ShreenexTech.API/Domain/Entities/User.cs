namespace ShreenexTech.API.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        [RegularExpression("Admin", ErrorMessage = "Role must be Admin")]
        public string Role { get; set; } = "Admin";
    }
}
