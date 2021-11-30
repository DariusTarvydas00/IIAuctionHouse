using System.Reflection.PortableExecutable;
using IIAuctionHouse.Core.Models;
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
            modelBuilder.Entity<AccDetailsEntity>().HasOne(ad => ad.Address).WithOne().HasForeignKey<Address>(sss => new {sss.Id})
                .OnDelete(DeleteBehavior.SetNull);
        }

        public virtual DbSet<AddressEntity> Addresses { get; set; }
        public virtual DbSet<AccDetailsEntity> AccDetails { get; set; }
 
        public virtual DbSet<ProprietaryEntity> Proprietaries { get; set; }

        public virtual DbSet<BidEntity> Bids { get; set; }
    }
}