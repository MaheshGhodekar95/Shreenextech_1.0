using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShreenexTech.API.Domain.Entities
{
   

    [Table("NewsletterSubscribers")]
    public class NewsletterSubscriber
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(200, ErrorMessage = "Email cannot exceed 200 characters")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required]
        public DateTime SubscribedDate { get; set; } = DateTime.Now;
    }
}
