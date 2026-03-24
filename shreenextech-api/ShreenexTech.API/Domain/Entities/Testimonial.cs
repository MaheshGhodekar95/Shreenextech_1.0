using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShreenexTech.API.Domain.Entities
{
    

    [Table("Testimonials")]
    public class Testimonial
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(200, ErrorMessage = "Client name cannot exceed 200 characters")]
        public string ClientName { get; set; }

        [StringLength(200, ErrorMessage = "Company name cannot exceed 200 characters")]
        public string CompanyName { get; set; }

        [DataType(DataType.MultilineText)]
        public string Feedback { get; set; }

        [StringLength(500, ErrorMessage = "Client image URL cannot exceed 500 characters")]
        [DataType(DataType.ImageUrl)]
        public string ClientImage { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int? Rating { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
