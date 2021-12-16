using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.Domain.IRepositories;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.DataAccess.Entities;

namespace IIAuctionHouse.DataAccess.Repositories
{
    public class BidRepository: IBidRepository
    {
        private readonly AuctionHouseDbContext _ctx;

        public BidRepository(AuctionHouseDbContext ctx)
        {
            if (ctx == null) throw new InvalidDataException("Non existing DbContext");
            _ctx = ctx;
        } 

        public IEnumerable<Bid> ReadAll()
        {
            return _ctx.Bids.Select(ae=>new Bid()
            {
                Id = ae.Id,
                BidAmount = ae.BidAmount,
                BidDateTime = ae.BidDateTime
            }).ToList();
        }

        public Bid ReadById(int id)
        {
            return _ctx.Bids.Select(ae => new Bid()
            {
                Id = ae.Id,
                BidAmount = ae.BidAmount,
                BidDateTime = ae.BidDateTime
            }).FirstOrDefault(e => e.Id == id);
        }

        public Bid Create(Bid bid)
        {
            var entity = _ctx.Bids.Add(new BidEntity()
            {
                BidAmount = bid.BidAmount,
                BidDateTime = bid.BidDateTime
            }).Entity;
            return new Bid()
            {
                Id = entity.Id,
                BidAmount = entity.BidAmount,
                BidDateTime = entity.BidDateTime
            };
        }

        public Bid Update(Bid bid)
        {
            var entity = _ctx.Bids.Update(new BidEntity()
            {
                Id = bid.Id,
                BidAmount = bid.BidAmount,
                BidDateTime = bid.BidDateTime
            }).Entity;
            _ctx.SaveChanges();
            return new Bid()
            {
                Id = entity.Id,
                BidAmount = entity.BidAmount,
                BidDateTime = entity.BidDateTime
            };
        }

        public Bid Delete(int id)
        {
            var entity = _ctx.Bids.Remove(new BidEntity()
            {
                Id = id
            }).Entity;
            _ctx.SaveChanges();
            return new Bid()
            {
                Id = entity.Id,
                BidAmount = entity.BidAmount,
                BidDateTime = entity.BidDateTime
            };
        }
    }
}