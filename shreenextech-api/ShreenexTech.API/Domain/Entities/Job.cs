using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShreenexTech.API.Domain.Entities
{


    [Table("Jobs")]
    public class Job
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Job title is required")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [StringLength(200, ErrorMessage = "Location cannot exceed 200 characters")]
        public string Location { get; set; }

        [StringLength(100, ErrorMessage = "Experience cannot exceed 100 characters")]
        public string Experience { get; set; }

        [StringLength(100, ErrorMessage = "Salary cannot exceed 100 characters")]
        public string Salary { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation property - one Job has many JobApplications
        [InverseProperty("Job")]
        public ICollection<JobApplication> Applications { get; set; } = new List<JobApplication>();
    }
}
