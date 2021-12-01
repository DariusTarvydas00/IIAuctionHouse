using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.AccDetails;
using IIAuctionHouse.DataAccess.Entities;
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
            var addressEntity = _ctx.Addresses.Select(ae => new AddressEntity()
            {
                Id = ae.Id,
                Country = ae.Country,
                City = ae.City,
                PostCode = ae.PostCode,
                StreetName = ae.StreetName,
                StreetNumber = ae.StreetNumber
            }).FirstOrDefault();
            if (addressEntity != null)
            {
                return new Address()
                {
                    Id = addressEntity.Id,
                    Country = addressEntity.Country,
                    City = addressEntity.City,
                    PostCode = addressEntity.PostCode,
                    StreetName = addressEntity.StreetName,
                    StreetNumber = addressEntity.StreetNumber
                };
            }
            return null;
        }

        public Address Create(string country, string city, int postCode, string streetName, int streetNumber)
        {
            var entity = _ctx.Addresses.Add(new AddressEntity()
            {
                Country = country,
                City = city,
                PostCode = postCode,
                StreetName = streetName,
                StreetNumber = streetNumber
            }).Entity;
            return new Address()
            {
                Country = entity.Country,
                City = entity.City,
                PostCode = entity.PostCode,
                StreetName = entity.StreetName,
                StreetNumber = entity.StreetNumber
            };
        }

        public Address Update(Address address)
        {
            var entity = _ctx.Addresses.Update(new AddressEntity()
            {
                Id = address.Id,
                Country = address.Country,
                City = address.City,
                PostCode = address.PostCode,
                StreetName = address.StreetName,
                StreetNumber = address.StreetNumber
            }).Entity;
            _ctx.SaveChanges();
            return new Address()
            {
                Id = entity.Id,
                Country = entity.Country,
                City = entity.City,
                PostCode = entity.PostCode,
                StreetName = entity.StreetName,
                StreetNumber = entity.StreetNumber
            };
        }

        public Address Delete(int id)
        {
            var entity = _ctx.Addresses.Remove(new AddressEntity()
            {
                Id = id
            }).Entity; 
            _ctx.SaveChanges();
            return new Address()
            {
                Id = entity.Id,
                Country = entity.Country,
                City = entity.City,
                PostCode = entity.PostCode,
                StreetName = entity.StreetName,
                StreetNumber = entity.StreetNumber
            };

        }
    }
}