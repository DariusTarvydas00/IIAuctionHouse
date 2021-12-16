using IIAuctionHouse.Core.Models;
using IIAuctionHouse.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace IIAuctionHouse.DataAccess
{
    public class AuctionHouseDbContext: DbContext
    {
        public AuctionHouseDbContext(DbContextOptions<AuctionHouseDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Bid>().HasOne(p=>p.Id).WithMany(b=>b.)
        }
        public virtual DbSet<CustomerDetailsEntity> AllCustomerDetails { get; set; }
 
        public virtual DbSet<ProprietaryEntity> Proprietaries { get; set; }

        public virtual DbSet<BidEntity> Bids { get; set; }

    }
}