using GymManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GymManager.DataAccess.Repositories;

namespace GymManager.ApplicationServices.MemberShips
{
    public class MemberShipsAppService : IMemberShipsAppService
    {
        private readonly IRepository<int, Membership> _repository;

        public MemberShipsAppService(IRepository<int, Membership> repository) {
            _repository = repository;
        }

        public async Task<int> AddMemberShipAsync(Membership memberShip)
        {
            await _repository.AddAsync(memberShip);
            return memberShip.Id;
        }

        public async Task<List<Membership>> GetMemberShipsAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public async Task DeleteMemberShipAsync(int memberShipId)
        {
            await _repository.DeleteAsync(memberShipId);
        }

        public async Task<Membership> GetMemberShipAsync(int memberShipId)
        {
            return await _repository.GetAsync(memberShipId);
        }

        public async Task EditMemberShipsAsync(Membership memberShip)
        {
            await _repository.UpdateAsync(memberShip);
        }
    }
}
