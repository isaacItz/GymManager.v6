using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GymManager.Core.Entities;

namespace GymManager.DataAccess
{
    public class GymManagerContext : IdentityDbContext
    {
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<MeasureType> MeasureTypes { get; set; }
        public virtual DbSet<ProductPrice> ProductPrices { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SaleRow> SaleRows { get; set; }
        public virtual DbSet<Refilled> Refills { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<EquipmentType> EquipmentTypes { get; set; }
        public virtual DbSet<Membership> Memberships { get; set; }
        public virtual DbSet<MemberMembership> MemberMemberships { get; set; }

        public GymManagerContext(DbContextOptions<GymManagerContext> options) : base(options)
        {

        }

    }
}