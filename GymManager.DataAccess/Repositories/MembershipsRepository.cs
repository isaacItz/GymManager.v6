using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymManager.DataAccess.Repositories
{
    public class MembershipsRepository : Repository<int, Membership>
    {
        public MembershipsRepository(GymManagerContext context) : base(context) {

        }

        public async override Task<Membership> UpdateAsync(Membership entity){
            Console.WriteLine("entro al MembershipRepository");
            Context.Attach(entity);
            Context.Entry(entity).Property(x => x.Name ).IsModified = true;
            Context.Entry(entity).Property(x => x.Cost ).IsModified = true;
            Context.Entry(entity).Property(x => x.Duration ).IsModified = true;
            await Context.SaveChangesAsync();
            return entity;
        }
        
    }
}