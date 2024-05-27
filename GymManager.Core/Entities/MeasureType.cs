using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GymManager.Core.Entities
{
    public class MeasureType
    {

        public MeasureType() {
            Products = new List<Product>();
        }
        
        public int Id { get; set; }

        [StringLength(200)]
        [Required]
        public int Name { get; set; }

        public List<Product>? Products { get; set; }
    }
}