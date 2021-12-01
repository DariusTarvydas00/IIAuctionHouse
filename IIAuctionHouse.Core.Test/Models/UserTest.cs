using IIAuctionHouse.Core.Models;
using Xunit;

namespace IIAuctionHouse.Core.Test.Models
{
    public class UserTest
    {
         private User _User;

        public UserTest()
        {
            _User = new User();
        }

        // Checking if User class can be initialized
        [Fact]
        public void User_CanBeInitialized()
        {
            Assert.NotNull(_User);
        }

        #region Id property Test

        // Checking if Id property exists
        [Fact]
        public void User_Id_Exists()
        {
            Assert.True(_User.GetType().GetProperty("Id") != null);
        }
        
        // Checking if Id is integer type
        [Fact]
        public void Id_NoParam_isInt()
        {
            Assert.True(_User.Id is int);
        }
        
        // Checking if SetId stores Id
        [Fact]
        public void Id_SetUpdateId_StoresUpdatesId()
        {
            _User.Id = 1;
            Assert.Equal(1,_User.Id);
            _User.Id = 2;
            Assert.Equal(2, _User.Id);
        }

        #endregion

        #region FirstName property Test

        // Checking if FirstName property exists
        [Fact]
        public void User_FirstName_Exists()
        {
            Assert.True(_User.GetType().GetProperty("FirstName") != null);
        }
        
        // Checking if FirstName property value is stored and if it is string value type and updates to new value
        [Fact]
        public void FirstName_SetUpdateFirstName_StoresUpdatesFirstName()
        {
            _User.FirstName = "IamAdmin";
            Assert.True(_User.FirstName is string);
            Assert.Equal("IamAdmin", _User.FirstName);
            _User.FirstName = "IamReallyAdmin";
            Assert.Equal("IamReallyAdmin", _User.FirstName);
        }

        #endregion

        #region LastName property Test

        // Checking if LastName property exists
        [Fact]
        public void User_LastName_Exists()
        {
            Assert.True(_User.GetType().GetProperty("LastName") != null);
        }
        
        // Checking if LastName property value is stored, is string value type, is updated to new one
        [Fact]
        public void LastName_SetUpdateLastName_StoresUpdatesLastName()
        {
            _User.LastName = "NotAdmin";
            Assert.True(_User.LastName is string);
            Assert.Equal("NotAdmin", _User.LastName);
            _User.LastName = "Admin";
            Assert.Equal("Admin", _User.LastName);
        }

        #endregion

        #region Address property Test

        // Checking if Address property exists
        [Fact]
        public void User_Address_Exists()
        {
            Assert.True(_User.GetType().GetProperty("Address") != null);
        }
        
        #endregion

        #region Proprietary property Test

        // Checking if StreetName property exists
        [Fact]
        public void User_Proprietary_Exists()
        {
            Assert.True(_User.GetType().GetProperty("Proprietary") != null);
        }

        #endregion

        #region Bid property Test

        // Checking if StreetNumber property exists
        [Fact]
        public void User_Bid_Exists()
        {
            Assert.True(_User.GetType().GetProperty("Bid") != null);
        }
 
        #endregion
    }
}