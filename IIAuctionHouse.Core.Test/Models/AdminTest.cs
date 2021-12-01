using IIAuctionHouse.Core.Models;
using Xunit;

namespace IIAuctionHouse.Core.Test.Models
{
    public class AdminTest
    {
        private Admin _Admin;

        public AdminTest()
        {
            _Admin = new Admin();
        }

        // Checking if Admin class can be initialized
        [Fact]
        public void Admin_CanBeInitialized()
        {
            Assert.NotNull(_Admin);
        }

        #region Id property Test

        // Checking if Id property exists
        [Fact]
        public void Admin_Id_Exists()
        {
            Assert.True(_Admin.GetType().GetProperty("Id") != null);
        }

        // Checking if Id is integer type
        [Fact]
        public void Id_NoParam_isInt()
        {
            Assert.True(_Admin.Id is int);
        }

        // Checking if SetId stores Id
        [Fact]
        public void Id_SetUpdateId_StoresUpdatesId()
        {
            _Admin.Id = 1;
            Assert.Equal(1, _Admin.Id);
            _Admin.Id = 2;
            Assert.Equal(2, _Admin.Id);
        }

        #endregion

        #region FirstName property Test

        // Checking if FirstName property exists
        [Fact]
        public void Admin_FirstName_Exists()
        {
            Assert.True(_Admin.GetType().GetProperty("FirstName") != null);
        }

        // Checking if FirstName property value is stored and if it is string value type and updates to new value
        [Fact]
        public void FirstName_SetUpdateFirstName_StoresUpdatesFirstName()
        {
            _Admin.FirstName = "IamAdmin";
            Assert.True(_Admin.FirstName is string);
            Assert.Equal("IamAdmin", _Admin.FirstName);
            _Admin.FirstName = "IamReallyAdmin";
            Assert.Equal("IamReallyAdmin", _Admin.FirstName);
        }

        #endregion

        #region LastName property Test

        // Checking if LastName property exists
        [Fact]
        public void Admin_LastName_Exists()
        {
            Assert.True(_Admin.GetType().GetProperty("LastName") != null);
        }

        // Checking if LastName property value is stored, is string value type, is updated to new one
        [Fact]
        public void LastName_SetUpdateLastName_StoresUpdatesLastName()
        {
            _Admin.LastName = "NotAdmin";
            Assert.True(_Admin.LastName is string);
            Assert.Equal("NotAdmin", _Admin.LastName);
            _Admin.LastName = "Admin";
            Assert.Equal("Admin", _Admin.LastName);
        }

        #endregion

        #region Address property Test

        // Checking if Address property exists
        [Fact]
        public void Admin_Address_Exists()
        {
            Assert.True(_Admin.GetType().GetProperty("Address") != null);
        }

        #endregion

        #region Proprietary property Test

        // Checking if StreetName property exists
        [Fact]
        public void Admin_Proprietary_Exists()
        {
            Assert.True(_Admin.GetType().GetProperty("Proprietary") != null);
        }

        #endregion

        #region Bid property Test

        // Checking if StreetNumber property exists
        [Fact]
        public void Admin_Bid_Exists()
        {
            Assert.True(_Admin.GetType().GetProperty("Bid") != null);
        }

        #endregion
    }
}