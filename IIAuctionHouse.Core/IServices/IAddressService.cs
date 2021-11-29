using System.Collections;
using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.IServices
{
    public interface IAddressService
    {
        List<Address> ReadAll();
        Address GetById(int id);
        Address Create(string country, string city, int postCode, string streetName, int streetNumber);
        Address Update(Address address);
        Address Delete(int id);
    }
}