using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManager.Core.Entities
{
    public class Sale
    {
        public int Id { get; set; }

        [Required]
        public DateTime SaleDate { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        public List<SaleRow> SaleRows { get; set; }
    }
}