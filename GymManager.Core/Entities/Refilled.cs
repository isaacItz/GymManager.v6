using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManager.Core.Entities
{
    public class Refilled
    {
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public DateTime Expiration { get; set; }

        [Required]
        public DateTime RefilledDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public Decimal CostPerUnit { get; set; }

        public Product Product { get; set; }

        public List<ProductPrice> ProductPrices { get; set; }
    }
}