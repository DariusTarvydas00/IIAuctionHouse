using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using EntityFrameworkCore.Testing.Moq;
using IIAuctionHouse.Core.Domain.IRepositories;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.DataAccess;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.DataAccess.Repositories;
using Xunit;

namespace IIAuctionHouseDataAccess.Repositories
{
    public class BidRepositoryTest
    {
         // Checking if BidRepository is Interface of Bid Repository
        [Fact]
        public void BidRepository_IsIBidRepository()
        {
            var fakeContext = Create.MockedDbContextFor<AuctionHouseDbContext>();
            var repository = new BidRepository(fakeContext);
            Assert.IsAssignableFrom<IBidRepository>(repository);
        }
         
        // Checking if Bid Repository contains empty DbContext if not throws InvalidDataException
        [Fact]
        public void BidRepository_WithNullDbContext_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new BidRepository(null));
        }
        
        // Checking if Bid Repository contains empty DbContext if not throws InvalidDataException Message
        [Fact]
        public void BidRepository_WithNullDbContext_ThrowsInvalidDataExceptionMessage()
        {
            var expected = "Non existing DbContext";
            var actual = Assert.Throws<InvalidDataException>(() => new BidRepository(null));
            Assert.Equal(expected,actual.Message);
        }
        
        // Checking if GetAll returns Bid entities as list of Bids
        [Fact]
        public void GetAll_GetAllBidsInDbContext_ReturnsListOfBides()
        {
            var fakeContext = Create.MockedDbContextFor<AuctionHouseDbContext>();
            var repository = new BidRepository(fakeContext);
            var list = new List<BidEntity>()
            {
                new BidEntity()
                {
                    Id = 1, BidAmount = 7000, BidDateTime = DateTime.Today
                },
                new BidEntity()
                {
                    Id = 2, BidAmount = 8000, BidDateTime = DateTime.Today
                },
                new BidEntity()
                {
                    Id = 3, BidAmount = 10000, BidDateTime = DateTime.Today
                }
            };
            fakeContext.Set<BidEntity>().AddRange(list);
            fakeContext.SaveChanges();
            var expectedList = list.Select(ae => new Bid()
            {
                Id = ae.Id,
                BidAmount = ae.BidAmount,
                BidDateTime = ae.BidDateTime
            }).ToList();

            var actual = repository.ReadAll();
            Assert.Equal(expectedList, actual, new Comparer());
        }
        
        // Checks if GetById Returns selected BidEntity as Object
        [Fact]
        public void GetById_Int_ReturnsBidObject()
        {
            var fakeContext = Create.MockedDbContextFor<AuctionHouseDbContext>();
            var repository = new BidRepository(fakeContext);
            var list = new List<BidEntity>()
            {
                new BidEntity() {BidAmount = 20000, BidDateTime = DateTime.Today},
                new BidEntity() {BidAmount = 40000, BidDateTime = DateTime.Today}
            };
            fakeContext.Set<BidEntity>().AddRange(list);
            fakeContext.SaveChanges();
            var bidEntity = fakeContext.Bids.Select(ae => new BidEntity()
            {
                Id = ae.Id,
                BidAmount = ae.BidAmount,
                BidDateTime = ae.BidDateTime
            }).FirstOrDefault();
            Debug.Assert(bidEntity != null, nameof(bidEntity) + " != null");
            var expectedBid = new Bid()
            {
                Id = bidEntity.Id,
                BidAmount = bidEntity.BidAmount,
                BidDateTime = bidEntity.BidDateTime
            };
            var actual = repository.ReadById(1);
            Assert.Equal(expectedBid,actual, new Comparer());
        }
        
        // Checks if GetById returns null if Bid is not existing in DbContext
        [Fact]
        public void GetById_BidIsNullInDbContext_ReturnsNull()
        {
            var fakeContext = Create.MockedDbContextFor<AuctionHouseDbContext>();
            var repository = new BidRepository(fakeContext);
            var list = new List<BidEntity>()
            {
                new BidEntity() { BidAmount = 20000, BidDateTime = DateTime.Today },
                new BidEntity() { BidAmount = 40000, BidDateTime = DateTime.Today }
            };
            fakeContext.Set<BidEntity>().AddRange(list);
            fakeContext.SaveChanges();
            var entity = fakeContext.Bids.First();
            var expected = new Bid()
            {
                Id = entity.Id,
                BidAmount = entity.BidAmount,
                BidDateTime = entity.BidDateTime
            };
            var actual = repository.ReadById(1);
            Assert.Equal(expected,actual, new Comparer());
            var actual1 = repository.ReadById(10);
            Assert.Null(actual1);
        }
        
        // Checks if Bid object is created
        [Fact]
        public void Create_BidProperties_StoresNewBid()
        {
            var fakeContext = Create.MockedDbContextFor<AuctionHouseDbContext>();
            var repository = new BidRepository(fakeContext);
            var fakeList = new List<BidEntity>()
            {
                new BidEntity(){ Id = 1, BidAmount = 20000, BidDateTime = DateTime.Today}
            };
            fakeContext.Set<BidEntity>().AddRange(fakeList);
            fakeContext.SaveChanges();
            var expected = new Bid()
            {
                Id = 2,
                BidAmount = 40000,
                BidDateTime = DateTime.Today
            };
            var actual = repository.Create(expected);
            Assert.Equal(expected,actual,new Comparer());
        }
        
        // Checks if Bid object is updated
        [Fact]
        public void Update_BidObject_IsUpdated()
        {
            var fakeContext = Create.MockedDbContextFor<AuctionHouseDbContext>();
            var repository = new BidRepository(fakeContext);
            var list = new List<BidEntity>()
            {
                new BidEntity()
                {
                    Id = 1, 
                    BidAmount = 40000, 
                    BidDateTime = DateTime.Today
                }
            };
            fakeContext.Set<BidEntity>().AddRange(list);
            fakeContext.SaveChanges();
            var expected = new Bid()
            {
                Id = 1, 
                BidAmount = 50000, 
                BidDateTime = DateTime.Today
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
            var repository = new BidRepository(fakeContext);
            var list = new List<BidEntity>()
            {
                new BidEntity() {BidAmount = 40000, 
                BidDateTime = DateTime.Today
                }
            };
            fakeContext.Set<BidEntity>().AddRange(list);
            fakeContext.SaveChanges();
            fakeContext.ChangeTracker.Clear();
            var actual = repository.Delete(1);
            var expected = new Bid()
            {
                Id = 1
            };
            Assert.Equal(expected,actual,new Comparer());
        }

        private class Comparer: IEqualityComparer<Bid>
        {
            public bool Equals(Bid x, Bid y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id == y.Id && x.BidAmount == y.BidAmount && x.BidDateTime.Equals(y.BidDateTime);
            }

            public int GetHashCode(Bid obj)
            {
                return HashCode.Combine(obj.Id, obj.BidAmount, obj.BidDateTime);
            }
        }
    }
}