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

        // Checking if Id, PhoneNumber, Email, Address, AccCreationDateTime properties exists
        [Fact]
        public void AccDetails_Properties_Exists()
        {
            Assert.True(_accDetails.GetType().GetProperty("Id") != null);
            Assert.True(_accDetails.GetType().GetProperty("PhoneNumber") != null);
            Assert.True(_accDetails.GetType().GetProperty("Email") != null);
            Assert.True(_accDetails.GetType().GetProperty("Address") != null);
            Assert.True(_accDetails.GetType().GetProperty("AccCreationDateTime") != null);
        }

        // Checking if Id, PhoneNumber is integer value type
        [Fact]
        public void IdPostCodeStreetNumber_NoParam_isIntegerType()
        {
#pragma warning disable 183
            Assert.True(_accDetails.Id is int);
            Assert.True(_accDetails.PhoneNumber is int);
#pragma warning restore 183
        }
        
        // Checking if Id and PhoneNumber values are stored
        [Fact]
        public void IdPhoneNumber_SetIdPhoneNumber_StoresValues()
        {
            Assert.Equal(1,_accDetails.Id);
            Assert.Equal(123456789, _accDetails.PhoneNumber);
        }
        
        // Checking if Id and PhoneNumber stores new values
        [Fact]
        public void IdPhoneNumber_SetIdPhoneNumber_StoresNewValues()
        {
            _accDetails.Id = 2;
            Assert.Equal(2, _accDetails.Id);
            _accDetails.PhoneNumber = 987654321;
            Assert.Equal(987654321,_accDetails.PhoneNumber);
        }

        // Checking if Email property is string value type
        [Fact]
        public void Email_NoParam_IsString()
        {
            Assert.True(_accDetails.Email is string);
        }

        // Checking if Email property value is stored
        [Fact]
        public void Email_SetEmail_StoresEmail()
        {
            Assert.Equal("test@test.com", _accDetails.Email);
            _accDetails.Email = "test2@test2.com";
            Assert.Equal("test2@test2.com", _accDetails.Email);
        }
        
        // Checking if Email new value is stored
        [Fact]
        public void Email_SetEmail_StoresNewValue()
        {
            _accDetails.Email = "test2@test2.com";
            Assert.Equal("test2@test2.com", _accDetails.Email);
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

        // Checking if DateTime property is DateTime type
        [Fact]
        public void DateTime_IsDateTimeType()
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

    }
}