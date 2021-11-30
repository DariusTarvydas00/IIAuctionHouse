using System;

namespace IIAuctionHouse.DataAccess.Entities
{
    public class BidEntity
    {
        public int Id { get; set; }
        public int BidAmount { get; set; }
        public DateTime BidDateTime { get; set; }
    } 
}