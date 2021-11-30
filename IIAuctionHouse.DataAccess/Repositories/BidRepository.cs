using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.DataAccess.Repositories
{
    public class BidRepository: IBidRepository
    {
        private readonly MainDbContext _ctx;

        public BidRepository(MainDbContext ctx)
        {
            if (ctx == null) throw new InvalidDataException("Non existing DbContext");
            _ctx = ctx;
        }

        public List<Bid> ReadAll()
        {
            return _ctx.Bids.Select(ae=>new Bid()
            {
                Id = ae.Id,
                BidAmount = ae.BidAmount,
                BidDateTime = ae.BidDateTime
            }).ToList();
        }

        public Bid GetById(int id)
        {
            var bidEntity = _ctx.Bids.Select(ae => new BidEntity()
            {
                Id = ae.Id,
                BidAmount = ae.BidAmount,
                BidDateTime = ae.BidDateTime
            }).FirstOrDefault();
            if (bidEntity != null)
            {
                return new Bid()
                {
                    Id = bidEntity.Id,
                    BidAmount = bidEntity.BidAmount,
                    BidDateTime = bidEntity.BidDateTime
                };
            }
            return null;
        }

        public Bid Create(int bidAmount, DateTime bidDateTime)
        {
            var entity = _ctx.Bids.Add(new BidEntity()
            {
                BidAmount = bidAmount,
                BidDateTime = bidDateTime
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