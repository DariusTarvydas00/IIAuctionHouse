using System;
using IIAuctionHouse.Core.Models.AccDetails;
using Xunit;

namespace IIAuctionHouse.Core.Test.Models
{
    public class AccDetailsTest
    {
         private readonly AccDetails _accDetails;

        public AccDetailsTest()
        {
            _accDetails = new AccDetails()
            {
                Id = 1,
                PhoneNumber = 123456789,
                Email = "test@test.com",
                Address = new Address()
                {
                    Id = 1,
                    Country = "DK",
                    City = "Copenhagen",
                    PostCode = 1067,
                    StreetName = "Old Street Name",
                    StreetNumber = 30
                },
                AccCreationDateTime = DateTime.Today
            };
        }

        // Checking if AccDetails class can be initialized
        [Fact]
        public void AccDetails_CanBeInitialized()
        {
            Assert.NotNull(_accDetails);
        }
        
        # region Id Property Test
        
        [Fact]
        // Check if Id property exists
        public void Id_Exists()
        {
            Assert.True(_accDetails.GetType().GetProperty("Id") != null);
        }
        // Check if Id is integer value type
        [Fact]
        public void Id_isIntegerType()
        {
            Assert.True(_accDetails.Id is int);
        }
        
        // Checking if Id value is stored
        [Fact]
        public void Id_SetId_StoresId()
        {
            Assert.Equal(1,_accDetails.Id);
        }
        
        // Checking if Id value is updated
        [Fact]
        public void Id_UpdateId_StoresNewIdValues()
        {
            _accDetails.Id = 2;
            Assert.Equal(2,_accDetails.Id);
        }
        
        #endregion
        
        # region PhoneNumber Property Test
        
        [Fact]
        // Check if PhoneNumber property exists
        public void PhoneNumber_Exists()
        {
            Assert.True(_accDetails.GetType().GetProperty("PhoneNumber") != null);
        }
        // Check if PhoneNumber is integer value type
        [Fact]
        public void PhoneNumber_isIntegerType()
        {
            Assert.True(_accDetails.PhoneNumber is int);
        }
        
        // Checking if PhoneNumber value is stored
        [Fact]
        public void PhoneNumber_SetPhoneNumber_StoresPhoneNumber()
        {
            Assert.Equal(1,_accDetails.PhoneNumber);
        }
        
        // Checking if PhoneNumber value is updated
        [Fact]
        public void PhoneNumber_UpdatePhoneNumber_StoresNewPhoneNumberValues()
        {
            _accDetails.PhoneNumber = 2;
            Assert.Equal(2,_accDetails.PhoneNumber);
        }
        
        #endregion

        # region Email Property Test
        
        [Fact]
        // Check if Email property exists
        public void Email_Exists()
        {
            Assert.True(_accDetails.GetType().GetProperty("Email") != null);
        }
        // Check if Email is string value type
        [Fact]
        public void Email_isIntegerType()
        {
            Assert.True(_accDetails.Email is string);
        }
        
        // Checking if Email value is stored
        [Fact]
        public void Email_SetEmail_StoresEmail()
        {
            Assert.Equal("test@test.com",_accDetails.Email);
        }
        
        // Checking if Email value is updated
        [Fact]
        public void Email_UpdateEmail_StoresNewEmailValues()
        {
            _accDetails.Email = "anotherTest@test.com";
            Assert.Equal("anotherTest@test.com",_accDetails.Email);
        }
        
        #endregion

        #region Address Property Test

        // Checking if Address property exists
        [Fact]
        public void Address_Exists()
        {
            Assert.True(_accDetails.GetType().GetProperty("Address") != null);
        }
        
        // Checking if Address value is stored
        [Fact]
        public void Address_SetAddress_StoresAddress()
        {
            var expected = new Address()
            {
                Id = 1,
                Country = "DK",
                City = "Copenhagen",
                PostCode = 1067,
                StreetName = "Old Street Name",
                StreetNumber = 30
            };
            _accDetails.Address = expected;
            Assert.Equal(expected,_accDetails.Address);
        }
        
        // Checking if Address new values is stored
        [Fact]
        public void Address_SetAddress_StoresNewAddress()
        {
            var expected = new Address()
            {
                Id = 1,
                Country = "LT",
                City = "Vilnius",
                PostCode = 1067,
                StreetName = "New Street Name",
                StreetNumber = 31
            };
            _accDetails.Address = expected;
            Assert.Equal(expected,_accDetails.Address);
        }

        #endregion

        #region AccCreationDate Property Test

        // Checking if AccCreationDate property exists
        [Fact]
        public void AccCreationDate_Exists()
        {
            Assert.True(_accDetails.GetType().GetProperty("AccCreationDate") != null);
        }
        
        // Checking if DateTime property is DateTime type
        [Fact]
        public void AccCreationDateTime_IsDateTimeType()
        {
            Assert.True(_accDetails.AccCreationDateTime is DateTime);
        }

        // Checking if AccCreationDateTime property value is stored
        [Fact]
        public void AccCreationDateTime_SetAccCreationDateTime_StoresDateTime()
        {
            Assert.Equal(DateTime.Today, _accDetails.AccCreationDateTime);
        }
        
        // Checking if DateTime property new value is stored
        [Fact]
        public void AccCreationDateTime_SetAccCreationDateTime_StoresNewAccCreationDateTime()
        {
            var expected = _accDetails.AccCreationDateTime = new DateTime(2021,11,23);
            Assert.Equal(expected, _accDetails.AccCreationDateTime);
        }

        #endregion

    }
}