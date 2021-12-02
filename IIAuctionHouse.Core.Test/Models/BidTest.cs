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

        // Checks if Id, BidAmount BidDateTime, Bids property exists
        [Fact]
        public void Bid_Properties_Exists()
        {
            Assert.True(_bid.GetType().GetProperty("Id") != null);
            Assert.True(_bid.GetType().GetProperty("BidAmount") != null);
            Assert.True(_bid.GetType().GetProperty("BidDateTime") != null);
        }
        
        // Checks if Id, BidAmount is integer type
        [Fact]
        public void IdBidAmount_NoParam_isInt()
        {
#pragma warning disable 183
            Assert.True(_bid.Id is int);
            Assert.True(_bid.BidAmount is int);
#pragma warning restore 183
        }
        
        // Checks if Id BidAmount stores values
        [Fact]
        public void IdBid_SetIdBid_StoresValues()
        {
            Assert.Equal(1,_bid.Id);
            Assert.Equal(7601, _bid.BidAmount);
        }
        
        // Checks if Id BidAmount stores new value
        [Fact]
        public void IdBid_SetIdBid_StoresNewValues()
        {
            _bid.Id = 2;
            Assert.Equal(2,_bid.Id);
            _bid.BidAmount = 7600;
            Assert.Equal(7600, _bid.BidAmount);
        }

        
        // Checks if BidDateTime is DatTime type value
        [Fact]
        public void BidDateTime_NoParam_IsDateTimeType()
        {
#pragma warning disable 183
            Assert.True(_bid.BidDateTime is DateTime);
#pragma warning restore 183
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
        
    }
}