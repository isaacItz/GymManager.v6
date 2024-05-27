using GymManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.ApplicationServices.MemberShips
{
    public interface IMemberShipsAppService
    {
        Task<List<Membership>> GetMemberShipsAsync();
        
        Task<int> AddMemberShipAsync(Membership memberShip);

        Task DeleteMemberShipAsync(int memberShipId);

        Task<Membership> GetMemberShipAsync(int memberShipId);

        Task EditMemberShipsAsync(Membership memberShip);
    }
}
