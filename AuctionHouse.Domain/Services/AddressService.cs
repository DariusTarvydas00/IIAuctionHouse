using System.Collections.Generic;
using System.IO;
using AuctionHouse.Domain.IRepositories;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;

namespace AuctionHouse.Domain.Services
{
    public class AddressService: IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository ?? throw new InvalidDataException("Address Service can not be null");
        }

        public List<Address> ReadAll()
        {
            throw new System.NotImplementedException();
        }

        public Address GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Address Create(string country, string city, int postCode, string streetName, int streetNumber)
        {
            throw new System.NotImplementedException();
        }

        public Address Update(Address address)
        {
            throw new System.NotImplementedException();
        }

        public Address Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}