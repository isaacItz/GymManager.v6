using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GymManager.Core.Entities
{
    public class SaleRow
    {
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        public Sale Sale { get; set; }

        public Refilled Refilled { get; set; }
    }
}