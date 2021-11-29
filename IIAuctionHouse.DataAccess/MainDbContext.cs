using IIAuctionHouse.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace IIAuctionHouse.DataAccess
{
    public class MainDbContext: DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
            
        }

        public virtual DbSet<AddressEntity> Addresses { get; set; }
    }
}