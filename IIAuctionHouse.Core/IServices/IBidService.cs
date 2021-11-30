using System;
using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.IServices
{
    public interface IBidService
    {
        List<Bid> ReadAll();
        Bid GetById(int id);
        Bid Create(int bidAmount, DateTime bidDateTime);
        Bid Update(Bid bid);
        Bid Delete(int id);
    }
}