namespace IIAuctionHouse.DataAccess
{
    public interface IAuctionHouseDbSeeder
    {
        void SeedDevelopment();
        void SeedProduction();
    }
}