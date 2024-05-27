using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GymManager.Core.Entities
{
    public class ProductType
    {

        public ProductType() {
            Products = new List<Product>();
        }
        
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public List<Product>? Products { get; set; }
    }
}