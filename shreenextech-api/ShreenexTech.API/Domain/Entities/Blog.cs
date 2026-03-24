using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShreenexTech.API.Domain.Entities
{
   

    [Table("Blogs")]
    public class Blog
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(300, ErrorMessage = "Title cannot exceed 300 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Slug is required")]
        [StringLength(300)]
        public string Slug { get; set; }

        [Required(ErrorMessage = "Content is required")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [StringLength(500)]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [StringLength(200)]
        public string Author { get; set; }

        public DateTime? PublishedDate { get; set; }

        public bool IsPublished { get; set; } = false;
    }
}
