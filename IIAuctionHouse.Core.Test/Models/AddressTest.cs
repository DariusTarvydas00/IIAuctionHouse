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
            Assert.True(_address.GetType().GetProperty("Id") != null);
            Assert.True(_address.GetType().GetProperty("Country") != null);
            Assert.True(_address.GetType().GetProperty("City") != null);
            Assert.True(_address.GetType().GetProperty("PostCode") != null);
            Assert.True(_address.GetType().GetProperty("StreetName") != null);
            Assert.True(_address.GetType().GetProperty("StreetNumber") != null);
        }

        // Checking if Id, PostCode, Street Number is integer value type
        [Fact]
        public void IdPostCodeStreetNumber_NoParam_isIntegerType()
        {
#pragma warning disable 183
            Assert.True(_address.Id is int);
            Assert.True(_address.PostCode is int);
            Assert.True(_address.StreetNumber is int);
#pragma warning restore 183
        }
        
        // Checking if SetId stores Id, PostCode, StreetNumber
        [Fact]
        public void IdPostCodeStreetNumber_SetIdPostCodeStreetNumber_StoresIdPostCodeStreetNumberValues()
        {
            Assert.Equal(1,_address.Id);
            Assert.Equal(1067, _address.PostCode);
            Assert.Equal(30,_address.StreetNumber);
        }
        
        // Checking if Id, PostCode, StreetNumber stores values and updates to new one
        [Fact]
        public void IdPostCodeStreetNumber_UpdateIdPostCodeStreetNumber_StoresNewValues()
        {
            _address.Id = 2;
            Assert.Equal(2,_address.Id);
            _address.PostCode = 1068;
            Assert.Equal(1068, _address.PostCode);
            _address.StreetNumber = 31;
            Assert.Equal(31,_address.StreetNumber);
        }

        // Checking if Country, City, StreetName is string value type
        [Fact]
        public void Address_CountryCityStreetName_IsStringValueType()
        {
            Assert.True(_address.Country is string);
            Assert.True(_address.City is string);
            Assert.True(_address.StreetName is string);
        }

        // Checking if  Country, City, StreetName value is stored
        [Fact]
        public void CountryCityStreetName_SetCountryCityStreetName_StoresCountryCityStreetNameValues()
        {
            Assert.Equal("DK", _address.Country);
            Assert.Equal("Copenhagen", _address.City);
            Assert.Equal("Old Street Name", _address.StreetName);
        }

        // Checking if  Country, City, StreetName stores values and updates to new one
        [Fact]
        public void StreetName_SetUpdateStreetName_StoresUpdatesStreetName()
        {
            _address.Country = "LT";
            Assert.Equal("LT", _address.Country);
            _address.City = "Vilnius";
            Assert.Equal("Vilnius", _address.City);
            _address.StreetName = "New Street Name";
            Assert.Equal("New Street Name", _address.StreetName);
        }
    }
}