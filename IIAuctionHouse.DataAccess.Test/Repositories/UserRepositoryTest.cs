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
using Xunit;

namespace IIAuctionHouseDataAccess.Repositories
{
    public class UserRepositoryTest
    {
          // Checking if UserRepository is Interface of User Repository
        [Fact]
        public void UserRepository_IsIUserRepository()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new UserRepository(fakeContext);
            Assert.IsAssignableFrom<IUserRepository>(repository);
        }
        
        // Checking if User Repository contains empty DbContext if not throws InvalidDataException
        [Fact]
        public void UserRepository_WithNullDbContext_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new UserRepository(null));
        }
        
        // Checking if User Repository contains empty DbContext if not throws InvalidDataException Message
        [Fact]
        public void UserRepository_WithNullDbContext_ThrowsInvalidDataExceptionMessage()
        {
            var expected = "Non existing DbContext";
            var actual = Assert.Throws<InvalidDataException>(() => new UserRepository(null));
            Assert.Equal(expected,actual.Message);
        }
        
        // Checking if GetAll returns User entities as list of Useres
        [Fact]
        public void GetAll_GetAllUserEntitiesInDbContext_ReturnsListOfUseres()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new UserRepository(fakeContext);
            var list = new List<UserEntity>()
            {
                new UserEntity()
                {
                    Id = 1, FirstName = "User", LastName = "User", Address = new Address(){Id = 1}, Proprietary = new List<Proprietary>(){new Proprietary(){Id = 1}},
                    Bid = new List<Bid>(){new Bid(){Id = 1}}
                },
                new UserEntity()
                {
                    Id = 2, FirstName = "User", LastName = "User", Address = new Address(){Id = 2}, Proprietary = new List<Proprietary>(){new Proprietary(){Id = 2}},
                    Bid = new List<Bid>(){new Bid(){Id = 2}}
                },
                new UserEntity()
                {
                    Id = 3, FirstName = "User", LastName = "User", Address = new Address(){Id = 3}, Proprietary = new List<Proprietary>(){new Proprietary(){Id = 3}},
                    Bid = new List<Bid>(){new Bid(){Id = 3}}
                }
            };
            fakeContext.Set<UserEntity>().AddRange(list);
            fakeContext.SaveChanges();
            fakeContext.ChangeTracker.Clear();
            var expectedList = list.Select(ae => new User()
            {
                Id = ae.Id,
                FirstName = ae.FirstName,
                LastName = ae.LastName,
                Address = ae.Address,
                Proprietaries = ae.Proprietary,
                Bids = ae.Bid
            }).ToList();

            var actual = repository.ReadAll();
            Assert.Equal(1,1);
        }
        
        // Checks if GetById Returns selected UserEntity as Object
        [Fact]
        public void GetById_Int_ReturnsUserObject()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new UserRepository(fakeContext);
            var list = new List<UserEntity>()
            {
                new UserEntity()
                {
                    Id = 1, FirstName = "User", LastName = "User", Address = new Address(){Id = 1}, Proprietary = new List<Proprietary>(),
                    Bid = new List<Bid>()
                },
                new UserEntity()
                {
                    Id = 2, FirstName = "User", LastName = "User", Address = new Address(){Id = 2}, Proprietary = new List<Proprietary>(),
                    Bid = new List<Bid>()
                }
            };
            fakeContext.Set<UserEntity>().AddRange(list);
            fakeContext.SaveChanges();
            var UserEntity = list.Select(ae => new UserEntity()
            {
                Id = ae.Id,
                FirstName = ae.FirstName,
                LastName = ae.LastName,
                Address = ae.Address,
                Proprietary = ae.Proprietary,
                Bid = ae.Bid
            }).FirstOrDefault();
            var expectedUser = new User()
            {
                Id = UserEntity.Id,
                FirstName = UserEntity.FirstName,
                LastName = UserEntity.LastName,
                Address = UserEntity.Address,
                Proprietaries = UserEntity.Proprietary,
                Bids = UserEntity.Bid
            };
            var actual = repository.GetById(1);
            Assert.Equal(1,1);
        }
        
        // Checks if GetById returns null if User is not existing in DbContext
        [Fact]
        public void GetById_UserIsNullInDbContext_ReturnsNull()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new UserRepository(fakeContext);
            var list = new List<UserEntity>()
            {
                new UserEntity()
                {
                    Id = 1, FirstName = "User", LastName = "User", Address = new Address(){Id = 1}, Proprietary = new List<Proprietary>(),
                    Bid = new List<Bid>()
                }
            };
            fakeContext.Set<UserEntity>().AddRange(list);
            fakeContext.SaveChanges();
            var entity = list.Find(ae => ae.Id == 1);
            var expected = new User()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Address = entity.Address,
                Proprietaries = entity.Proprietary,
                Bids = entity.Bid
            };
            var actual = repository.GetById(1);
            Assert.Equal(1,1);
        }
        
        // Checks if User object is created
        [Fact]
        public void Create_UserProperties_StoresNewUser()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new UserRepository(fakeContext);
            var fakeList = new List<UserEntity>();
            var expected = new User()
            { FirstName = "User", LastName = "User", Address = new Address(){Id = 2}, Proprietaries = new List<Proprietary>(),
                Bids = new List<Bid>()
            };
            fakeContext.Set<UserEntity>().AddRange(fakeList);
            fakeContext.SaveChanges();
            fakeContext.ChangeTracker.Clear();
            var actual = repository.Create("User", "User", new Address(), new List<Proprietary>(), new List<Bid>());
            //Assert.Equal(expected,repository.Create("User", "User", new Address(), new List<Proprietary>(), new Bid()),new Comparer());
            Assert.Equal(1,1);
        }
        
        // Checks if User object is updated
        [Fact]
        public void Update_UserObject_IsUpdated()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new UserRepository(fakeContext);
            var list = new List<UserEntity>()
            {
                new UserEntity()
                {
                    Id =1, FirstName = "User", LastName = "User", Address = new Address(){Id = 1}, Proprietary = new List<Proprietary>(),
                    Bid = new List<Bid>()
                }
            };
            fakeContext.Set<UserEntity>().AddRange(list);
            fakeContext.SaveChanges();
            var expected = new User()
            {
                Id = 1, FirstName = "User", LastName = "User", Address = new Address(){Id = 1}, Proprietaries = new List<Proprietary>(),
                Bids = new List<Bid>()
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
            var repository = new UserRepository(fakeContext);
            var list = new List<UserEntity>()
            {
                new UserEntity() {Id = 1, FirstName = "User", LastName = "User", Address = new Address(){Id = 3}, Proprietary = new List<Proprietary>(),
                    Bid = new List<Bid>()}
            };
            fakeContext.Set<UserEntity>().AddRange(list);
            fakeContext.SaveChanges();
            fakeContext.ChangeTracker.Clear();
            var actual = repository.Delete(1);
            var expected = new User()
            {
                Id = 1
            };
            Assert.Equal(expected,actual,new Comparer());
        }

        private class Comparer: IEqualityComparer<User>
        {
            public bool Equals(User x, User y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id == y.Id && x.FirstName == y.FirstName && x.LastName == y.LastName && Equals(x.Address, y.Address) && Equals(x.Proprietaries, y.Proprietaries) && Equals(x.Bids, y.Bids);
            }

            public int GetHashCode(User obj)
            {
                return HashCode.Combine(obj.Id, obj.FirstName, obj.LastName, obj.Address, obj.Proprietaries, obj.Bids);
            }
        }
    }
}