using System.IO;
using AuctionHouse.Domain.IRepositories;
using AuctionHouse.Domain.Services;
using IIAuctionHouse.Core.IServices;
using Moq;
using Xunit;

namespace IIAuctionHouse.Domain.Test.Services
{
    public class AddressServiceTest
    {
        private readonly AddressService _service;
        private readonly Mock<IAddressRepository> _mock;

        public AddressServiceTest()
        {
            _mock = new Mock<IAddressRepository>();
            _service = new AddressService(_mock.Object);
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

    }
}