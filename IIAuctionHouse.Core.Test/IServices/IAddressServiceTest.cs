using System.Collections.Generic;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using Moq;
using Xunit;

namespace IIAuctionHouse.Core.Test.IServices
{
    public class IAddressServiceTest
    {
        // Checking if IAddressService is available
        [Fact]
        public void IAddressService_IsAvailable()
        {
            var service = new Mock<IAddressService>();
            Assert.NotNull(service);
        }
        
        // Checking if ReadAll method return a list
        [Fact]
        public void ReadAll_NoParam_ReturnsListOfAllAddresses()
        {
            var mock = new Mock<IAddressService>();
            var fakeList = new List<Address>();
            mock.Setup(s => s.ReadAll()).Returns(fakeList);
            var service = mock.Object;
            Assert.Equal(fakeList,service.ReadAll());
        }
    }
}