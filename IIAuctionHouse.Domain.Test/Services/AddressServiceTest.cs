﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using AuctionHouse.Domain.IRepositories;
using AuctionHouse.Domain.Services;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using Moq;
using Xunit;
using Xunit.Sdk;

namespace IIAuctionHouse.Domain.Test.Services
{
    public class AddressServiceTest
    {
        private readonly AddressService _service;
        private readonly Mock<IAddressRepository> _mock;
        private readonly List<Address> _expected;

        public AddressServiceTest()
        {
            _mock = new Mock<IAddressRepository>();
            _service = new AddressService(_mock.Object);
            _expected = new List<Address>()
            {
                new Address()
                {
                    Id = 1,
                    Country = "Denmark",
                    City = "Esbjerg",
                    PostCode = 6700,
                    StreetName = "Strandbygade",
                    StreetNumber = 30
                },
                new Address()
                {
                    Id = 2,
                    Country = "Denmark",
                    City = "Esbjerg",
                    PostCode = 6700,
                    StreetName = "Skolegade",
                    StreetNumber = 20
                }
            };
        }

        // Checking if Service is Using Interface
        [Fact]
        public void AddressService_IsIAddressService()
        {
            Assert.True(_service is IAddressService);
        }
        
        // Checking throw exception if IAddressService is null
        [Fact]
        public void AddressService_WithNullRepositoryException_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new AddressService(null));
        }

        [Fact]
        public void AddressService_WithNullRepositoryException_ThrowsInvalidDataExceptionMessage()
        {
            var expected = "Address Service can not be null";
            var actual = Assert.Throws<InvalidDataException>(() => new AddressService(null));
            Assert.Equal(expected,actual.Message);
        }
        
        // Checks if ReadAll method calls AddressRepository only one time
        [Fact]
        public void ReadAll_CallsAddressRepositoryReadAll_ExactlyOnce()
        {
            _service.ReadAll();
            _mock.Verify(r=>r.ReadAll(), Times.Once);
        }
        
        // Checks if ReadAll method returns list of Addresses
        [Fact]
        public void ReadAll_NoFilter_ReturnsListOfAddresses()
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
            var expected = "Address Id must be higher than 0";
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
            var expected = "Address Id must be higher than 0";
            var actual = Assert.Throws<InvalidDataException>(() => _service.GetById(value));
            Assert.Equal(expected,actual.Message);
        }

    }
}