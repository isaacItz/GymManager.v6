using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace GymManager.Core.Members
{
    public class Member
    {
        public int Id { get; set; }
        
        [StringLength(15)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [StringLength(20)]
        [Required]
        public string LastName { get; set; }
        
        [BindProperty, DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDay { get; set; }

        [Range(1,5)]
        public int CityId { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        public bool AllowNewsLetter { get; set; }

    }
}
