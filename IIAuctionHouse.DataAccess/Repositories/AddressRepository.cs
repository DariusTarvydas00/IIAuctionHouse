using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.DataAccess.Repositories
{
    public class AddressRepository: IAddressRepository
    {
        private readonly MainDbContext _ctx;

        public AddressRepository(MainDbContext ctx)
        {
            if (ctx == null) throw new InvalidDataException("Non existing DbContext");
            _ctx = ctx;
        }

        public List<Address> ReadAll()
        {
            return _ctx.Addresses.Select(ae=>new Address()
            {
                Id = ae.Id,
                Country = ae.Country,
                City = ae.City,
                PostCode = ae.PostCode,
                StreetName = ae.StreetName,
                StreetNumber = ae.StreetNumber
            }).ToList();
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