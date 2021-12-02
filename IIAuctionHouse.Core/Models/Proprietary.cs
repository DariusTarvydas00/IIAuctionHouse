using System.Collections.Generic;

namespace IIAuctionHouse.Core.Models
{
    public class Proprietary
    {
        public int Id { get; set; } 
        public string CadastreNumber { get; set; }
        public string ForestryEnterprise { get; set; }
        public string City { get; set; }
        public List<Bid> Bids { get; set; }
    }
}