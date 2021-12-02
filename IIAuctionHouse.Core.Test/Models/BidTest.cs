using System;
using IIAuctionHouse.Core.Models;
using Xunit;

namespace IIAuctionHouse.Core.Test.Models
{
    public class BidTest
    {
         private readonly Bid _bid;

        public BidTest()
        {
            _bid = new Bid()
            {
                Id = 1,
                BidAmount = 7601,
                BidDateTime = DateTime.Today
            };
        }

        // Checks if Bid class can be initialized
        [Fact]
        public void Bid_CanBeInitialized()
        {
            Assert.NotNull(_bid);
        }
        
        # region Id Property Test
        
        [Fact]
        // Check if Id property exists
        public void Id_Exists()
        {
            Assert.True(_bid.GetType().GetProperty("Id") != null);
        }
        // Check if Id is integer value type
        [Fact]
        public void Id_isIntegerType()
        {
            Assert.True(_bid.Id is int);
        }
        
        // Checking if Id value is stored
        [Fact]
        public void Id_SetId_StoresId()
        {
            Assert.Equal(1,_bid.Id);
        }
        
        // Checking if Id value is updated
        [Fact]
        public void Id_UpdateId_StoresNewIdValues()
        {
            _bid.Id = 2;
            Assert.Equal(2,_bid.Id);
        }
        
        #endregion
        
        # region BidAmount Property Test
        
        [Fact]
        // Check if BidAmount property exists
        public void BidAmount_Exists()
        {
            Assert.True(_bid.GetType().GetProperty("BidAmount") != null);
        }
        // Check if BidAmount is integer value type
        [Fact]
        public void BidAmount_isIntegerType()
        {
            Assert.True(_bid.BidAmount is int);
        }
        
        // Checking if BidAmount value is stored
        [Fact]
        public void BidAmount_SetBidAmount_StoresBidAmount()
        {
            Assert.Equal(7601,_bid.BidAmount);
        }
        
        // Checking if BidAmount value is updated
        [Fact]
        public void BidAmount_UpdateBidAmount_StoresNewBidAmountValues()
        {
            _bid.BidAmount = 7000;
            Assert.Equal(7000,_bid.BidAmount);
        }
        
        #endregion

        #region BidDateTime Property Test

        // Checks if Id, BidAmount BidDateTime, Bids property exists
        [Fact]
        public void Bid_Exists()
        {
            Assert.True(_bid.GetType().GetProperty("BidDateTime") != null);
        }
        
        // Checks if BidDateTime is DatTime type value
        [Fact]
        public void BidDateTime_NoParam_IsDateTimeType()
        {
            Assert.True(_bid.BidDateTime is DateTime);
        }
        
        // Checks if BidDateTime stores value
        [Fact]
        public void BidDateTime_SetBidDateTime_StoresValue()
        {
            Assert.Equal(DateTime.Today, _bid.BidDateTime);
        }
        
        // Checks Id BidDateTime new value is stored
        [Fact]
        public void BidDateTime_SetBidDateTime_StoresNewValue()
        {
            var expected = _bid.BidDateTime = new DateTime(2021, 12, 01);
            Assert.Equal(expected, _bid.BidDateTime);
        }

        #endregion

    }
}