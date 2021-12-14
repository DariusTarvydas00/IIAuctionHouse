using System.Reflection.PortableExecutable;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.AccDetails;
using IIAuctionHouse.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace IIAuctionHouse.DataAccess
{
    public class MainDbContext: DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          //  modelBuilder.Entity<AccDetailsEntity>().HasOne(ad => ad.Address).WithOne().HasForeignKey<Address>(entity => entity.Id);
         //   modelBuilder.Entity<UserEntity>().HasOne(ad => ad.).WithOne().HasForeignKey<AccDetails>(ent => ent.Id);
         //   modelBuilder.Entity<AdminEntity>().HasOne(ad => ad.Address).WithOne().HasForeignKey<AccDetails>(ent => ent.Id);
        }

        public virtual DbSet<AddressEntity> Addresses { get; set; }
        public virtual DbSet<AccDetailsEntity> AccDetails { get; set; }
 
        public virtual DbSet<ProprietaryEntity> Proprietaries { get; set; }

        public virtual DbSet<BidEntity> Bids { get; set; }

        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<AdminEntity> Admins { get; set; }
    }
}