using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Domain.IRepositories;
using EntityFrameworkCore.Testing.Moq;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.DataAccess;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.DataAccess.Repositories;
using Xunit;

namespace IIAuctionHouseDataAccess.Repositories
{
    public class AddressRepositoryTest
    {
        // Checking if AddressRepository is Interface of Address Repository
        [Fact]
        public void AddressRepository_IsIAddressRepository()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new AddressRepository(fakeContext);
            Assert.IsAssignableFrom<IAddressRepository>(repository);
        }
        
        // Checking if address Repository contains empty DbContext if not throws InvalidDataException
        [Fact]
        public void AddressRepository_WithNullDbContext_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new AddressRepository(null));
        }
        
        // Checking if address Repository contains empty DbContext if not throws InvalidDataException Message
        [Fact]
        public void AddressRepository_WithNullDbContext_ThrowsInvalidDataExceptionMessage()
        {
            var expected = "Non existing DbContext";
            var actual = Assert.Throws<InvalidDataException>(() => new AddressRepository(null));
            Assert.Equal(expected,actual.Message);
        }
        
        // Checking if GetAll returns address entities as list of addresses
        [Fact]
        public void GetAll_GetAllAddressEntitiesInDbContext_ReturnsListOfAddresses()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new AddressRepository(fakeContext);
            var list = new List<AddressEntity>()
            {
                new AddressEntity()
                {
                    Id = 1, Country = "DK", City = "Esbjerg", PostCode = 6700, StreetName = "Strandbygade",
                    StreetNumber = 30
                },
                new AddressEntity()
                {
                    Id = 2, Country = "DK", City = "Copenhagen", PostCode = 123456, StreetName = "NewStreet",
                    StreetNumber = 55
                },
                new AddressEntity()
                {
                    Id = 3, Country = "DK", City = "Esbjerg", PostCode = 6700, StreetName = "Skolegade",
                    StreetNumber = 12
                }
            };
            fakeContext.Set<AddressEntity>().AddRange(list);
            fakeContext.SaveChanges();
            var expectedList = list.Select(ae => new Address()
            {
                Id = ae.Id,
                Country = ae.Country,
                City = ae.City,
                PostCode = ae.PostCode,
                StreetName = ae.StreetName,
                StreetNumber = ae.StreetNumber
            }).ToList();

            var actual = repository.ReadAll();
            Assert.Equal(expectedList, actual, new Comparer());
        }

        public class Comparer: IEqualityComparer<Address>
            {
                public bool Equals(Address x, Address y)
                {
                    if (ReferenceEquals(x, y)) return true;
                    if (ReferenceEquals(x, null)) return false;
                    if (ReferenceEquals(y, null)) return false;
                    if (x.GetType() != y.GetType()) return false;
                    return x.Id == y.Id && x.Country == y.Country && x.City == y.City && x.PostCode == y.PostCode && x.StreetName == y.StreetName && x.StreetNumber == y.StreetNumber;
                }

                public int GetHashCode(Address obj)
                {
                    return HashCode.Combine(obj.Id, obj.Country, obj.City, obj.PostCode, obj.StreetName, obj.StreetNumber);
                }
            }
    }
}