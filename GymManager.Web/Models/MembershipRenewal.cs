using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManager.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace GymManager.Web.Models
{
    public class MembershipRenewal
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string SearchValue { get; set; }

        public List<MemberMembership> Members { get; set; }

        public override string ToString() {
            return $"Id: {Id}, SearchValue: {SearchValue}\nMembershipsMembers: {Members}";
        }
    }
}