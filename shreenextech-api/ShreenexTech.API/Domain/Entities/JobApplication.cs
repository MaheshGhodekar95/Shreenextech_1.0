using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShreenexTech.API.Domain.Entities
{

    [Table("JobApplications")]
    public class JobApplication
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Job is required")]
        public Guid JobId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(200, ErrorMessage = "Name cannot exceed 200 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(200)]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Resume URL is required")]
        [StringLength(500)]
        [DataType(DataType.Upload)]
        public string ResumeUrl { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation Property
        [ForeignKey("JobId")]
        [InverseProperty("Applications")]
        public Job Job { get; set; }
    }
}
