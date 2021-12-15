using System;
using System.Collections.Generic;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.AccDetails;
using IIAuctionHouse.DataAccess.Entities;

namespace IIAuctionHouse.DataAccess
{
    public class DbSeeder
    {
        private readonly MainDbContext _ctx;

        public DbSeeder(MainDbContext ctx)
        {
            _ctx = ctx;
        }

        public void SeedDevelopment()
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();
            _ctx.Addresses.Add(new AddressEntity() {Country = "addressEntity1", City = "addressEntity1", PostCode = 1,
                StreetName = "addressEntity", StreetNumber = 1
            });
            _ctx.Addresses.Add(new AddressEntity() {Country = "addressEntity2", City = "addressEntity2", PostCode = 2,
                StreetName = "addressEntity2", StreetNumber = 2
            });
            _ctx.Addresses.Add(new AddressEntity() {Country = "addressEntity3", City = "addressEntity3", PostCode = 3,
                StreetName = "addressEntity3", StreetNumber = 3
            });
            _ctx.AccDetails.Add(new AccDetailsEntity()
            {
                Email = "accDetailsEntity1",
                PhoneNumber = 1,
                AccCreationDateTime = DateTime.Today,
                // Address = new Address()
                // {
                //     Country = "address1", City = "address1", PostCode = 1, StreetName = "address1",
                //     StreetNumber = 1
                // }
            });
            _ctx.AccDetails.Add(new AccDetailsEntity()
            {
                Email = "accDetailsEntity2",
                PhoneNumber = 2,
                AccCreationDateTime = DateTime.Today,
                // Address = new Address()
                // {
                //     Country = "address2", City = "address2", PostCode = 2, StreetName = "address2",
                //     StreetNumber = 2
                // }
            });
            _ctx.AccDetails.Add(new AccDetailsEntity()
            {
                Email = "accDetailsEntity3",
                PhoneNumber = 3,
                AccCreationDateTime = DateTime.Today,
                // Address = new Address()
                // {
                //     Country = "address3", City = "address3", PostCode = 3, StreetName = "address3",
                //     StreetNumber = 3
                // }
            });
            _ctx.Bids.Add(new BidEntity()
            {
                Id = 1,
                BidAmount = 3000,
                BidDateTime = DateTime.Today
            });
            _ctx.Bids.Add(new BidEntity()
            {
                Id = 2,
                BidAmount = 3000,
                BidDateTime = DateTime.Today
            });
            _ctx.Bids.Add(new BidEntity()
            {
                Id = 3,
                BidAmount = 3000,
                BidDateTime = DateTime.Today
            });
            _ctx.Proprietaries.Add(new ProprietaryEntity()
            {
                Id = 1,
                CadastreNumber = "123/123:123",
                City = "Esbjerg",
                ForestryEnterprise = "EsbjergEnterprise"
            });
            _ctx.Proprietaries.Add(new ProprietaryEntity()
            {
                Id = 2,
                CadastreNumber = "123/123:123",
                City = "Esbjerg",
                ForestryEnterprise = "EsbjergEnterprise"
            });
            _ctx.Proprietaries.Add(new ProprietaryEntity()
            {
                Id = 3,
                CadastreNumber = "123/123:123",
                City = "Esbjerg",
                ForestryEnterprise = "EsbjergEnterprise"
            });
            _ctx.SaveChanges();
        }
    }
}