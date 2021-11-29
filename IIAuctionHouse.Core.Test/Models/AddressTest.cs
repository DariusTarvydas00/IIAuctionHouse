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

        #region Id property Test

        // Checking if Id property exists
        [Fact]
        public void Address_Id_Exists()
        {
            Assert.True(_address.GetType().GetProperty("Id") != null);
        }

        #endregion

        #region Country property Test

        // Checking if Country property exists
        [Fact]
        public void Address_Country_Exists()
        {
            Assert.True(_address.GetType().GetProperty("Country") != null);
        }

        #endregion

        #region City property Test

        // Checking if City property exists
        [Fact]
        public void Address_City_Exists()
        {
            Assert.True(_address.GetType().GetProperty("City") != null);
        }
        
        #endregion

        #region PostCode property Test

        // Checking if PostCode property exists
        [Fact]
        public void Address_PostCode_Exists()
        {
            Assert.True(_address.GetType().GetProperty("PostCode") != null);
        }

        #endregion

        #region StreetName property Test

        // Checking if StreetName property exists
        [Fact]
        public void Address_StreetName_Exists()
        {
            Assert.True(_address.GetType().GetProperty("StreetName") != null);
        }

        #endregion

        #region StreetNumber property Test

        // Checking if StreetNumber property exists
        [Fact]
        public void Address_StreetNumber_Exists()
        {
            Assert.True(_address.GetType().GetProperty("StreetNumber") != null);
        }

        #endregion
    }
}