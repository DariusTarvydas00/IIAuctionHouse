using IIAuctionHouse.Core.IServices;
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
    }
}