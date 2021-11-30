using System;
using System.Collections.Generic;
using System.IO;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.Domain.Services
{
    public class AccDetailsService: IAccDetailsService
    {
        private readonly IAccDetailsRepository _accDetailsRepository;

        public AccDetailsService(IAccDetailsRepository accDetailsRepository)
        {
            _accDetailsRepository = accDetailsRepository ?? throw new InvalidDataException("Account Details Repository can not be null");
        }

        public List<AccDetails> ReadAll()
        {
            return _accDetailsRepository.ReadAll();
        }

        public AccDetails GetById(int id)
        {
            if (id < 1) throw new InvalidDataException("AccDetails Id must be higher than 0");
            return _accDetailsRepository.GetById(id);
        }

        public AccDetails Create(Address address, string email, int phoneNumber, DateTime accCreationDate)
        {
            if (address is null || email is null || phoneNumber < 1 || accCreationDate == null)
                throw new InvalidDataException("One of the values is empty or entered incorrectly"); 
            return _accDetailsRepository.Create(address, email, phoneNumber, accCreationDate);
        }

        public AccDetails Update(AccDetails accDetails)
        {
            if (accDetails.Address is null || accDetails.Email is null || accDetails.PhoneNumber < 1 || accDetails.AccCreationDateTime == null)
                throw new InvalidDataException("One of the values is empty or entered incorrectly");
            return _accDetailsRepository.Update(accDetails);
        }

        public AccDetails Delete(int id)
        {
            if (id < 1) throw new InvalidDataException("AccDetails Id must be higher than 0");
            return _accDetailsRepository.Delete(id);
        }
    }
}