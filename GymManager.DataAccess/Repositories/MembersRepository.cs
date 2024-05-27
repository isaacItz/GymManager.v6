using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymManager.DataAccess.Repositories
{
    public class MembersRepository : Repository<int, Member>
    {
        public MembersRepository(GymManagerContext context) : base(context) {

        }

        public async override Task<Member> AddAsync(Member entity) {
            //Console.WriteLine(entity);
            var city = await Context.Cities.FindAsync(entity.City.Id);
            Console.WriteLine(city);
            entity.City = null;
            await Context.Members.AddAsync(entity);
            city.Members.Add(entity);

            await Context.SaveChangesAsync();
            return entity;
        }

        public async override Task<Member> GetAsync(int id) {
            var member = await Context.Members.Include(x => x.City).FirstOrDefaultAsync(x => x.Id == id);
            return member;
        }
    }
}