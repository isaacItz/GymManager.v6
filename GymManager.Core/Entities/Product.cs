using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManager.Core.Entities
{
    public class Product
    {

        public Product() { 
            Refills = new List<Refilled>();
            Prices = new List<ProductPrice>();
        }

        public int Id { get; set; }

        [StringLength(200)]
        [Required]
        public string Name { get; set; }

        [StringLength(200)]
        [Required]
        public string Brand { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        public MeasureType MeasureType { get; set; }

        public ProductType ProductType { get ; set; }

        public List<ProductPrice>? Prices { get; set; }

        public List<Refilled>? Refills { get; set; }

    }
}