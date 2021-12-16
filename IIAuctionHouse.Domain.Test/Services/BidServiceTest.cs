using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using IIAuctionHouse.Core.Domain.IRepositories;
using IIAuctionHouse.Core.Domain.Services;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
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
            var expected = "Bid Repository failure";
            var actual = Assert.Throws<InvalidDataException>(() => new BidService(null));
            Assert.Equal(expected,actual.Message);
        }
        
        // Checks if ReadAll method calls BidRepository only one time
        [Fact]
        public void ReadAll_CallsBidRepositoryReadAll_ExactlyOnce()
        {
            _service.GetAllBids();
            _mock.Verify(r=>r.ReadAll(), Times.Once);
        }
        
        // Checks if ReadAll method returns list of Bides
        [Fact]
        public void ReadAll_NoFilter_ReturnsListOfBides()
        {
            _mock.Setup(r => r.ReadAll()).Returns(_expected);
            var actual = _service.GetAllBids();
            Assert.Equal(_expected,actual);
        }
        
        // Checks if GetById throws exception if id is less than 1
        [Fact]
        public void GetById_withZeroOrLess_ThrowsException()
        {
            Assert.Throws<InvalidDataException>(() => _service.GetBidById(0));
            Assert.Throws<InvalidDataException>(() => _service.GetBidById(-5));
        }
        
        // Checks if GetById  throws exception message if id is less than 1
        [Fact]
        public void GetById_withZeroOrLess_ThrowsExceptionMessage()
        {
            var expected = "Bid Id is invalid";
            var actual = Assert.Throws<InvalidDataException>(() => _service.GetBidById(0));
            Assert.Equal(expected,actual.Message);
            var actual2 = Assert.Throws<InvalidDataException>(() => _service.GetBidById(-5));
            Assert.Equal(expected,actual2.Message);
        }
        
        // Checks if GetById with null throws exception
        [Theory]
        [InlineData(null)]
        public void GetById_Null_ThrowsException(int value)
        {
            Assert.Throws<InvalidDataException>(() => _service.GetBidById(value));
        }
        
        // Checks if GetById with null throws exception message
        [Theory]
        [InlineData(null)]
        public void GetById_Null_ThrowsExceptionMessage(int value)
        {
            var expected = "Bid Id is invalid";
            var actual = Assert.Throws<InvalidDataException>(() => _service.GetBidById(value));
            Assert.Equal(expected,actual.Message);
        }
        
        // Checks if Creating Bid Object is possible
        [Theory]
        [ClassData(typeof(TestCreateDataClass))]
        public void Create_WithNull_ThrowsExceptionWithMessage(int bidAmount, DateTime bidDateTime, string expected)
        {
            var actual = Assert.Throws<InvalidDataException>(() =>
                _service.CreateBid(new Bid(){BidAmount = bidAmount, BidDateTime = bidDateTime}));
            Assert.Equal(expected,actual.Message);
            Assert.Equal(expected,actual.Message);
        }

        // Checks if Updating Object is possible
        [Theory]
        [ClassData(typeof(TestCreateDataClass))]
        public void Update_WithNull_ThrowsExceptionWithMessage(int bidAmount, DateTime bidDateTime, string expected)
        {
            var actual  = Assert.Throws<InvalidDataException>(() => _service.UpdateBid(new Bid()
            {
                BidAmount = bidAmount,
                BidDateTime = bidDateTime
            }));
            Assert.Equal(expected,actual.Message);
        }
        
        // Check if Delete Method throws exception
        [Theory]
        [InlineData(null)]
        public void Delete_Null_ThrowsException(int value)
        {
            Assert.Throws<InvalidDataException>(() => _service.DeleteBid(value));
        }
        
        // Checks if Delete with null throws exception message
        [Theory]
        [InlineData(null)]
        public void Delete_Null_ThrowsExceptionMessage(int value)
        {
            const string expected = "Bid Id is invalid";
            var actual = Assert.Throws<InvalidDataException>(() => _service.DeleteBid(value));
            Assert.Equal(expected,actual.Message);
        }
        
        [Fact]
        public void Delete_Int_DeletesCustomerDetails()
        {
            Assert.Null(_service.DeleteBid(1));
        }
        
        private class TestCreateDataClass : IEnumerable<object[]>
        {
            static string expected1 = "Bid Amount is invalid";
            static string expected2 = "Bid Date Time is invalid";
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] {null, new DateTime(2017, 3, 1), expected1 },
                new object[] {7000, null, expected2},
            };

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

    }
}