

namespace IIAuctionHouse.DataAccess.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }
       // public Address Address { get; set; }
       // public int AddressId { get; set; }
       // public List<Proprietary> Proprietary { get; set; }
       // public int ProprietaryId { get; set; }
       // public List<Bid> Bid { get; set; }
        //public int BidId { get; set; }
    }
}