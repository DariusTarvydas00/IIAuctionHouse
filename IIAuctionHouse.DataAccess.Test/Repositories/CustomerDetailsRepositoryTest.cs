using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EntityFrameworkCore.Testing.Moq;
using IIAuctionHouse.Core.Domain.IRepositories;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.DataAccess;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.DataAccess.Repositories;
using Moq;
using Xunit;

namespace IIAuctionHouseDataAccess.Repositories
{
    public class CustomerDetailsRepositoryTest
    {
        // Checking if CustomerDetailsRepository is using Interface of CustomerDetails Repository
        [Fact]
        public void CustomerDetailsRepository_IsIAddressRepository()
        {
            var fakeContext = Create.MockedDbContextFor<AuctionHouseDbContext>();
            var repository = new CustomerDetailsRepository(fakeContext);
            Assert.IsAssignableFrom<ICustomerDetailsRepository>(repository);
        }
        
        // Checking if CustomerDetails Repository contains empty DbContext if not throws InvalidDataException
        [Fact]
        public void CustomerDetailsRepository_WithNullDbContext_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new CustomerDetailsRepository(null));
        }
        
        // Checking if CustomerDetails Repository contains empty DbContext if not throws InvalidDataException Message
        [Fact]
        public void CustomerDetailsRepository_WithNullDbContext_ThrowsInvalidDataExceptionMessage()
        {
            var expected = "Non existing DbContext";
            var actual = Assert.Throws<InvalidDataException>(() => new CustomerDetailsRepository(null));
            Assert.Equal(expected,actual.Message);
        }
        
        // Checking if GetAll returns CustomerDetails entities as list of CustomerDetails
        [Fact]
        public void GetAll_GetAllCustomerDetailsEntitiesInDbContext_ReturnsListOfCustomerDetails()
        {
            var fakeContext = Create.MockedDbContextFor<AuctionHouseDbContext>();
            var repository = new CustomerDetailsRepository(fakeContext);
            var list = new List<CustomerDetailsEntity>()
            {
                new CustomerDetailsEntity()
                {
                    Country = "DK",
                    City = "Esbjerg",
                    PostCode = 6700,
                    StreetName = "Strandbygade",
                    StreetNumber = 30,
                    PhoneNumber = 123456789,
                    Email = "test@test.com",
                    AccCreationDateTime = DateTime.Today
                }
            }.ToList();
            fakeContext.Set<CustomerDetailsEntity>().AddRange(list);
            fakeContext.SaveChanges();
            var expected = fakeContext.AllCustomerDetails.Select(entity => new CustomerDetails()
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
            }).ToList();
            var actual = repository.ReadAll();
            Assert.Equal(expected,actual, new Comparer());
        }
        
        // Checks if GetById Returns selected CustomerDetailsEntity as Object
        [Fact]
        public void GetById_Int_ReturnsCustomerDetailsObject()
        {
            var fakeContext = Create.MockedDbContextFor<AuctionHouseDbContext>();
            var repository = new CustomerDetailsRepository(fakeContext);
            var list = new List<CustomerDetailsEntity>()
            {
                new CustomerDetailsEntity()
                {
                    Country = "DK",
                    City = "Esbjerg",
                    PostCode = 6700,
                    StreetName = "Strandbygade",
                    StreetNumber = 30,
                    PhoneNumber = 123456789,
                    Email = "test@test.com",
                    AccCreationDateTime = DateTime.Today
                }
            };
            fakeContext.Set<CustomerDetailsEntity>().AddRange(list);
            fakeContext.SaveChanges();
            var expected = new CustomerDetails()
            {
                Id = 1,
                Country = "DK",
                City = "Esbjerg",
                PostCode = 6700,
                StreetName = "Strandbygade",
                StreetNumber = 30,
                PhoneNumber = 123456789,
                Email = "test@test.com",
                AccCreationDateTime = DateTime.Today
            };
            var actual1 = repository.ReadById(1);
            var actual2 = repository.ReadById(10);
            Assert.Equal(expected,actual1,new Comparer());
            Assert.Null(actual2);
        }
        
        // Checks if CustomerDetails object is created
        [Fact]
        public void Create_CustomerDetailsProperties_StoresNewCustomerDetails()
        {
            var fakeContext = Create.MockedDbContextFor<AuctionHouseDbContext>();
            var repository = new CustomerDetailsRepository(fakeContext);
            var expected = new CustomerDetails()
            {
                Id = 1,
                Country = "DK",
                City = "Esbjerg",
                PostCode = 6700,
                StreetName = "Strandbygade",
                StreetNumber = 30,
                PhoneNumber = 123456789,
                Email = "test@test.com",
                AccCreationDateTime = DateTime.Today
            };
            var actual = repository.Create(expected);
            Assert.Equal(expected,actual, new Comparer());
        }
        
        // Checks if CustomerDetails object is updated
        [Fact]
        public void Update_CustomerDetailsObject_IsUpdated()
        {
            var fakeContext = Create.MockedDbContextFor<AuctionHouseDbContext>();
            var repository = new CustomerDetailsRepository(fakeContext);
            var list = new List<CustomerDetailsEntity>()
            {
                new CustomerDetailsEntity()
                {
                    Id = 1,
                    Country = "DK",
                    City = "Esbjerg",
                    PostCode = 6700,
                    StreetName = "Strandbygade",
                    StreetNumber = 30,
                    PhoneNumber = 123456789,
                    Email = "test@test.com",
                    AccCreationDateTime = DateTime.Today
                } 
            };
            fakeContext.Set<CustomerDetailsEntity>().AddRange(list);
            fakeContext.SaveChanges();
            var expected = new CustomerDetails()
            {
                Id = 1,
                Country = "LT",
                City = "Kaunas",
                PostCode = 123456,
                StreetName = "NewStreet",
                StreetNumber = 456,
                PhoneNumber = 987654321,
                Email = "test2@test2.com",
                AccCreationDateTime = DateTime.Today
            };
            fakeContext.ChangeTracker.Clear();
            var actual = repository.Update(expected);
            Assert.Equal(expected,actual, new Comparer());
        }
        
        // Checks if Delete method deletes object from DB
        [Fact]
        public void Delete_Id_ReturnsNull()
        {
            var fakeContext = Create.MockedDbContextFor<AuctionHouseDbContext>();
            var repository = new CustomerDetailsRepository(fakeContext);
            var list = new List<CustomerDetailsEntity>()
            {
                new CustomerDetailsEntity(){ Id = 1, 
                  //  AddressId = 1, 
                    Email = "test2@test2.com", PhoneNumber = 123456789,
                AccCreationDateTime = new DateTime(2021,11,23)}
            };
            var expected = list.Select(ae => new CustomerDetails()
            {
                Id = ae.Id
            }).FirstOrDefault();
            fakeContext.Set<CustomerDetailsEntity>().AddRange(list);
            fakeContext.SaveChanges();
            fakeContext.ChangeTracker.Clear();
            var actual = repository.Delete(1);
            Assert.Equal(expected,actual, new Comparer());
        }

        private class Comparer: IEqualityComparer<CustomerDetails>
        {
            public bool Equals(CustomerDetails x, CustomerDetails y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id == y.Id && x.Country == y.Country && x.City == y.City && x.PostCode == y.PostCode && 
                       x.StreetName == y.StreetName && x.StreetNumber == y.StreetNumber && 
                       x.PhoneNumber == y.PhoneNumber && x.Email == y.Email &&
                       x.AccCreationDateTime.Equals(y.AccCreationDateTime);
            }

            public int GetHashCode(CustomerDetails obj)
            {
                var hashCode = new HashCode();
                hashCode.Add(obj.Id);
                hashCode.Add(obj.Country);
                hashCode.Add(obj.City);
                hashCode.Add(obj.PostCode);
                hashCode.Add(obj.StreetName);
                hashCode.Add(obj.StreetNumber);
                hashCode.Add(obj.PhoneNumber);
                hashCode.Add(obj.Email);
                hashCode.Add(obj.AccCreationDateTime);
                return hashCode.ToHashCode();
            }
        }
    }
}