using System;
using System.Collections.Generic;
using System.IO;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.Domain.Services
{
    public class BidService: IBidService
    {
        private readonly IBidRepository _bidRepository;

        public BidService(IBidRepository BidRepository)
        {
            _bidRepository = BidRepository ?? throw new InvalidDataException("Bid Service can not be null");
        }

        public List<Bid> ReadAll()
        {
            return _bidRepository.ReadAll();
        }

        public Bid GetById(int id)
        {
            if (id < 1) throw new InvalidDataException("Bid Id must be higher than 0");
            return _bidRepository.GetById(id);
        }

        public Bid Create(int bidAmount, DateTime bidDateTime)
        {
            if (bidAmount < 1 || bidDateTime == default(DateTime))
                throw new InvalidDataException("One of the values is empty or entered incorrectly"); 
            return _bidRepository.Create(bidAmount,bidDateTime);
        }

        public Bid Update(Bid Bid)
        {
            if (Bid.BidAmount < 1 || Bid.BidDateTime == default(DateTime))
                throw new InvalidDataException("One of the values is empty or entered incorrectly");
            return _bidRepository.Update(Bid);
        }

        public Bid Delete(int id)
        {
            if (id < 1) throw new InvalidDataException("Bid Id must be higher than 0");
            return _bidRepository.Delete(id);
        }
    }
}