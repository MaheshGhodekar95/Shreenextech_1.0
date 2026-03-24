using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShreenexTech.API.Domain.Entities
{

    [Table("TeamMembers")]
    public class TeamMember
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(200, ErrorMessage = "Name cannot exceed 200 characters")]
        public string Name { get; set; }

        [StringLength(200, ErrorMessage = "Role cannot exceed 200 characters")]
        public string Role { get; set; }

        [StringLength(500, ErrorMessage = "Image URL cannot exceed 500 characters")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [StringLength(500, ErrorMessage = "LinkedIn URL cannot exceed 500 characters")]
        [DataType(DataType.Url)]
        public string LinkedInUrl { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
