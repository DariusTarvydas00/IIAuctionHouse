using System.Collections;
using System.Collections.Generic;
using System.IO;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.Domain.Services
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
            if (address.Country is null || address.City is null || address.PostCode < 1 || address.StreetName is null ||
                address.StreetNumber < 1)
                throw new InvalidDataException("One of the values is empty or entered incorrectly");
            return _addressRepository.Update(address);
        }

        public Address Delete(int id)
        {
            if (id < 1) throw new InvalidDataException("Address Id must be higher than 0");
            return _addressRepository.Delete(id);
        }
    }
}