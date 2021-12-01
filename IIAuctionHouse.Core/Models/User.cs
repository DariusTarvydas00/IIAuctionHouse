using System.Collections.Generic;

namespace IIAuctionHouse.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public List<Proprietary> Proprietary { get; set; }
        public List<Bid> Bid { get; set; }
    }
}