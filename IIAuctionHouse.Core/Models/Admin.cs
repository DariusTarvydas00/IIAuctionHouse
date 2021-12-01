namespace IIAuctionHouse.Core.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public Proprietary Proprietary { get; set; }
        public Bid Bid { get; set; }
    }
}