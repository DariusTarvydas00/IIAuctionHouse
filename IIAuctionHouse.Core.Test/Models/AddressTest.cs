using System.Reflection.Metadata;
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
        
        // Checking if Id is integer type
        [Fact]
        public void Id_NoParam_isInt()
        {
            Assert.True(_address.Id is int);
        }
        
        // Checking if SetId stores Id
        [Fact]
        public void Id_SetId_StoresId()
        {
            _address.Id = 1;
            Assert.Equal(1,_address.Id);
        }
        
        // Checking if changing Id updates Id
        [Fact]
        public void Id_UpdateId_StoresNewId()
        {
            _address.Id = 1;
            _address.Id = 2;
            Assert.Equal(2, _address.Id);
        }

        #endregion

        #region Country property Test

        // Checking if Country property exists
        [Fact]
        public void Address_Country_Exists()
        {
            Assert.True(_address.GetType().GetProperty("Country") != null);
        }
        
        // Checking if Country property value is stored and if it is string value type
        [Fact]
        public void Country_SetCountry_StoresCountry()
        {
            _address.Country = "DK";
            Assert.True(_address.Country is string);
            Assert.Equal("DK", _address.Country);
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