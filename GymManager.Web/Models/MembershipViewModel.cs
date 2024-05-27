using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GymManager.Web.Models
{
    public class MembershipViewModel
    {
        public int Id { get; set; }
        
        [StringLength(20)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public decimal Cost { get; set; }
        
        public int Duration { get; set; }

    }
}