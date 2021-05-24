using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic;

namespace Sales.Entities.Sales
{
    public class Sales
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int PersonnelId { get; set; }
        public DateTime? ReportDate { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal? SalesAmount { get; set; }
    }
}
