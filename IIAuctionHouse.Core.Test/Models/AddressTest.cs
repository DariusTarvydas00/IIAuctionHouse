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

        #region Id parameter Test

        // Checking if Id parameter exists
        [Fact]
        public void Address_Id_Exists()
        {
            Assert.True(_address.GetType().GetProperty("Id") != null);
        }

        #endregion

        #region Country parameter Test

        // Checking if Country parameter exists
        [Fact]
        public void Address_Country_Exists()
        {
            Assert.True(_address.GetType().GetProperty("Country") != null);
        }

        #endregion

        #region City parameter Test

        // Checking if City parameter exists
        [Fact]
        public void Address_City_Exists()
        {
            Assert.True(_address.GetType().GetProperty("City") != null);
        }

        #endregion
    }
}