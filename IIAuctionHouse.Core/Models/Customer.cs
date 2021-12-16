using System.Collections.Generic;

namespace IIAuctionHouse.Core.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public CustomerDetails CustomerDetails { get; set; }

        public CustomerType CustomerType { get; set; }
        
        public List<Bid> Bids { get; set; }

        public List<Proprietary> Proprietaries { get; set; }
    }
}