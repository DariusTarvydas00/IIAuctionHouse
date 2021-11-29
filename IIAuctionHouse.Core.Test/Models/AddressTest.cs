using IIAuctionHouse.Core.Models;
using Xunit;

namespace IIAuctionHouse.Core.Test.Models
{
    public class AddressTest
    {
        private Address _address;

        public AddressTest()
        {
            _address = new Address();
        }

        // Checking if Address class can be initialized
        [Fact]
        public void Address_CanBeInitialized()
        {
            Assert.NotNull(_address);
        }
    }
}