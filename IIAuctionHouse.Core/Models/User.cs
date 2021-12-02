using System.Collections.Generic;
using IIAuctionHouse.Core.Models.AccDetails;

namespace IIAuctionHouse.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public List<Proprietary> Proprietaries { get; set; }
        public List<Bid> Bids { get; set; }
    }
}