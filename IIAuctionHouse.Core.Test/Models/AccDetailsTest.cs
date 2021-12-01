using System;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.AccDetails;
using Xunit;

namespace IIAuctionHouse.Core.Test.Models
{
    public class AccDetailsTest
    {
         private AccDetails _AccDetails;

        public AccDetailsTest()
        {
            _AccDetails = new AccDetails();
        }

        // Checking if AccDetails class can be initialized
        [Fact]
        public void AccDetails_CanBeInitialized()
        {
            Assert.NotNull(_AccDetails);
        }

        #region Id property Test

        // Checking if Id property exists
        [Fact]
        public void AccDetails_Id_Exists()
        {
            Assert.True(_AccDetails.GetType().GetProperty("Id") != null);
        }
        
        // Checking if Id is integer type
        [Fact]
        public void Id_NoParam_isInt()
        {
            Assert.True(_AccDetails.Id is int);
        }
        
        // Checking if SetId stores Id
        [Fact]
        public void Id_SetUpdateId_StoresUpdatesId()
        {
            _AccDetails.Id = 1;
            Assert.Equal(1,_AccDetails.Id);
            _AccDetails.Id = 2;
            Assert.Equal(2, _AccDetails.Id);
        }

        #endregion 
        
        #region PhoneNumber property Test

        // Checking if PhoneNUmber property exists
        [Fact]
        public void AccDetails_PhoneNumber_Exists()
        {
            Assert.True(_AccDetails.GetType().GetProperty("PhoneNumber") != null);
        }
        
        // Checking if PhoneNUmber is integer type
        [Fact]
        public void PhoneNumber_NoParam_isInt()
        {
            Assert.True(_AccDetails.PhoneNumber is int);
        }
        
        // Checking if SetPhoneNumber stores PhoneNumber
        [Fact]
        public void PhoneNumber_SetUpdatePhoneNumber_StoresUpdatesPhoneNumber()
        {
            _AccDetails.PhoneNumber = 123456;
            Assert.Equal(123456,_AccDetails.PhoneNumber);
            _AccDetails.PhoneNumber = 654321;
            Assert.Equal(654321, _AccDetails.PhoneNumber);
        }

        #endregion

        #region Email property Test

        // Checking if Email property exists
        [Fact]
        public void AccDetails_Email_Exists()
        {
            Assert.True(_AccDetails.GetType().GetProperty("Email") != null);
        }
        
        // Checking if Email property value is stored and if it is string value type and updates to new value
        [Fact]
        public void Email_SetUpdateEmail_StoresUpdatesEmail()
        {
            _AccDetails.Email = "test@test.com";
            Assert.True(_AccDetails.Email is string);
            Assert.Equal("test@test.com", _AccDetails.Email);
            _AccDetails.Email = "test2@test2.com";
            Assert.Equal("test2@test2.com", _AccDetails.Email);
        }

        #endregion

        #region DateTime property Test

        // Checking if DateTime property exists
        [Fact]
        public void AccDetails_DateTime_Exists()
        {
            Assert.True(_AccDetails.GetType().GetProperty("AccCreationDateTime") != null);
        }
        
        // Checking if DateTime property value is stored, is string value type, is updated to new one
        [Fact]
        public void DateTime_SetUpdateDateTime_StoresUpdatesDateTime()
        {
            var exected = new DateTime(2021, 11, 23);
            var actual = _AccDetails.AccCreationDateTime = new DateTime(2021,11,23);
            Assert.True(_AccDetails.AccCreationDateTime is DateTime);
            Assert.Equal(exected, actual);
            var exected2 = new DateTime(2021, 12, 01);
            var actual2 = _AccDetails.AccCreationDateTime = new DateTime(2021, 12, 01);
            Assert.Equal(exected2, actual2);
        }

        #endregion

        #region Address property Test

        // Checking if Address property exists
        [Fact]
        public void AccDetails_Address_Exists()
        {
            Assert.True(_AccDetails.GetType().GetProperty("Address") != null);
        }
        
        // Checking if Address stores value and updates to new one
        [Fact]
        public void Address_CreatesAddress_StoresAddress()
        {
            var expected = _AccDetails.Address = new Address();
            Assert.Equal(expected,_AccDetails.Address);
        }

        #endregion

       
    }
}