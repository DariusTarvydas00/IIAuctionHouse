using IIAuctionHouse.Core.Models.AccDetails;
using Xunit;

namespace IIAuctionHouse.Core.Test.Models
{
    public class AddressTest
    {
        private readonly Address _address;

        public AddressTest()
        {
            _address = new Address
            {
                Id = 1,
                Country = "DK",
                City = "Copenhagen",
                PostCode = 1067,
                StreetName = "Old Street Name",
                StreetNumber = 30
            };
        }

        // Checking if Address class can be initialized
        [Fact]
        public void Address_CanBeInitialized()
        {
            Assert.NotNull(_address);
        }

        [Fact]
        // Check if Id, Country, City, PostCode, StreetName, StreetNumber properties exists
        public void Address_IdCountryCityPostCodeStreetNameStreetNumber_Exists()
        {
            Assert.True(_address.GetType().GetProperty("Country") != null);
            Assert.True(_address.GetType().GetProperty("City") != null);
            Assert.True(_address.GetType().GetProperty("StreetName") != null);
        }

        # region Id Property Test
        
        [Fact]
        // Check if Id property exists
        public void Id_Exists()
        {
            Assert.True(_address.GetType().GetProperty("Id") != null);
        }
        // Check if Id is integer value type
        [Fact]
        public void Id_isIntegerType()
        {
            Assert.True(_address.Id is int);
        }
        
        // Checking if Id value is stored
        [Fact]
        public void Id_SetId_StoresId()
        {
            Assert.Equal(1,_address.Id);
        }
        
        // Checking if Id value is updated
        [Fact]
        public void Id_UpdateId_StoresNewIdValues()
        {
            _address.Id = 2;
            Assert.Equal(2,_address.Id);
        }
        
        #endregion
        
        # region PostCode Property Test
        
        [Fact]
        // Check if PostCode property exists
        public void PostCode_Exists()
        {
            Assert.True(_address.GetType().GetProperty("PostCode") != null);
        }
        // Check if PostCode is integer value type
        [Fact]
        public void PostCode_isIntegerType()
        {
            Assert.True(_address.PostCode is int);
        }
        
        // Checking if PostCode value is stored
        [Fact]
        public void PostCode_SetPostCode_StoresPostCode()
        {
            Assert.Equal(1067,_address.PostCode);
        }
        
        // Checking if PostCode value is updated
        [Fact]
        public void PostCode_UpdatePostCode_StoresNewPostCodeValues()
        {
            _address.PostCode = 1068;
            Assert.Equal(1068,_address.PostCode);
        }
        
        #endregion
        
        # region StreetNumber Property Test
        
        [Fact]
        // Check if StreetNumber property exists
        public void StreetNumber_Exists()
        {
            Assert.True(_address.GetType().GetProperty("StreetNumber") != null);
        }
        // Check if StreetNumber is integer value type
        [Fact]
        public void StreetNumber_isIntegerType()
        {
            Assert.True(_address.StreetNumber is int);
        }
        
        // Checking if StreetNumber value is stored
        [Fact]
        public void StreetNumber_SetStreetNumber_StoresStreetNumber()
        {
            Assert.Equal(30,_address.StreetNumber);
        }
        
        // Checking if StreetNumber value is updated
        [Fact]
        public void StreetNumber_UpdateStreetNumber_StoresNewStreetNumberValues()
        {
            _address.StreetNumber = 35;
            Assert.Equal(35,_address.StreetNumber);
        }
        
        #endregion

        # region Country Property Test
        
        [Fact]
        // Check if Country property exists
        public void Country_Exists()
        {
            Assert.True(_address.GetType().GetProperty("Country") != null);
        }
        // Check if Country is string value type
        [Fact]
        public void Country_isIntegerType()
        {
            Assert.True(_address.Country is string);
        }
        
        // Checking if Country value is stored
        [Fact]
        public void Country_SetCountry_StoresCountry()
        {
            Assert.Equal("DK",_address.Country);
        }
        
        // Checking if Country value is updated
        [Fact]
        public void Country_UpdateCountry_StoresNewCountryValues()
        {
            _address.Country = "LT";
            Assert.Equal("LT",_address.Country);
        }
        
        #endregion
        
        # region City Property Test
        
        [Fact]
        // Check if City property exists
        public void City_Exists()
        {
            Assert.True(_address.GetType().GetProperty("City") != null);
        }
        // Check if City is string value type
        [Fact]
        public void City_isIntegerType()
        {
            Assert.True(_address.City is string);
        }
        
        // Checking if City value is stored
        [Fact]
        public void City_SetCity_StoresCity()
        {
            Assert.Equal("Copenhagen",_address.City);
        }
        
        // Checking if City value is updated
        [Fact]
        public void City_UpdateCity_StoresNewCityValues()
        {
            _address.City = "Esbjerg";
            Assert.Equal("Esbjerg",_address.City);
        }
        
        #endregion
        
        # region StreetName Property Test
        
        [Fact]
        // Check if StreetName property exists
        public void StreetName_Exists()
        {
            Assert.True(_address.GetType().GetProperty("StreetName") != null);
        }
        // Check if StreetName is string value type
        [Fact]
        public void StreetName_isIntegerType()
        {
            Assert.True(_address.StreetName is string);
        }
        
        // Checking if StreetName value is stored
        [Fact]
        public void StreetName_SetStreetName_StoresStreetName()
        {
            Assert.Equal("Old Street Name",_address.StreetName);
        }
        
        // Checking if StreetName value is updated
        [Fact]
        public void StreetName_UpdateStreetName_StoresNewStreetNameValues()
        {
            _address.StreetName = "New Street Name";
            Assert.Equal("New Street Name",_address.StreetName);
        }
        
        #endregion
     
    }
}