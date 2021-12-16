using System;
using IIAuctionHouse.Core.Models;
using Xunit;

namespace IIAuctionHouse.Core.Test.Models
{
    public class CustomerDetailsTest
    {
        private readonly CustomerDetails _customerDetails;

        public CustomerDetailsTest()
        {
            _customerDetails = new CustomerDetails()
            {
                Id = 1,
                Country = "DK",
                City = "Copenhagen",
                PostCode = 1067,
                StreetName = "Old Street Name",
                StreetNumber = 30,
                PhoneNumber = 123456789,
                Email = "test@test.com",
                AccCreationDateTime = DateTime.Today
            };
        }

        // Checking if CustomerDetails class can be initialized
        [Fact]
        public void CustomerDetails_CanBeInitialized()
        {
            Assert.NotNull(_customerDetails);
        }
        
        # region Id Property Test
        
        [Fact]
        // Check if Id property exists
        public void Id_Exists()
        {
            Assert.True(_customerDetails.GetType().GetProperty("Id") != null);
        }
        // Check if Id is integer value type
        [Fact]
        public void Id_isIntegerType()
        {
            Assert.True(_customerDetails.Id is int);
        }
        
        // Checking if Id value is stored
        [Fact]
        public void Id_SetId_StoresId()
        {
            Assert.Equal(1,_customerDetails.Id);
        }
        
        // Checking if Id value is updated
        [Fact]
        public void Id_UpdateId_StoresNewIdValues()
        {
            _customerDetails.Id = 2;
            Assert.Equal(2,_customerDetails.Id);
        }
        
        #endregion
        
        # region Country Property Test
        
        [Fact]
        // Check if Country property exists
        public void Country_Exists()
        {
            Assert.True(_customerDetails.GetType().GetProperty("Country") != null);
        }
        // Check if Country is string value type
        [Fact]
        public void Country_isStringType()
        {
            Assert.True(_customerDetails.Country is string);
        }
        
        // Checking if Country value is stored
        [Fact]
        public void Country_SetCountry_StoresCountry()
        {
            Assert.Equal("DK",_customerDetails.Country);
        }
        
        // Checking if Country value is updated
        [Fact]
        public void Country_UpdateCountry_StoresNewCountryValues()
        {
            _customerDetails.Country = "LT";
            Assert.Equal("LT",_customerDetails.Country);
        }
        
        #endregion
        
        # region City Property Test
        
        [Fact]
        // Check if City property exists
        public void City_Exists()
        {
            Assert.True(_customerDetails.GetType().GetProperty("City") != null);
        }
        // Check if City is string value type
        [Fact]
        public void City_isStringType()
        {
            Assert.True(_customerDetails.City is string);
        }
        
        // Checking if City value is stored
        [Fact]
        public void City_SetCity_StoresCity()
        {
            Assert.Equal("Copenhagen",_customerDetails.City);
        }
        
        // Checking if City value is updated
        [Fact]
        public void City_UpdateCity_StoresNewCityValues()
        {
            _customerDetails.City = "Esbjerg";
            Assert.Equal("Esbjerg",_customerDetails.City);
        }
        
        #endregion
        
        # region PostCode Property Test
        
        [Fact]
        // Check if PostCode property exists
        public void PostCode_Exists()
        {
            Assert.True(_customerDetails.GetType().GetProperty("PostCode") != null);
        }
        // Check if PostCode is integer value type
        [Fact]
        public void PostCode_isIntegerType()
        {
            Assert.True(_customerDetails.PostCode is int);
        }
        
        // Checking if PostCode value is stored
        [Fact]
        public void PostCode_SetPostCode_StoresPostCode()
        {
            Assert.Equal(1067,_customerDetails.PostCode);
        }
        
        // Checking if PostCode value is updated
        [Fact]
        public void PostCode_UpdatePostCode_StoresNewPostCodeValues()
        {
            _customerDetails.PostCode = 1068;
            Assert.Equal(1068,_customerDetails.PostCode);
        }
        
        #endregion
        
        # region StreetName Property Test
        
        [Fact]
        // Check if StreetName property exists
        public void StreetName_Exists()
        {
            Assert.True(_customerDetails.GetType().GetProperty("StreetName") != null);
        }
        // Check if StreetName is string value type
        [Fact]
        public void StreetName_isStringType()
        {
            Assert.True(_customerDetails.StreetName is string);
        }
        
        // Checking if StreetName value is stored
        [Fact]
        public void StreetName_SetStreetName_StoresStreetName()
        {
            Assert.Equal("Old Street Name",_customerDetails.StreetName);
        }
        
        // Checking if StreetName value is updated
        [Fact]
        public void StreetName_UpdateStreetName_StoresNewStreetNameValues()
        {
            _customerDetails.StreetName = "New Street Name";
            Assert.Equal("New Street Name",_customerDetails.StreetName);
        }
        
        #endregion
        
        # region StreetNumber Property Test
        
        [Fact]
        // Check if StreetNumber property exists
        public void StreetNumber_Exists()
        {
            Assert.True(_customerDetails.GetType().GetProperty("StreetNumber") != null);
        }
        // Check if StreetNumber is integer value type
        [Fact]
        public void StreetNumber_isIntegerType()
        {
            Assert.True(_customerDetails.StreetNumber is int);
        }
        
        // Checking if StreetNumber value is stored
        [Fact]
        public void StreetNumber_SetStreetNumber_StoresStreetNumber()
        {
            Assert.Equal(30,_customerDetails.StreetNumber);
        }
        
        // Checking if StreetNumber value is updated
        [Fact]
        public void StreetNumber_UpdateStreetNumber_StoresNewStreetNumberValues()
        {
            _customerDetails.StreetNumber = 35;
            Assert.Equal(35,_customerDetails.StreetNumber);
        }
        
        #endregion
        
        # region PhoneNumber Property Test
        
        [Fact]
        // Check if PhoneNumber property exists
        public void PhoneNumber_Exists()
        {
            Assert.True(_customerDetails.GetType().GetProperty("PhoneNumber") != null);
        }
        // Check if PhoneNumber is integer value type
        [Fact]
        public void PhoneNumber_isIntegerType()
        {
            Assert.True(_customerDetails.PhoneNumber is int);
        }
        
        // Checking if PhoneNumber value is stored
        [Fact]
        public void PhoneNumber_SetPhoneNumber_StoresPhoneNumber()
        {
            Assert.Equal(123456789,_customerDetails.PhoneNumber);
        }
        
        // Checking if PhoneNumber value is updated
        [Fact]
        public void PhoneNumber_UpdatePhoneNumber_StoresNewPhoneNumberValues()
        {
            _customerDetails.PhoneNumber = 987654321;
            Assert.Equal(987654321,_customerDetails.PhoneNumber);
        }
        
        #endregion

        # region Email Property Test
        
        [Fact]
        // Check if Email property exists
        public void Email_Exists()
        {
            Assert.True(_customerDetails.GetType().GetProperty("Email") != null);
        }
        // Check if Email is string value type
        [Fact]
        public void Email_isStringType()
        {
            Assert.True(_customerDetails.Email is string);
        }
        
        // Checking if Email value is stored
        [Fact]
        public void Email_SetEmail_StoresEmail()
        {
            Assert.Equal("test@test.com",_customerDetails.Email);
        }
        
        // Checking if Email value is updated
        [Fact]
        public void Email_UpdateEmail_StoresNewEmailValues()
        {
            _customerDetails.Email = "anotherTest@test.com";
            Assert.Equal("anotherTest@test.com",_customerDetails.Email);
        }
        
        #endregion

        #region AccCreationDate Property Test

        // Checking if AccCreationDate property exists
        [Fact]
        public void AccCreationDate_Exists()
        {
            Assert.True(_customerDetails.GetType().GetProperty("AccCreationDateTime") != null);
        }
        
        // Checking if DateTime property is DateTime type
        [Fact]
        public void AccCreationDateTime_IsDateTimeType()
        {
            Assert.True(_customerDetails.AccCreationDateTime is DateTime);
        }

        // Checking if AccCreationDateTime property value is stored
        [Fact]
        public void AccCreationDateTime_SetAccCreationDateTime_StoresDateTime()
        {
            Assert.Equal(DateTime.Today, _customerDetails.AccCreationDateTime);
        }
        
        // Checking if DateTime property new value is stored
        [Fact]
        public void AccCreationDateTime_SetAccCreationDateTime_StoresNewAccCreationDateTime()
        {
            var expected = _customerDetails.AccCreationDateTime = DateTime.Today;
            Assert.Equal(expected, _customerDetails.AccCreationDateTime);
        }
        
        #endregion
    }
}