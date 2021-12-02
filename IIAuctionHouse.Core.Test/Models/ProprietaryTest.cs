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

        // Checks if Proprietary properties exists
        [Fact]
        public void Proprietary_Properties_Exists()
        {
            Assert.True(_proprietary.GetType().GetProperty("Id") != null);
            Assert.True(_proprietary.GetType().GetProperty("CadastreNumber") != null);
            Assert.True(_proprietary.GetType().GetProperty("ForestryEnterprise") != null);
            Assert.True(_proprietary.GetType().GetProperty("City") != null);
            Assert.True(_proprietary.GetType().GetProperty("Bids") != null);
        }
        
        // Checks if Id is integer type
        [Fact]
        public void Id_NoParam_isInt()
        {
            Assert.True(_proprietary.Id is int);
        }
        
        // Checks if SetId stores value
        [Fact]
        public void Id_SetId_StoresValue()
        {
            Assert.Equal(1,_proprietary.Id);
            _proprietary.Id = 2;
            Assert.Equal(2, _proprietary.Id);
        }
        
        // Checks if SetId stores new value
        [Fact]
        public void Id_SetId_StoresNewValue()
        {
            _proprietary.Id = 2;
            Assert.Equal(2, _proprietary.Id);
        }

        // Checks if CadastreNumber, Forestry Enterprise, City is string value type
        [Fact]
        public void CadastreNumberForestryEnterpriseCity_NoParam_IsStringType()
        {
            Assert.True(_proprietary.CadastreNumber is not null);
            Assert.True(_proprietary.ForestryEnterprise is not null);
            Assert.True(_proprietary.City is not null);
        }

        // Checks if CadastreNumber, Forestry Enterprise, City stores value 
        [Fact]
        public void CadastreNumberForestryEnterpriseCity_SetCadastreNumberForestryEnterpriseCity_StoresValues()
        {
            Assert.Equal("123/123:123", _proprietary.CadastreNumber);
            Assert.Equal("Esbjerg Forestry Enterprise",_proprietary.ForestryEnterprise);
            Assert.Equal("Esbjerg",_proprietary.City);
        }

        // Checks if CadastreNumber, Forestry Enterprise, City stores new value 
        [Fact]
        public void CadastreNumberForestryEnterpriseCity_SetCadastreNumberForestryEnterpriseCity_StoresNewValues()
        {
            _proprietary.CadastreNumber = "321/321:321";
            Assert.Equal("321/321:321", _proprietary.CadastreNumber);
            _proprietary.ForestryEnterprise = "Copenhagen Forestry Enterprise";
            Assert.Equal("Copenhagen Forestry Enterprise",_proprietary.ForestryEnterprise);
            _proprietary.City = "Copenhagen";
            Assert.Equal("Copenhagen",_proprietary.City);
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

    }
}