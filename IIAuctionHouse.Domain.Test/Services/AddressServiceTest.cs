using System.Collections.Generic;
using System.IO;
using AuctionHouse.Domain.IRepositories;
using AuctionHouse.Domain.Services;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using Moq;
using Xunit;

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
        
        // Checks if GetById throws exception if id is 0
        [Fact]
        public void GetById_withZero_ThrowsException()
        {
            Assert.Throws<InvalidDataException>(() => _service.GetById(0));
        }

    }
}