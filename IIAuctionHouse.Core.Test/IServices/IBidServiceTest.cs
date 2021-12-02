using System;
using System.Collections.Generic;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using Moq;
using Xunit;

namespace IIAuctionHouse.Core.Test.IServices
{
    public class IBidServiceTest
    {
        // Checking if IBidService is available
        [Fact]
        public void IBidService_IsAvailable()
        {
            var service = new Mock<IBidService>();
            Assert.NotNull(service);
        }
        
        // Checking if ReadAll method return a list
        [Fact]
        public void ReadAll_ReturnsListOfAllBids()
        {
            var mock = new Mock<IBidService>();
            var fakeList = new List<Bid>();
            mock.Setup(s => s.ReadAll()).Returns(fakeList);
            var service = mock.Object;
            Assert.Equal(fakeList,service.ReadAll());
        }
        
        // Checking if GetById returns a Bid object
        [Fact]
        public void GetById_Id_ReturnsBid()
        {
            var mock = new Mock<IBidService>();
            var fakeList = new List<Bid>();
            var bid = new Bid()
            {
                Id = 1,
                BidAmount = 7000,
                BidDateTime = DateTime.Today
            };
            fakeList.Add(bid);
            mock.Setup(s => s.GetById(1)).Returns(fakeList.Find(a => a.Id == 1));
            var service = mock.Object;
            Assert.Equal(bid,service.GetById(1));
        }
        
        // Checking if Bid object is created
        [Fact]
        public void Create_Bid_IsCreated()
        {
            var mock = new Mock<IBidService>();
            var fakeBid = new Bid()
            {
                Id = 1,
                BidAmount = 7000,
                BidDateTime = DateTime.Today
            };
            mock.Setup(s => s.Create(It.IsAny<int>(), It.IsAny<DateTime>()))
                .Returns(() => fakeBid);
            var service = mock.Object;
            Assert.Equal(fakeBid,service.Create(7000, DateTime.Today));
        }
        
        // Checking if Bid object is updated
        [Fact]
        public void Update_Bid_IsUpdated()
        {
            var mock = new Mock<IBidService>();
            var fakeBid = new Bid()
            {
                Id = 1,
                BidAmount = 8000,
                BidDateTime = DateTime.Today
            };
            mock.Setup(s => s.Update(fakeBid)).Returns(fakeBid);
            var service = mock.Object;
            Assert.Equal(fakeBid,service.Update(fakeBid));
        }
        
        // Checks if Delete method deletes object
        [Fact]
        public void Delete_Id_ReturnNull()
        {
            var mock = new Mock<IBidService>();
            var fakeList = new List<Bid>();
            var bid = new Bid()
            { 
                Id = 1,
                BidAmount = 8000,
                BidDateTime = DateTime.Today
            };
            fakeList.Add(bid);
            mock.Setup(s => s.Delete(1)).Returns(() => null);
            var service = mock.Object;
            Assert.Null(service.Delete(1));
        }
    }
}