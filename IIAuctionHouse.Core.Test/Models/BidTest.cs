using System;
using IIAuctionHouse.Core.Models;
using Xunit;

namespace IIAuctionHouse.Core.Test.Models
{
    public class BidTest
    {
         private Bid _bid;

        public BidTest()
        {
            _bid = new Bid();
        }

        // Checking if Bid class can be initialized
        [Fact]
        public void Bid_CanBeInitialized()
        {
            Assert.NotNull(_bid);
        }

        #region Id property Test

        // Checking if Id property exists
        [Fact]
        public void Bid_Id_Exists()
        {
            Assert.True(_bid.GetType().GetProperty("Id") != null);
        }
        
        // Checking if Id is integer type
        [Fact]
        public void Id_NoParam_isInt()
        {
            Assert.True(_bid.Id is int);
        }
        
        // Checking if SetId stores Id
        [Fact]
        public void Id_SetUpdateId_StoresUpdatesId()
        {
            _bid.Id = 1;
            Assert.Equal(1,_bid.Id);
            _bid.Id = 2;
            Assert.Equal(2, _bid.Id);
        }

        #endregion


        #region BidAmount property Test

        // Checking if BidAmount property exists
        [Fact]
        public void Bid_BidAmount_Exists()
        {
            Assert.True(_bid.GetType().GetProperty("BidAmount") != null);
        }
        
        // Checking if BidAmount is int type
        [Fact]
        public void BidAmount_NoParam_isInt()
        {
            Assert.True(_bid.BidAmount is int);
        }
        
        // Checking if BidAmount stores value and updates to new one
        [Fact]
        public void BidAmount_SetUpdateBidAmount_StoresUpdatesBidAmount()
        {
            _bid.BidAmount = 7601;
            Assert.Equal(7601, _bid.BidAmount);
            _bid.BidAmount = 7600;
            Assert.Equal(7600, _bid.BidAmount);
        }

        #endregion


        #region BidDateTime property Test

        // Checking if BidDateTime property exists
        [Fact]
        public void Bid_BidDateTime_Exists()
        {
            Assert.True(_bid.GetType().GetProperty("BidDateTime") != null);
        }
        
        // Checking if BidDateTime is int type
        [Fact]
        public void BidDateTime_NoParam_isInt()
        {
            Assert.True(_bid.BidDateTime is DateTime);
        }
        
        // Checking if BidDateTime property stores and updates new value
        [Fact]
        public void BidDateTime_SetUpdateBidDateTime_StoresUpdatesBidDateTime()
        {
            var date = DateTime.Today;
            _bid.BidDateTime = date;
            Assert.Equal(date, _bid.BidDateTime);
            var newDate = new DateTime(2021, 12, 01);
            _bid.BidDateTime = newDate;
            Assert.Equal(newDate, _bid.BidDateTime);
        }
 
        #endregion
    }
}