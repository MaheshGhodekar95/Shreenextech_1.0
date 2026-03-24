using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShreenexTech.API.Domain.Entities
{
    [Table("Portfolio")]
    public class Portfolio
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        public string Description { get; set; }

        [StringLength(500)]
        public string? ImageUrl { get; set; }

        [StringLength(200)]
        public string ClientName { get; set; }

        [StringLength(500)]
        public string? ProjectUrl { get; set; }

        [StringLength(500)]
        public string Technologies { get; set; }

        // Value is provided by the database via the DEFAULT (getdate()) constraint.
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
    }
}