using System;
using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.IServices
{
    public interface IBidService
    {
        Bid NewBid(int bidAmount, DateTime bidDateTime);
        Bid CreateBid(Bid bid);
        Bid GetBidById(int id);
        List<Bid> GetAllBids();
        Bid UpdateBid(Bid bidUpdate);
        Bid DeleteBid(int id); 
    }
}