using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.DataAccess.Repositories
{
    public class AccDetailsRepository: IAccDetailsRepository
    {
        private readonly MainDbContext _ctx;

        public AccDetailsRepository(MainDbContext ctx)
        {
            if (ctx == null) throw new InvalidDataException("Non existing DbContext");
            _ctx = ctx;
        }

        public List<AccDetails> ReadAll()
        {
            return _ctx.AccDetails.Select(ae=>new AccDetails()
            {
                Id = ae.Id,
                Address = new Address(){Id = ae.Id},
                Email = ae.Email,
                PhoneNumber = ae.PhoneNumber,
                AccCreationDateTime = ae.AccCreationDateTime
            }).ToList();
        }

        public AccDetails GetById(int id)
        {
            var addressEntity = _ctx.AccDetails.Select(ae => new AccDetails()
            {
                Id = ae.Id,
                Address = new Address(){Id = ae.Id},
                Email = ae.Email,
                PhoneNumber = ae.PhoneNumber,
                AccCreationDateTime = ae.AccCreationDateTime
            }).FirstOrDefault();
            if (addressEntity != null)
            {
                return new AccDetails()
                {
                    Id = addressEntity.Id,
                    Address = addressEntity.Address,
                    Email = addressEntity.Email,
                    PhoneNumber = addressEntity.PhoneNumber,
                    AccCreationDateTime = addressEntity.AccCreationDateTime
                };
            }
            return null;
        }

        public AccDetails Create(Address address, string email, int phoneNumber, DateTime accCreationDate)
        {
            var entity = _ctx.AccDetails.Add(new AccDetailsEntity()
            {
                AddressId = address.Id,
                Email = email,
                PhoneNumber = phoneNumber,
                AccCreationDateTime = accCreationDate
            }).Entity; 
            return new AccDetails()
            {
                Id = entity.Id,
                Address = new Address()
                {
                    Id = entity.AddressId
                },
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                AccCreationDateTime = entity.AccCreationDateTime
            };
        }

        public AccDetails Update(AccDetails accDetails)
        {
            var entity = _ctx.AccDetails.Update(new AccDetailsEntity()
            {
                Id = accDetails.Id,
                AddressId = accDetails.Id,
                Email = accDetails.Email,
                PhoneNumber = accDetails.PhoneNumber,
                AccCreationDateTime = accDetails.AccCreationDateTime
            }).Entity;
            _ctx.SaveChanges();
            return new AccDetails()
            {
                Id = entity.Id,
                Address = new Address()
                {
                    Id = entity.AddressId
                },
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                AccCreationDateTime = entity.AccCreationDateTime
            };
        }

        public AccDetails Delete(int id)
        {
            var entity = _ctx.AccDetails.Remove(new AccDetailsEntity()
            {
                Id = id
            }).Entity;
            _ctx.SaveChanges();
            return new AccDetails()
            {
                Id = entity.Id,
            };
        }
    }
}