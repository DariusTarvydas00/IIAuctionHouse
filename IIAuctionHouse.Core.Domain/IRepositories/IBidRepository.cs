using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.Domain.IRepositories
{
    public interface IBidRepository
    {
        public IEnumerable<Bid> ReadAll();
        public Bid ReadById(int id);
        public Bid Create(Bid bid);
        public Bid Update(Bid bid);
        public Bid Delete(int id);
    }
} 