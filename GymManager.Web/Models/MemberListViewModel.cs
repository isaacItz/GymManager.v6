using GymManager.Core.Entities;

namespace GymManager.Web.Models
{
    public class MemberListViewModel
    {
        public int NewMembersCount { get; set; }

        public List<Member> Members { get; set; }
    }
}
