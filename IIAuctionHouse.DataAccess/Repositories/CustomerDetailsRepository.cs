using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.Domain.IRepositories;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.DataAccess.Entities;

namespace IIAuctionHouse.DataAccess.Repositories
{
    public class CustomerDetailsRepository: ICustomerDetailsRepository
    {
        private readonly AuctionHouseDbContext _ctx;

        public CustomerDetailsRepository(AuctionHouseDbContext ctx)
        {
            if (ctx == null) throw new InvalidDataException("Non existing DbContext");
            _ctx = ctx;
        }

        public IEnumerable<CustomerDetails> ReadAll()
        {
            return _ctx.AllCustomerDetails.Select(ae=>new CustomerDetails()
            {
                Id = ae.Id,
                Country = ae.Country,
                City = ae.City,
                PostCode = ae.PostCode,
                StreetName = ae.StreetName,
                StreetNumber = ae.StreetNumber,
                PhoneNumber = ae.PhoneNumber,
                Email = ae.Email,
                AccCreationDateTime = ae.AccCreationDateTime
            }).ToList();
        }

        public CustomerDetails ReadById(int id)
        {
            return _ctx.AllCustomerDetails.Select(ae => new CustomerDetails()
            {
                Id = ae.Id,
                Country = ae.Country,
                City = ae.City,
                PostCode = ae.PostCode,
                StreetName = ae.StreetName,
                StreetNumber = ae.StreetNumber,
                PhoneNumber = ae.PhoneNumber,
                Email = ae.Email,
                AccCreationDateTime = ae.AccCreationDateTime
            }).FirstOrDefault(i => i.Id == id);
        }

        public CustomerDetails Create(CustomerDetails customerDetails)
        {
            var entity = _ctx.AllCustomerDetails.Add(new CustomerDetailsEntity()
            {
                Country = customerDetails.Country,
                City = customerDetails.City,
                PostCode = customerDetails.PostCode,
                StreetName = customerDetails.StreetName,
                StreetNumber = customerDetails.StreetNumber,
                PhoneNumber = customerDetails.PhoneNumber,
                Email = customerDetails.Email,
                AccCreationDateTime = customerDetails.AccCreationDateTime
            }).Entity;
            return new CustomerDetails()
            {
                Id = entity.Id,
                Country = entity.Country,
                City = entity.City,
                PostCode = entity.PostCode,
                StreetName = entity.StreetName,
                StreetNumber = entity.StreetNumber,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email,
                AccCreationDateTime = entity.AccCreationDateTime
            };
        }

        public CustomerDetails Update(CustomerDetails customerDetails)
        {
            var entity = _ctx.AllCustomerDetails.Update(new CustomerDetailsEntity()
            {
                Id = customerDetails.Id,
                Country = customerDetails.Country,
                City = customerDetails.City,
                PostCode = customerDetails.PostCode,
                StreetName = customerDetails.StreetName,
                StreetNumber = customerDetails.StreetNumber,
                PhoneNumber = customerDetails.PhoneNumber,
                Email = customerDetails.Email,
                AccCreationDateTime = customerDetails.AccCreationDateTime
            }).Entity;
            _ctx.SaveChanges();
            return new CustomerDetails()
            {
                Id = entity.Id,
                Country = entity.Country,
                City = entity.City,
                PostCode = entity.PostCode,
                StreetName = entity.StreetName,
                StreetNumber = entity.StreetNumber,
                PhoneNumber = entity.PhoneNumber,
                Email = entity.Email,
                AccCreationDateTime = entity.AccCreationDateTime
            };
        }

        public CustomerDetails Delete(int id)
        {
            var entity = _ctx.AllCustomerDetails.Remove(new CustomerDetailsEntity()
            {
                Id = id
            }).Entity; 
            _ctx.SaveChanges();
            return new CustomerDetails()
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