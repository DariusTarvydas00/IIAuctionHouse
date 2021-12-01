using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.DataAccess.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public Proprietary Proprietary { get; set; }
        public int ProprietaryId { get; set; }
        public Bid Bid { get; set; }
        public int BidId { get; set; }
    }
}