using System.Collections.Generic;
using System.Data;
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
            return _addressRepository.ReadAll();
        }

        public Address GetById(int id)
        {
            if (id < 1) throw new InvalidDataException("Address Id must be higher than 0");
            return _addressRepository.GetById(id);
        }

        public Address Create(string country, string city, int postCode, string streetName, int streetNumber)
        {
            if (country is null || city is null || postCode < 1 || streetName is null || streetNumber < 1)
                throw new InvalidDataException("One of the values is empty or entered incorrectly"); 
            return _addressRepository.Create(country, city, postCode, streetName, streetNumber);
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