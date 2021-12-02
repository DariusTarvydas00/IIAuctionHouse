using System;
using System.Collections.Generic;
using IIAuctionHouse.Core.Models;
using Xunit;

namespace IIAuctionHouse.Core.Test.Models
{
    public class ProprietaryTest
    {
         private readonly Proprietary _proprietary;

        public ProprietaryTest()
        {
            _proprietary = new Proprietary()
            {
                Id = 1,
                CadastreNumber = "123/123:123",
                ForestryEnterprise = "Esbjerg Forestry Enterprise",
                City = "Esbjerg",
                Bids = new List<Bid>()
                {
                    new Bid()
                    {
                        Id = 1,
                        BidAmount = 7600,
                        BidDateTime = DateTime.Today
                    }
                }
            };
        }

        // Checks if Proprietary class can be initialized
        [Fact]
        public void Proprietary_CanBeInitialized()
        {
            Assert.NotNull(_proprietary);
        }

        # region Id Property Test
        
        [Fact]
        // Check if Id property exists
        public void Id_Exists()
        {
            Assert.True(_proprietary.GetType().GetProperty("Id") != null);
        }
        // Check if Id is integer value type
        [Fact]
        public void Id_isIntegerType()
        {
            Assert.True(_proprietary.Id is int);
        }
        
        // Checking if Id value is stored
        [Fact]
        public void Id_SetId_StoresId()
        {
            Assert.Equal(1,_proprietary.Id);
        }
        
        // Checking if Id value is updated
        [Fact]
        public void Id_UpdateId_StoresNewIdValues()
        {
            _proprietary.Id = 2;
            Assert.Equal(2,_proprietary.Id);
        }
        
        #endregion
        
        # region CadastreNumber Property Test
        
        [Fact]
        // Check if CadastreNumber property exists
        public void CadastreNumber_Exists()
        {
            Assert.True(_proprietary.GetType().GetProperty("CadastreNumber") != null);
        }
        // Check if CadastreNumber is string value type
        [Fact]
        public void CadastreNumber_isIntegerType()
        {
            Assert.True(_proprietary.CadastreNumber is string);
        }
        
        // Checking if CadastreNumber value is stored
        [Fact]
        public void CadastreNumber_SetCadastreNumber_StoresCadastreNumber()
        {
            Assert.Equal("123/123:123",_proprietary.CadastreNumber);
        }
        
        // Checking if CadastreNumber value is updated
        [Fact]
        public void CadastreNumber_UpdateCadastreNumber_StoresNewCadastreNumberValues()
        {
            _proprietary.CadastreNumber = "654/654:654";
            Assert.Equal("654/654:654",_proprietary.CadastreNumber);
        }
        
        #endregion
        
        # region City Property Test
        
        [Fact]
        // Check if City property exists
        public void City_Exists()
        {
            Assert.True(_proprietary.GetType().GetProperty("City") != null);
        }
        // Check if City is string value type
        [Fact]
        public void City_isIntegerType()
        {
            Assert.True(_proprietary.City is string);
        }
        
        // Checking if City value is stored
        [Fact]
        public void City_SetCity_StoresCity()
        {
            Assert.Equal("Esbjerg",_proprietary.City);
        }
        
        // Checking if City value is updated
        [Fact]
        public void City_UpdateCity_StoresNewCityValues()
        {
            _proprietary.City = "Copenhagen";
            Assert.Equal("Copenhagen",_proprietary.City);
        }
        
        #endregion

        # region CadastreNumber Property Test
        
        [Fact]
        // Check if ForestryEnterprise property exists
        public void ForestryEnterprise_Exists()
        {
            Assert.True(_proprietary.GetType().GetProperty("ForestryEnterprise") != null);
        }
        // Check if ForestryEnterprise is string value type
        [Fact]
        public void ForestryEnterprise_isIntegerType()
        {
            Assert.True(_proprietary.ForestryEnterprise is string);
        }
        
        // Checking if ForestryEnterprise value is stored
        [Fact]
        public void ForestryEnterprise_SetForestryEnterprise_StoresForestryEnterprise()
        {
            Assert.Equal("Esbjerg Forestry Enterprise",_proprietary.ForestryEnterprise);
        }
        
        // Checking if ForestryEnterprise value is updated
        [Fact]
        public void ForestryEnterprise_UpdateForestryEnterprise_StoresNewForestryEnterpriseValues()
        {
            _proprietary.ForestryEnterprise = "Copenhagen Forestry Enterprise";
            Assert.Equal("Copenhagen Forestry Enterprise",_proprietary.ForestryEnterprise);
        }
        
        #endregion

        #region Bids Property Test

        // Checks if Proprietary property exists
        [Fact]
        public void Bids_Exists()
        {
            Assert.True(_proprietary.GetType().GetProperty("Bids") != null);
        }
        
        // Checks if Bids property is List of Bids type
        [Fact]
        public void Bid_IsListOfBids()
        {
            Assert.True(_proprietary.Bids is List<Bid>);
        }

        // Checks if Bid stores value
        [Fact]
        public void Bid_SetBid_StoresValue()
        {
            var expected = _proprietary.Bids = new List<Bid>()
            {
                new Bid()
                {
                    Id = 1,
                    BidAmount = 7600,
                    BidDateTime = DateTime.Today
                }
            };
            Assert.Equal(expected, _proprietary.Bids);
        }
        
        // Checks if Bid stores new value
        [Fact]
        public void Bid_SetBid_StoresNewValue()
        {
            var expected = _proprietary.Bids = new List<Bid>()
            {
                new Bid()
                {
                    Id = 2,
                    BidAmount = 4600,
                    BidDateTime = DateTime.Today
                }
            };
            Assert.Equal(expected, _proprietary.Bids);
        }
        
        #endregion

    }
}