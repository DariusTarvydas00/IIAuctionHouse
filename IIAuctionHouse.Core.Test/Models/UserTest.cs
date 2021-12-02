using System;
using System.Collections.Generic;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.AccDetails;
using Xunit;

namespace IIAuctionHouse.Core.Test.Models
{
    public class UserTest
    {
         private readonly User _user;

        public UserTest()
        {
            _user = new User()
            {
                Id = 1,
                FirstName = "FirstName",
                LastName = "LastName",
                Address = new Address()
                {Id = 1, Country = "DK", City = "Copenhagen", PostCode = 1067, StreetName = "Old Street Name", StreetNumber = 30
                },
                Proprietaries = new List<Proprietary>()
                {
                    new Proprietary()
                    {Id = 1, CadastreNumber = "123/123:123", ForestryEnterprise = "Esbjerg Forestry Enterprise",
                        City = "Esbjerg", Bids = new List<Bid>() {new Bid() {Id = 1, BidAmount = 7600, BidDateTime = DateTime.Today
                            }
                        }
                    }
                },
                Bids = new List<Bid>()
                {
                    new Bid()
                    {
                        Id = 1,
                        BidAmount = 7601,
                        BidDateTime = DateTime.Today
                    }
                }
            };
        }

        // Checking if User class can be initialized
        [Fact]
        public void User_CanBeInitialized()
        {
            Assert.NotNull(_user);
        }

        # region Id Property Test
        
        [Fact]
        // Check if Id property exists
        public void Id_Exists()
        {
            Assert.True(_user.GetType().GetProperty("Id") != null);
        }
        // Check if Id is integer value type
        [Fact]
        public void Id_isIntegerType()
        {
            Assert.True(_user.Id is int);
        }
        
        // Checking if Id value is stored
        [Fact]
        public void Id_SetId_StoresId()
        {
            Assert.Equal(1,_user.Id);
        }
        
        // Checking if Id value is updated
        [Fact]
        public void Id_UpdateId_StoresNewIdValues()
        {
            _user.Id = 2;
            Assert.Equal(2,_user.Id);
        }
        
        #endregion
        
        # region FirstName Property Test
        
        [Fact]
        // Check if FirstName property exists
        public void FirstName_Exists()
        {
            Assert.True(_user.GetType().GetProperty("FirstName") != null);
        }
        // Check if FirstName is string value type
        [Fact]
        public void FirstName_isIntegerType()
        {
            Assert.True(_user.FirstName is string);
        }
        
        // Checking if FirstName value is stored
        [Fact]
        public void FirstName_SetFirstName_StoresFirstName()
        {
            Assert.Equal("FirstName",_user.FirstName);
        }
        
        // Checking if FirstName value is updated
        [Fact]
        public void FirstName_UpdateFirstName_StoresNewFirstNameValues()
        {
            _user.FirstName = "NewFirstName";
            Assert.Equal("NewFirstName",_user.FirstName);
        }
        
        #endregion

        # region LastName Property Test
        
        [Fact]
        // Check if LastName property exists
        public void LastName_Exists()
        {
            Assert.True(_user.GetType().GetProperty("LastName") != null);
        }
        // Check if LastName is string value type
        [Fact]
        public void LastName_isIntegerType()
        {
            Assert.True(_user.LastName is string);
        }
        
        // Checking if LastName value is stored
        [Fact]
        public void LastName_SetLastName_StoresLastName()
        {
            Assert.Equal("LastName",_user.LastName);
        }
        
        // Checking if LastName value is updated
        [Fact]
        public void LastName_UpdateLastName_StoresNewLastNameValues()
        {
            _user.LastName = "NewLastName";
            Assert.Equal("NewLastName",_user.LastName);
        }
        
        #endregion

        #region Address Property Test

        // Checking if Address property exists
        [Fact]
        public void Address_Exists()
        {
            Assert.True(_user.GetType().GetProperty("Address") != null);
        }
        
        // Checking if Address value is stored
        [Fact]
        public void Address_SetAddress_StoresAddress()
        {
            var expected = _user.Address = new Address()
            {
                Id = 1,
                Country = "DK",
                City = "Copenhagen",
                PostCode = 1067,
                StreetName = "Old Street Name",
                StreetNumber = 30
            };
            _user.Address = expected;
            Assert.Equal(expected,_user.Address);
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
            _user.Address = expected;
            Assert.Equal(expected,_user.Address);
        }

        #endregion

        #region Proprietarys Property Test

        // Checks if Proprietary property exists
        [Fact]
        public void Proprietaries_Exists()
        {
            Assert.True(_user.GetType().GetProperty("Proprietaries") != null);
        }
        
        // Checks if Proprietarys property is List of Proprietarys type
        [Fact]
        public void Proprietaries_IsListOfProprietaries()
        {
            Assert.True(_user.Proprietaries is List<Proprietary>);
        }

        // Checks if Proprietaries stores value
        [Fact]
        public void Proprietaries_SetProprietaries_StoresValue()
        {
            var expected = _user.Proprietaries = new List<Proprietary>()
            {
                new Proprietary()
                {Id = 1, CadastreNumber = "123/123:123", ForestryEnterprise = "Esbjerg Forestry Enterprise",
                    City = "Esbjerg", Bids = new List<Bid>() {new Bid() {Id = 1, BidAmount = 7600, BidDateTime = DateTime.Today
                        }
                    }
                }
            };
            Assert.Equal(expected, _user.Proprietaries);
        }
        
        // Checks if Proprietaries stores new value
        [Fact]
        public void Proprietaries_SetProprietaries_StoresNewValue()
        {
            var expected = _user.Proprietaries = new List<Proprietary>()
            {
                new Proprietary()
                {Id = 2, CadastreNumber = "321/321:321", ForestryEnterprise = "Copenhagen Forestry Enterprise",
                    City = "Copenhagen", Bids = new List<Bid>() {new Bid() {Id = 1, BidAmount = 7600, BidDateTime = DateTime.Today
                        }
                    }
                }
            };
            Assert.Equal(expected, _user.Proprietaries);
        }
        
        #endregion

        #region Bids Property Test

        // Checks if Proprietary property exists
        [Fact]
        public void Bid_Exists()
        {
            Assert.True(_user.GetType().GetProperty("Bids") != null);
        }
        
        // Checks if Bids property is List of Bids type
        [Fact]
        public void Bid_IsListOfBids()
        {
            Assert.True(_user.Bids is List<Bid>);
        }

        // Checks if Bid stores value
        [Fact]
        public void Bid_SetBid_StoresValue()
        {
            var expected = _user.Bids = new List<Bid>()
            {
                new Bid()
                {
                    Id = 1,
                    BidAmount = 7600,
                    BidDateTime = DateTime.Today
                }
            };
            Assert.Equal(expected, _user.Bids);
        }
        
        // Checks if Bid stores new value
        [Fact]
        public void Bid_SetBid_StoresNewValue()
        {
            var expected = _user.Bids = new List<Bid>()
            {
                new Bid()
                {
                    Id = 2,
                    BidAmount = 4600,
                    BidDateTime = DateTime.Today
                }
            };
            Assert.Equal(expected, _user.Bids);
        }
        
        #endregion
    }
}