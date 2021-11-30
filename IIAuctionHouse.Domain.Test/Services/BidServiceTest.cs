using System;
using System.Collections.Generic;
using System.IO;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Domain.IRepositories;
using IIAuctionHouse.Domain.Services;
using Moq;
using Xunit;

namespace IIAuctionHouse.Domain.Test.Services
{
    public class BidServiceTest
    {
        private readonly BidService _service;
        private readonly Mock<IBidRepository> _mock;
        private readonly List<Bid> _expected;

        public BidServiceTest()
        {
            _mock = new Mock<IBidRepository>();
            _service = new BidService(_mock.Object);
            _expected = new List<Bid>()
            {
                new Bid()
                {
                    Id = 1,
                    BidAmount = 7000,
                    BidDateTime = DateTime.Now
                },
                new Bid()
                {
                    Id = 2,
                    BidAmount = 8000,
                    BidDateTime = DateTime.Today
                }
            };
        }

        // Checking if Service is Using Interface
        [Fact]
        public void BidService_IsIBidService()
        {
            Assert.True(_service is IBidService);
        }
        
        // Checking throw exception if IBidService is null
        [Fact]
        public void BidService_WithNullRepositoryException_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new BidService(null));
        }

        [Fact]
        public void BidService_WithNullRepositoryException_ThrowsInvalidDataExceptionMessage()
        {
            var expected = "Bid Service can not be null";
            var actual = Assert.Throws<InvalidDataException>(() => new BidService(null));
            Assert.Equal(expected,actual.Message);
        }
        
        // Checks if ReadAll method calls BidRepository only one time
        [Fact]
        public void ReadAll_CallsBidRepositoryReadAll_ExactlyOnce()
        {
            _service.ReadAll();
            _mock.Verify(r=>r.ReadAll(), Times.Once);
        }
        
        // Checks if ReadAll method returns list of Bides
        [Fact]
        public void ReadAll_NoFilter_ReturnsListOfBides()
        {
            _mock.Setup(r => r.ReadAll()).Returns(_expected);
            var actual = _service.ReadAll();
            Assert.Equal(_expected,actual);
        }
        
        // Checks if GetById throws exception if id is less than 1
        [Fact]
        public void GetById_withZeroOrLess_ThrowsException()
        {
            Assert.Throws<InvalidDataException>(() => _service.GetById(0));
            Assert.Throws<InvalidDataException>(() => _service.GetById(-5));
        }
        
        // Checks if GetById  throws exception message if id is less than 1
        [Fact]
        public void GetById_withZeroOrLess_ThrowsExceptionMessage()
        {
            var expected = "Bid Id must be higher than 0";
            var actual = Assert.Throws<InvalidDataException>(() => _service.GetById(0));
            Assert.Equal(expected,actual.Message);
            var actual2 = Assert.Throws<InvalidDataException>(() => _service.GetById(-5));
            Assert.Equal(expected,actual2.Message);
        }
        
        // Checks if GetById with null throws exception
        [Theory]
        [InlineData(null)]
        public void GetById_Null_ThrowsException(int value)
        {
            Assert.Throws<InvalidDataException>(() => _service.GetById(value));
        }
        
        // Checks if GetById with null throws exception message
        [Theory]
        [InlineData(null)]
        public void GetById_Null_ThrowsExceptionMessage(int value)
        {
            var expected = "Bid Id must be higher than 0";
            var actual = Assert.Throws<InvalidDataException>(() => _service.GetById(value));
            Assert.Equal(expected,actual.Message);
        }
        // Checks if Creating Bid Object is possible
        [Theory]
        [InlineData(null, null)]
        [InlineData(7000, null)]
        public void Create_WithNull_ThrowsExceptionWithMessage(int bidAmount, DateTime bidDateTime)
        {
            var expected = "One of the values is empty or entered incorrectly";
            var actual = Assert.Throws<InvalidDataException>(() =>
                _service.Create(bidAmount,bidDateTime));
            Assert.Equal(expected,actual.Message);
        }
         
        // Checks if Updating Object is possible
        [Fact]
        public void Update_WithNull_ThrowsExceptionWithMessage()
        {
            var fakeList = new List<Bid>();
            fakeList.Add(new Bid() {Id = 0, BidAmount = 6700, BidDateTime = DateTime.Today});
            var update1 = new Bid() {Id = 0, BidAmount = 6700};
            var update2 = new Bid() {Id = 0, BidDateTime = DateTime.Today};
            var expected = "One of the values is empty or entered incorrectly";
            var actual1 = Assert.Throws<InvalidDataException>(() => _service.Update(update1));
            var actual2 = Assert.Throws<InvalidDataException>(() => _service.Update(update2));
            Assert.Equal(expected,actual1.Message);
            Assert.Equal(expected,actual2.Message);
        }
        
        // Check if Delete Method throws exception
        [Theory]
        [InlineData(null)]
        public void Delete_Null_ThrowsException(int value)
        {
            Assert.Throws<InvalidDataException>(() => _service.Delete(value));
        }
        
        // Checks if Delete with null throws exception message
        [Theory]
        [InlineData(null)]
        public void Delete_Null_ThrowsExceptionMessage(int value)
        {
            var expected = "Bid Id must be higher than 0";
            var actual = Assert.Throws<InvalidDataException>(() => _service.Delete(value));
            Assert.Equal(expected,actual.Message);
        }

    }
}