using System;
using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Domain.IRepositories
{
    public interface IAccDetailsRepository
    {
        List<AccDetails> ReadAll();
        AccDetails GetById(int id);
        AccDetails Create(Address address, string email, int phoneNumber, DateTime accCreationDate);
        AccDetails Update(AccDetails accDetails);
        AccDetails Delete(int id); 
    }
}