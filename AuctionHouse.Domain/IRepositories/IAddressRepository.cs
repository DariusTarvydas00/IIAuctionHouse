using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace AuctionHouse.Domain.IRepositories
{
    public interface IAddressRepository
    {
        List<Address> ReadAll();
        Address GetById(int id);
        Address Create(string country, string city, int postCode, string streetName, int streetNumber);
    }
}