using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Domain.IRepositories;
using IIAuctionHouse.Domain.Services;
using Microsoft.VisualBasic;
using Moq;
using Xunit;

namespace IIAuctionHouse.Domain.Test.Services
{
    public class AccDetailsServiceTest
    {
        private readonly AccDetailsService _service;
        private readonly Mock<IAccDetailsRepository> _mock;
        private readonly List<AccDetails> _expected;

        public AccDetailsServiceTest()
        {
            _mock = new Mock<IAccDetailsRepository>();
            _service = new AccDetailsService(_mock.Object);
            _expected = new List<AccDetails>()
            {
                new AccDetails()
                {
                    Id = 1,
                    Address = new Address(),
                    Email = "test2@test2.com",
                    PhoneNumber = 123456789,
                    AccCreationDateTime = new DateTime(2021,11,23)
                },
                new AccDetails()
                {
                    Id = 1,
                    Address = new Address(),
                    Email = "test@test.com",
                    PhoneNumber = 123456789,
                    AccCreationDateTime = new DateTime(2021,11,23)
                }
            };
        }

        // Checking if Service is Using Interface
        [Fact]
        public void AccDetailsService_IsIAccDetailsService()
        {
            Assert.True(_service is IAccDetailsService);
        }
        
        // Checking throw exception if IAccDetailsService is null
        [Fact]
        public void AccDetailsService_WithNullRepositoryException_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new AccDetailsService(null));
        }

        [Fact]
        public void AccDetailsService_WithNullRepositoryException_ThrowsInvalidDataExceptionMessage()
        {
            var expected = "Account Details Repository can not be null";
            var actual = Assert.Throws<InvalidDataException>(() => new AccDetailsService(null));
            Assert.Equal(expected,actual.Message);
        }
        
        // Checks if ReadAll method calls AccDetailsRepository only one time
        [Fact]
        public void ReadAll_CallsAccDetailsRepositoryReadAll_ExactlyOnce()
        {
            _service.ReadAll();
            _mock.Verify(r=>r.ReadAll(), Times.Once);
        }
        
        // Checks if ReadAll method returns list of Account Details
        [Fact]
        public void ReadAll_NoFilter_ReturnsListOfAccDetails()
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
            var expected = "AccDetails Id must be higher than 0";
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
            var expected = "AccDetails Id must be higher than 0";
            var actual = Assert.Throws<InvalidDataException>(() => _service.GetById(value));
            Assert.Equal(expected,actual.Message);
        }
        
        // Checks if Creating Address Object is possible
        [Theory]
        [InlineData(null, "test@test.com", 123456789, null)]
        [InlineData(null, null, 123456789, null)]
        [InlineData(null, "test@test.com", null, null)]
        public void Create_WithNull_ThrowsExceptionWithMessage(Address address, string email, int phoneNumber, DateTime accCreationDateTime)
        {
            var expected = "One of the values is empty or entered incorrectly";
            var actual = Assert.Throws<InvalidDataException>(() =>
                _service.Create(address, email, phoneNumber, accCreationDateTime));
            Assert.Equal(expected,actual.Message);
        }
        
        
        
        // Checks if Updating Object is possible
        [Fact]
        public void Update_WithNull_ThrowsExceptionWithMessage()
        {
            var fakeList = new List<AccDetails>();
            fakeList.Add(new AccDetails() {Id = 0, Email = "test@test.com", PhoneNumber = 123456789,
                AccCreationDateTime = new DateTime(2021,11,23)});
            var update1 = new AccDetails() {Id = 0, Address = new Address(), PhoneNumber = 123456789,
                AccCreationDateTime = new DateTime(2021,11,23)};
            var update2 = new AccDetails() {Id = 0, Address = new Address(), Email = "test@test.com"};
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
            var expected = "AccDetails Id must be higher than 0";
            var actual = Assert.Throws<InvalidDataException>(() => _service.Delete(value));
            Assert.Equal(expected,actual.Message);
        }
    }
}