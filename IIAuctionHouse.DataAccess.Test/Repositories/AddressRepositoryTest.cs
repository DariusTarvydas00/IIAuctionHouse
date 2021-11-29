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
using Moq;
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
        
        // Checks if GetById Returns selected AddressEntity as Object
        [Fact]
        public void GetById_Int_ReturnsAddressObject()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new AddressRepository(fakeContext);
            var list = new List<AddressEntity>()
            {
                new AddressEntity()
                {
                    Id = 4, Country = "DK", City = "Esbjerg", PostCode = 6700, StreetName = "Strandbygade",
                    StreetNumber = 30
                },
                new AddressEntity()
                {
                    Id = 5, Country = "DK", City = "Copenhagen", PostCode = 123456, StreetName = "NewStreet",
                    StreetNumber = 55
                }
            };
            fakeContext.Set<AddressEntity>().AddRange(list);
            fakeContext.SaveChanges();
            var addressEntity = list.Select(ae => new AddressEntity()
            {
                Id = ae.Id,
                Country = ae.Country,
                City = ae.City,
                PostCode = ae.PostCode,
                StreetName = ae.StreetName,
                StreetNumber = ae.StreetNumber
            }).FirstOrDefault();
            var expectedAddress = new Address()
            {
                Id = addressEntity.Id,
                Country = addressEntity.Country,
                City = addressEntity.City,
                PostCode = addressEntity.PostCode,
                StreetName = addressEntity.StreetName,
                StreetNumber = addressEntity.StreetNumber
            };
            var actual = repository.GetById(1);
            Assert.Equal(expectedAddress,actual, new Comparer());
        }
        
        // Checks if GetById returns null if Address is not existing in DbContext
        [Fact]
        public void GetById_AddressIsNullInDbContext_ReturnsNull()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new AddressRepository(fakeContext);
            var list = new List<AddressEntity>()
            {
                new AddressEntity()
            };
            fakeContext.Set<AddressEntity>().AddRange(list);
            fakeContext.SaveChanges();
            var entity = list.Find(ae => ae.Id == 1);
            var expected = new Address()
            {
                Id = entity.Id,
                Country = entity.Country,
                City = entity.City,
                PostCode = entity.PostCode,
                StreetName = entity.StreetName,
                StreetNumber = entity.StreetNumber
            };
            var actual = repository.GetById(1);
            Assert.Equal(expected,actual, new Comparer());
        }
        
        // Checks if Address object is created
        [Fact]
        public void Create_AddressProperties_StoresNewAddress()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new AddressRepository(fakeContext);
            var fakeList = new List<AddressEntity>();
            var expected = new Address()
            {
                Country = "DK",
                City = "Esbjerg",
                PostCode = 6700,
                StreetName = "Strandbygade",
                StreetNumber = 30
            };
            fakeContext.Set<AddressEntity>().AddRange(fakeList);
            fakeContext.SaveChanges();
            var actual = repository.Create("DK", "Esbjerg", 6700, "Strandbygade", 30);
            Assert.Equal(expected,repository.Create("DK", "Esbjerg", 6700, "Strandbygade", 30),new Comparer());
        }
        
        // Checks if Address object is updated
        [Fact]
        public void Update_AddressObject_IsUpdated()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new AddressRepository(fakeContext);
            var list = new List<AddressEntity>()
            {
                new AddressEntity()
                {
                    Id = 1, Country = "DK", City = "Esbjerg", PostCode = 6700, StreetName = "Strandbygade",
                    StreetNumber = 30
                }
            };
            fakeContext.Set<AddressEntity>().AddRange(list);
            fakeContext.SaveChanges();
            var expected = new Address()
            {
                Id = 1, Country = "DK", City = "Copenhagen", PostCode = 123456, StreetName = "NewStreet",
                StreetNumber = 55
            };
            fakeContext.ChangeTracker.Clear();
            var actual = repository.Update(expected);
            Assert.Equal(expected,actual, new Comparer());
        }
        
        // Checks if Delete method deletes object from DB
        [Fact]
        public void Delete_Id_ReturnsNull()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new AddressRepository(fakeContext);
            var list = new List<AddressEntity>()
            {
                new AddressEntity() {Id = 1, Country = "DK", City = "Copenhagen", PostCode = 123456, StreetName = "NewStreet",
                StreetNumber = 55}
            };
            fakeContext.Set<AddressEntity>().AddRange(list);
            fakeContext.SaveChanges();
            fakeContext.ChangeTracker.Clear();
            var actual = repository.Delete(1);
            var expected = new Address()
            {
                Id = 1
            };
            Assert.Equal(expected,actual,new Comparer());
        }

        private class Comparer: IEqualityComparer<Address>
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