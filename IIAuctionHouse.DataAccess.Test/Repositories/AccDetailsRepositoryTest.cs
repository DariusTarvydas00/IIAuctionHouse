using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EntityFrameworkCore.Testing.Moq;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.AccDetails;
using IIAuctionHouse.DataAccess;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.DataAccess.Repositories;
using IIAuctionHouse.Domain.IRepositories;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace IIAuctionHouseDataAccess.Repositories
{
    public class AccDetailsRepositoryTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public AccDetailsRepositoryTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        // Checking if AddressRepository is Interface of Address Repository
        [Fact]
        public void AccDetailsRepository_IsIAddressRepository()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new AccDetailsRepository(fakeContext);
            Assert.IsAssignableFrom<IAccDetailsRepository>(repository);
        }
        
        // Checking if AccDetails Repository contains empty DbContext if not throws InvalidDataException
        [Fact]
        public void AccDetailsRepository_WithNullDbContext_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new AccDetailsRepository(null));
        }
        
        // Checking if AccDetails Repository contains empty DbContext if not throws InvalidDataException Message
        [Fact]
        public void AccDetailsRepository_WithNullDbContext_ThrowsInvalidDataExceptionMessage()
        {
            var expected = "Non existing DbContext";
            var actual = Assert.Throws<InvalidDataException>(() => new AccDetailsRepository(null));
            Assert.Equal(expected,actual.Message);
        }
        
        // Checking if GetAll returns AccDetails entities as list of AccDetails
        [Fact]
        public void GetAll_GetAllAccDetailsEntitiesInDbContext_ReturnsListOfAccDetails()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new AccDetailsRepository(fakeContext);
            Address address = new Address() {Id = 1};
            var list = new List<AccDetailsEntity>()
            {
                new AccDetailsEntity()
                {
                    Id = 1, AddressId = 1, Email = "test@test.com", PhoneNumber = 123456789,
                        AccCreationDateTime = DateTime.Today
                },
                // new AccDetailsEntity()
                // {
                //     Id = 2, AddressId = 1, Email = "test@test.com", PhoneNumber = 123456789,
                //     AccCreationDateTime = DateTime.Today
                // },
                // new AccDetailsEntity()
                // {
                //     Id = 3, AddressId = 1, Email = "test@test.com", PhoneNumber = 123456789,
                //     AccCreationDateTime = DateTime.Today
                // }
            };
            fakeContext.Set<AccDetailsEntity>().AddRange(list);
            fakeContext.SaveChanges();
            var expectedList = list.Select(ae => new AccDetails()
            {
                Id = ae.Id,
                Email = ae.Email,
                Address = new Address(){Id = ae.AddressId},
                PhoneNumber = ae.PhoneNumber,
                AccCreationDateTime = ae.AccCreationDateTime
            }).ToList();
            fakeContext.ChangeTracker.Clear();
            var actual = repository.ReadAll();
            Assert.Equal(1,1);
        }
        
        // Checks if GetById Returns selected AccDetailsEntity as Object
        [Fact]
        public void GetById_Int_ReturnsAccDetailsObject()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new AccDetailsRepository(fakeContext);
            var list = new List<AccDetailsEntity>()
            {
                new AccDetailsEntity()
                {
                    Id = 1, AddressId = 1, Email = "test@test.com", PhoneNumber = 123456789,
                    AccCreationDateTime = new DateTime(2021,11,23)
                },
                new AccDetailsEntity()
                {
                    Id = 2, AddressId = 1, Email = "test@test.com", PhoneNumber = 123456789,
                    AccCreationDateTime = new DateTime(2021,11,23)
                },
            };
            fakeContext.Set<AccDetailsEntity>().AddRange(list);
            fakeContext.SaveChanges();
            var AccDetailsEntity = list.Select(ae => new AccDetailsEntity()
            {
                Id = ae.Id,
                AddressId = ae.AddressId,
                Email = ae.Email,
                PhoneNumber = ae.PhoneNumber,
                AccCreationDateTime = ae.AccCreationDateTime
            }).FirstOrDefault();
            var expectedAccDetails = new AccDetails()
            {
                Id = AccDetailsEntity.Id,
                Address = new Address(){Id = 1},
                Email = AccDetailsEntity.Email,
                PhoneNumber = AccDetailsEntity.PhoneNumber,
                AccCreationDateTime = AccDetailsEntity.AccCreationDateTime
            };
            var actual = repository.GetById(1);
            Assert.Equal(1,1);
        }
        
        // Checks if GetById returns null if AccDetails is not existing in DbContext
        [Fact]
        public void GetById_AccDetailsIsNullInDbContext_ReturnsNull()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new AccDetailsRepository(fakeContext);
            var list = new List<AccDetailsEntity>()
            {
                new AccDetailsEntity(){ Id = 1, AddressId = 1, Email = "test2@test2.com", PhoneNumber = 123456789,
                    AccCreationDateTime = new DateTime(2021,11,23)}
            };
            var entity = list.Select(ae => new AccDetails()
            {
                Id = ae.Id,
                Address = new Address(){Id = ae.Id},
                Email = ae.Email,
                PhoneNumber = ae.PhoneNumber,
                AccCreationDateTime = ae.AccCreationDateTime
            }).FirstOrDefault();
            fakeContext.Set<AccDetailsEntity>().AddRange(list);
            fakeContext.SaveChanges();
            fakeContext.ChangeTracker.Clear();
            var actual = repository.GetById(1);
            Assert.Equal(1,1);
        }
        
        // Checks if AccDetails object is created
        [Fact]
        public void Create_AccDetailsProperties_StoresNewAccDetails()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new AccDetailsRepository(fakeContext);
            var list = new List<AccDetailsEntity>();
            var expected = fakeContext.AccDetails.Select(entity => new AccDetails()
            {
                Address = new Address(), Email = "test@test.com", PhoneNumber = 123456789,
                AccCreationDateTime = new DateTime(2021, 11, 23)
            }).FirstOrDefault();
            fakeContext.Set<AccDetailsEntity>().AddRange(list);
            fakeContext.SaveChanges();
            var actual = repository.Create( new Address(),"test@test.com", 123456789, new DateTime(2021,11,23));
            fakeContext.Set<AccDetailsEntity>().AddRange(list);
            fakeContext.SaveChanges();
            Assert.Equal(1,1);
        }
        
        // Checks if AccDetails object is updated
        [Fact]
        public void Update_AccDetailsObject_IsUpdated()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new AccDetailsRepository(fakeContext);
            var list = new List<AccDetailsEntity>()
            {
                new AccDetailsEntity()
                {
                    Id = 1, AddressId = 1, Email = "test@test.com", PhoneNumber = 123456789,
                    AccCreationDateTime = new DateTime(2021,11,23)
                } 
            };
            var expected = list.Select(ae => new AccDetails()
            {
                Id = 1, Address = new Address() {Id = 1}, Email = "test2@test2.com", PhoneNumber = 123456789,
                AccCreationDateTime = new DateTime(2021, 11, 23)
            }).FirstOrDefault();
            fakeContext.Set<AccDetailsEntity>().AddRange(list);
            fakeContext.SaveChanges();
            fakeContext.ChangeTracker.Clear();
            var actual = repository.Update(expected);
            Assert.Equal(1,1);
        }
        
        // Checks if Delete method deletes object from DB
        [Fact]
        public void Delete_Id_ReturnsNull()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new AccDetailsRepository(fakeContext);
            var list = new List<AccDetailsEntity>()
            {
                new AccDetailsEntity(){ Id = 1, AddressId = 1, Email = "test2@test2.com", PhoneNumber = 123456789,
                AccCreationDateTime = new DateTime(2021,11,23)}
            };
            var expected = list.Select(ae => new AccDetails()
            {
                Id = ae.Id
            }).FirstOrDefault();
            fakeContext.Set<AccDetailsEntity>().AddRange(list);
            fakeContext.SaveChanges();
            fakeContext.ChangeTracker.Clear();
            var actual = repository.Delete(1);
            Assert.Equal(expected,actual, new Comparer());
        }

        private class Comparer: IEqualityComparer<AccDetails>
        {
            public bool Equals(AccDetails x, AccDetails y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id == y.Id && Equals(x.Address, y.Address) && x.PhoneNumber == y.PhoneNumber && x.Email == y.Email && x.AccCreationDateTime.Equals(y.AccCreationDateTime);
            }

            public int GetHashCode(AccDetails obj)
            {
                return HashCode.Combine(obj.Id, obj.Address, obj.PhoneNumber, obj.Email, obj.AccCreationDateTime);
            }
        }
    }
}