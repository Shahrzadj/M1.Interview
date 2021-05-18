using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Personnel.Entities
{
    public class Personnel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Must be less than 50 characters.")]
        public string Name { get; set; }
        [Required]
        [Range(18, 150)]
        public int Age { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Must be less than 20 characters.")]
        public string Phone { get; set; }
    }
}
