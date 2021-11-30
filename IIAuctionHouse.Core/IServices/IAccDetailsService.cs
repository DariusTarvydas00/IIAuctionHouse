using System;
using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.IServices
{
    public interface IAccDetailsService
    {
        List<AccDetails> ReadAll(); 
        AccDetails GetById(int id);
        AccDetails Create(Address address, string email, int phoneNumber, DateTime accCreationDate);
        AccDetails Update(AccDetails accDetails);
        AccDetails Delete(int id);
    }
}