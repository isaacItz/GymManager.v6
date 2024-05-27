using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymManager.DataAccess.Repositories
{
    public class MemberMembershipsRepository : Repository<int, MemberMembership>
    {
        public MemberMembershipsRepository(GymManagerContext context) : base(context) {

        }

        //public async override Task<MemberMembership> AddAsync(MemberMembership entity) {
        //    //Console.WriteLine(entity);
        //    var city = await Context.Cities.FindAsync(entity.City.Id);
        //    Console.WriteLine(city);
        //    entity.City = null;
        //    await Context.Members.AddAsync(entity);
        //    city.Members.Add(entity);

        //    await Context.SaveChangesAsync();
        //    return entity;
        //}

        //public async override Task<MemberMembership> GetAsync(int id) {
        //    var member = await Context.MemberMemberships.FindAsync(id);
        //    Console.WriteLine(member);
        //    return member;
        //}

        public async Task<List<MemberMembership>> GetMatches(string text) {
            var list = (from mm in Context.MemberMemberships
                //join m in Context.Members on mm.Member.Id equals m.Id 
                //join ms in Context.Memberships on mm.Membership.Id equals ms.Id
                select new MemberMembership {
                    Id =  mm.Id,
                    Date = mm.Date,
                    Membership = mm.Membership,
                    Member = mm.Member
                }).Where(x => (x.Member.Name + " " + x.Member.LastName).Contains(text)).ToList();
            return list;
        }
    }
}