using GymManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GymManager.DataAccess.Repositories;

namespace GymManager.ApplicationServices.MemberMemberships
{
    public class MemberMembershipsAppService : IMemberMembershipsAppService
    {
        private readonly MemberMembershipsRepository _repository;

        public MemberMembershipsAppService(MemberMembershipsRepository repository) {
            _repository = repository;
        }

        public async Task<int> AddMemberMembershipAsync(MemberMembership memberMembership)
        {
            await _repository.AddAsync(memberMembership);
            return memberMembership.Id;
        }
        public async Task<List<MemberMembership>> GetMemberMembershipsAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task DeleteMemberMembershipAsync(int memberMembershipId)
        {
            await _repository.DeleteAsync(memberMembershipId);
        }

        public async Task<MemberMembership> GetMemberMembershipAsync(int memberMembershipId)
        {
            return await _repository.GetAsync(memberMembershipId);
        }

        public async Task EditMemberMembershipAsync(MemberMembership memberMembership)
        {
            await _repository.UpdateAsync(memberMembership);
        }

        public async Task<List<MemberMembership>> GetMatches(string text) {
            return await _repository.GetMatches(text);
        }
    }
}
