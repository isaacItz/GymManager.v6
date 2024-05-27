using GymManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.ApplicationServices.MemberMemberships
{
    public interface IMemberMembershipsAppService
    {
        Task<List<MemberMembership>> GetMemberMembershipsAsync();
        
        Task<int> AddMemberMembershipAsync(MemberMembership memberMembership);

        Task DeleteMemberMembershipAsync(int memberMembershipId);

        Task<MemberMembership> GetMemberMembershipAsync(int memberMembershipId);

        Task EditMemberMembershipAsync(MemberMembership memberMembership);

        Task<List<MemberMembership>> GetMatches(string text);
    }
}
