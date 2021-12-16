using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.Domain.Exceptions;
using IIAuctionHouse.Core.Domain.IRepositories;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.Domain.Services
{
    public class BidService: IBidService
    {
        private readonly IBidRepository _bidRepository;

        public BidService(IBidRepository bidRepository)
        {
            _bidRepository = bidRepository ?? throw new InvalidDataException(BidExceptions.BidRepoCannotBeNull);
        }

        public Bid NewBid(int bidAmount, DateTime bidDateTime)
        {
            return new Bid()
            {
                BidAmount = bidAmount,
                BidDateTime = bidDateTime,
            };
        }
        public Bid CreateBid(Bid bid)
            {
                if (bid == null) 
                    throw new InvalidDataException(BidExceptions.BidIsIncorrect);
                if (bid.BidAmount < 1)
                    throw new InvalidDataException(BidExceptions.BidAmountIsIncorrect);
                if (bid.BidDateTime == null || bid.BidDateTime == DateTime.MinValue)
                    throw new InvalidDataException(BidExceptions.BidDateTimeIsIncorrect);
                return _bidRepository.Create(bid);
            }

        public Bid GetBidById(int id)
        {
                if (id < 1)
                    throw new InvalidDataException(BidExceptions.BidIdIncorrect);
                return _bidRepository.ReadById(id);
        }

        public List<Bid> GetAllBids()
        {
                return _bidRepository.ReadAll().ToList();

        }

        public Bid UpdateBid(Bid bidUpdate)
        {
            if (bidUpdate == null) 
                throw new InvalidDataException(BidExceptions.BidIsIncorrect);
            if (bidUpdate.BidAmount < 1)
                throw new InvalidDataException(BidExceptions.BidAmountIsIncorrect);
            if (bidUpdate.BidDateTime == null || bidUpdate.BidDateTime == DateTime.MinValue)
                throw new InvalidDataException(BidExceptions.BidDateTimeIsIncorrect);
            return _bidRepository.Update(bidUpdate);
        }

        public Bid DeleteBid(int id)
        {
                if (id < 1) 
                    throw new InvalidDataException(BidExceptions.BidIdIncorrect);
                return _bidRepository.Delete(id);
        }
    }
}