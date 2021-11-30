using IIAuctionHouse.Core.Models;
using Xunit;

namespace IIAuctionHouse.Core.Test.Models
{
    public class ProprietaryTest
    {
         private Proprietary _proprietary;

        public ProprietaryTest()
        {
            _proprietary = new Proprietary();
        }

        // Checking if Proprietary class can be initialized
        [Fact]
        public void Proprietary_CanBeInitialized()
        {
            Assert.NotNull(_proprietary);
        }

        #region Id property Test

        // Checking if Id property exists
        [Fact]
        public void Proprietary_Id_Exists()
        {
            Assert.True(_proprietary.GetType().GetProperty("Id") != null);
        }
        
        // Checking if Id is integer type
        [Fact]
        public void Id_NoParam_isInt()
        {
            Assert.True(_proprietary.Id is int);
        }
        
        // Checking if SetId stores Id
        [Fact]
        public void Id_SetUpdateId_StoresUpdatesId()
        {
            _proprietary.Id = 1;
            Assert.Equal(1,_proprietary.Id);
            _proprietary.Id = 2;
            Assert.Equal(2, _proprietary.Id);
        }

        #endregion

        #region CadastreNumber property Test

        // Checking if CadastreNumber property exists
        [Fact]
        public void Proprietary_CadastreNumber_Exists()
        {
            Assert.True(_proprietary.GetType().GetProperty("CadastreNumber") != null);
        }
        
        // Checking if CadastreNumber property value is stored and if it is string value type and updates to new value
        [Fact]
        public void CadastreNumber_SetUpdateCadastreNumber_StoresUpdatesEmail()
        {
            _proprietary.CadastreNumber = "123/123:123";
            Assert.True(_proprietary.CadastreNumber is string);
            Assert.Equal("123/123:123", _proprietary.CadastreNumber);
            _proprietary.CadastreNumber = "321/321:321";
            Assert.Equal("321/321:321", _proprietary.CadastreNumber);
        }

        #endregion

        #region ForestryEnterprise property Test

        // Checking if ForestryEnterprise property exists
        [Fact]
        public void Proprietary_ForestryEnterprise_Exists()
        {
            Assert.True(_proprietary.GetType().GetProperty("ForestryEnterprise") != null);
        }
         
        // Checking if ForestryEnterprise stores value and updates to new one
        [Fact]
        public void ForestryEnterprise_Create_StoresForestryEnterprise()
        {
            var expected = _proprietary.ForestryEnterprise = "EsbjergEnterprise";
            Assert.Equal(expected,_proprietary.ForestryEnterprise);
        }

        #endregion
        
        #region City property Test

        // Checking if City property exists
        [Fact]
        public void Proprietary_City_Exists()
        {
            Assert.True(_proprietary.GetType().GetProperty("City") != null);
        }
        
        // Checking if City stores value and updates to new one
        [Fact]
        public void City_Create_StoresForestryEnterprise()
        {
            var expected = _proprietary.City = "Esbjerg";
            Assert.Equal(expected,_proprietary.City);
        }
        
        #endregion
    }
}