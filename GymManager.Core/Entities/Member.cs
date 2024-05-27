using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace GymManager.Core.Entities
{
    public class Member
    {

        public Member() {
            MemberMemberships = new List<MemberMembership>();
        }

        public int Id { get; set; }
        
        [StringLength(15)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [StringLength(20)]
        [Required]
        public string LastName { get; set; }
        
        //[BindProperty, DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [BindProperty, DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly BirthDay { get; set; }

        [Required]
        public DateOnly RegisteredDate { get; set; }

        public virtual City City { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        public bool AllowNewsLetter { get; set; }

        public List<MemberMembership>? MemberMemberships { get; set; }

        public override string ToString() {
            return $"Id: {Id}\nName: {Name} \nLastName: {LastName} \nBirthDay: {BirthDay}\nRegistered Date: {RegisteredDate}\nCity: {City}\nEmail: {Email}\nNewsLetter: {AllowNewsLetter}";
        }
    }
}