using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.DataAccess.Entities
{
    public class ProprietaryEntity
    {
        public int Id { get; set; }
        public string CadastreNumber { get; set; }
        public string ForestryEnterprise { get; set; }
        public string City { get; set; }

        public int BidId { get; set; }

        public List<Bid> Bids { get; set; }
    }
} 