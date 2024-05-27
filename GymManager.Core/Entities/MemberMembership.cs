using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GymManager.Core.Entities
{
    public class MemberMembership
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public virtual Membership Membership { get; set; }

        public virtual Member Member { get; set; }

        public bool status { get; set; }

        public override string ToString(){
            return $"Id: {Id}, \nMember: {Member}, \nMembership: {Membership}";
        }
    }
}