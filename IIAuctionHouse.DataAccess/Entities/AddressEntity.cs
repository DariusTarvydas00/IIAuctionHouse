using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.DataAccess.Entities
{
    public class AddressEntity
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int PostCode { get; set; } 
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
    }
}