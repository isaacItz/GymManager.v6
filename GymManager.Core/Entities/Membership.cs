using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymManager.Core.Entities
{
    public class Membership
    {
       public int Id { get; set; }

       [Required]
       [StringLength(50)]
       public string Name { get; set; }

       [Required]
       [Column(TypeName = "decimal(10,2)")]
       public decimal Cost { get; set; }

       [Required]
       public DateTime CreatedOn { get; set; }

       [Required]
       public int Duration { get; set; }

       [Required]
       public string DurationMeasure { get; set; }
       
       public override string ToString() {
           return $"Id: {Id}, Name: {Name}, Cost: {Cost}";
       }
    }
}