using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GymManager.Core.Entities
{
    public class City
    {
        public City () {
            Members = new List<Member>();
        }
        
        public int Id { set; get; }

        [StringLength(200)]
        [Required]
        public string Name { set; get; }

        public virtual List<Member>? Members { get; set; }

        public override string ToString() {
            return $"Id: {Id}, Name: {Name}";
        }
    }
}
