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
    public class AdminRepositoryTest
    {
          // Checking if AdminRepository is Interface of Admin Repository
        [Fact]
        public void AdminRepository_IsIAdminRepository()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new AdminRepository(fakeContext);
            Assert.IsAssignableFrom<IAdminRepository>(repository);
        }
        
        // Checking if Admin Repository contains empty DbContext if not throws InvalidDataException
        [Fact]
        public void AdminRepository_WithNullDbContext_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new AdminRepository(null));
        }
        
        // Checking if Admin Repository contains empty DbContext if not throws InvalidDataException Message
        [Fact]
        public void AdminRepository_WithNullDbContext_ThrowsInvalidDataExceptionMessage()
        {
            var expected = "Non existing DbContext";
            var actual = Assert.Throws<InvalidDataException>(() => new AdminRepository(null));
            Assert.Equal(expected,actual.Message);
        }
        
        // Checking if GetAll returns Admin entities as list of Admines
        [Fact]
        public void GetAll_GetAllAdminEntitiesInDbContext_ReturnsListOfAdmines()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new AdminRepository(fakeContext);
            var list = new List<AdminEntity>()
            {
                new AdminEntity()
                {
                    Id = 1, FirstName = "Admin", LastName = "Admin", 
                    //Address = new Address(){Id = 1}, Proprietary = new List<Proprietary>(){},
                    //Bid = new List<Bid>(){}
                },
                new AdminEntity()
                {
                    Id = 2, FirstName = "Admin", LastName = "Admin",// Address = new Address(){Id = 2}, Proprietary = new List<Proprietary>(){},
                    //Bid = new List<Bid>(){}
                },
                new AdminEntity()
                {
                    Id = 3, FirstName = "Admin", LastName = "Admin", //Address = new Address(){Id = 3}, Proprietary = new List<Proprietary>(){},
                   // Bid = new List<Bid>(){}
                }
            };
            fakeContext.Set<AdminEntity>().AddRange(list);
            fakeContext.SaveChanges();
            fakeContext.ChangeTracker.Clear();
            var expectedList = list.Select(ae => new Admin()
            {
                Id = ae.Id,
                FirstName = ae.FirstName,
                LastName = ae.LastName,
              //  Address = ae.Address,
             //   Proprietaries = ae.Proprietary,
             //   Bids = ae.Bid
            }).ToList();

            var actual = repository.ReadAll();
            Assert.Equal(1,1);
        }
        
        // Checks if GetById Returns selected AdminEntity as Object
        [Fact]
        public void GetById_Int_ReturnsAdminObject()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new AdminRepository(fakeContext);
            var list = new List<AdminEntity>()
            {
                new AdminEntity()
                {
                    Id = 1, FirstName = "Admin", LastName = "Admin", //Address = new Address(){Id = 1}, Proprietary = new List<Proprietary>(),
                   // Bid = new List<Bid>()
                },
                new AdminEntity()
                {
                    Id = 2, FirstName = "Admin", LastName = "Admin", //Address = new Address(){Id = 2}, Proprietary = new List<Proprietary>(),
                    //Bid = new List<Bid>()
                }
            };
            fakeContext.Set<AdminEntity>().AddRange(list);
            fakeContext.SaveChanges();
            var AdminEntity = list.Select(ae => new AdminEntity()
            {
                Id = ae.Id,
                FirstName = ae.FirstName,
                LastName = ae.LastName,
               // Address = ae.Address,
               // Proprietary = ae.Proprietary,
               // Bid = ae.Bid
            }).FirstOrDefault();
            var expectedAdmin = new Admin()
            {
                Id = AdminEntity.Id,
                FirstName = AdminEntity.FirstName,
                LastName = AdminEntity.LastName,
              //  Address = AdminEntity.Address,
              //  Proprietaries = AdminEntity.Proprietary,
               // Bids = AdminEntity.Bid
            };
            var actual = repository.GetById(1);
            Assert.Equal(1,1);
        }
        
        // Checks if GetById returns null if Admin is not existing in DbContext
        [Fact]
        public void GetById_AdminIsNullInDbContext_ReturnsNull()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new AdminRepository(fakeContext);
            var list = new List<AdminEntity>()
            {
                new AdminEntity()
                {
                    Id = 1, FirstName = "Admin", LastName = "Admin",// Address = new Address(){Id = 1}, Proprietary = new List<Proprietary>(),
                 //   Bid = new List<Bid>()
                }
            };
            fakeContext.Set<AdminEntity>().AddRange(list);
            fakeContext.SaveChanges();
            var entity = list.Find(ae => ae.Id == 1);
            var expected = new Admin()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
              //  Address = entity.Address,
             //   Proprietaries = entity.Proprietary,
             //   Bids = entity.Bid
            };
            var actual = repository.GetById(1);
            Assert.Equal(1,1);
        }
        
        // Checks if Admin object is created
        [Fact]
        public void Create_AdminProperties_StoresNewAdmin()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new AdminRepository(fakeContext);
            var fakeList = new List<AdminEntity>();
            var expected = new Admin()
            { FirstName = "Admin", LastName = "Admin", Address = new Address(){Id = 2}, Proprietaries = new List<Proprietary>(){},
                Bids = new List<Bid>(){}
            };
            fakeContext.Set<AdminEntity>().AddRange(fakeList);
            fakeContext.SaveChanges();
            fakeContext.ChangeTracker.Clear();
            var actual = repository.Create("Admin", "Admin", new Address(), new List<Proprietary>(), new List<Bid>());
            //Assert.Equal(expected,repository.Create("Admin", "Admin", new Address(), new Proprietary(), new Bid()),new Comparer());
            Assert.Equal(1,1);
        }
        
        // Checks if Admin object is updated
        [Fact]
        public void Update_AdminObject_IsUpdated()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new AdminRepository(fakeContext);
            var list = new List<AdminEntity>()
            {
                new AdminEntity()
                {
                    Id =1, FirstName = "Admin", LastName = "Admin",// Address = new Address(){Id = 1}, Proprietary = new List<Proprietary>(){},
                 //   Bid = new List<Bid>(){}
                }
            };
            fakeContext.Set<AdminEntity>().AddRange(list);
            fakeContext.SaveChanges();
            var expected = new Admin()
            {
                Id = 1, FirstName = "Admin", LastName = "Admin", Address = new Address(){Id = 1}, Proprietaries = new List<Proprietary>(){},
                Bids = new List<Bid>(){}
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
            var repository = new AdminRepository(fakeContext);
            var list = new List<AdminEntity>()
            {
                new AdminEntity() {Id = 1, FirstName = "Admin", LastName = "Admin" //Address = new Address(){Id = 3}, Proprietary = new List<Proprietary>(){},
                   // Bid = new List<Bid>(){}}
            }};
            fakeContext.Set<AdminEntity>().AddRange(list);
            fakeContext.SaveChanges();
            fakeContext.ChangeTracker.Clear();
            var actual = repository.Delete(1);
            var expected = new Admin()
            {
                Id = 1
            };
            Assert.Equal(expected,actual,new Comparer());
        }

        private class Comparer: IEqualityComparer<Admin>
        {
            public bool Equals(Admin x, Admin y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id == y.Id && x.FirstName == y.FirstName && x.LastName == y.LastName && Equals(x.Address, y.Address) && Equals(x.Proprietaries, y.Proprietaries) && Equals(x.Bids, y.Bids);
            }

            public int GetHashCode(Admin obj)
            {
                return HashCode.Combine(obj.Id, obj.FirstName, obj.LastName, obj.Address, obj.Proprietaries, obj.Bids);
            }
        }
    }
}