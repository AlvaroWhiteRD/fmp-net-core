using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlvaroFacturacionApi.Domain.Models
{

    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string ProductCode { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string ProductName { get; set; }

        [Required]
        [Column(TypeName = "varchar(250)")]
        public string ProductDescription { get; set; }

        [Required]
        public decimal PriceOfTheProduct { get; set; }
    }
}