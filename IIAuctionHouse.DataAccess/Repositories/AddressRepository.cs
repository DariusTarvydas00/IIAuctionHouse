using System.Collections.Generic;
using System.IO;
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