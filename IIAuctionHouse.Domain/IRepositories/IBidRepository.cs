using System;
using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Domain.IRepositories
{
    public interface IBidRepository
    {
        public IEnumerable<Bid> ReadAll();

        public Bid GetById(int id);

        public Bid Create(int bidAmount, DateTime bidDateTime);

        public Bid Update(Bid bid);

        public Bid Delete(int id);
    }
} 