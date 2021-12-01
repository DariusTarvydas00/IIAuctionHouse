using System.Collections;
using System.Collections.Generic;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.AccDetails;

namespace IIAuctionHouse.Domain.IRepositories
{
    public interface IAddressRepository
    {
        List<Address> ReadAll();
        Address GetById(int id);
        Address Create(string country, string city, int postCode, string streetName, int streetNumber);
        Address Update(Address address);
        Address Delete(int id);
    } 
}