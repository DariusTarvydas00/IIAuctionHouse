using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using IIAuctionHouse.Core.Domain.IRepositories;
using IIAuctionHouse.Core.Domain.Services;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using Moq;
using Xunit;

namespace IIAuctionHouse.Domain.Test.Services
{
    public class ProprietaryServiceTest
    {
        private readonly ProprietaryService _service;
        private readonly Mock<IProprietaryRepository> _mockProprietaryRepository;
        private readonly Mock<IBidRepository> _mockBidRepository;
        private readonly List<Proprietary> _expected;

        public ProprietaryServiceTest()
        {
            _mockProprietaryRepository = new Mock<IProprietaryRepository>();
            _mockBidRepository = new Mock<IBidRepository>();
            _service = new ProprietaryService(_mockProprietaryRepository.Object, _mockBidRepository.Object);
            _expected = new List<Proprietary>()
            {
                new Proprietary()
                {
                    Id = 1,
                    CadastreNumber = "321/321/321",
                    City = "Esbjerg",
                    ForestryEnterprise = "EsbjergEnterprise"
                },
                new Proprietary()
                {
                    Id = 2,
                    CadastreNumber = "123/12/123",
                    City = "Esbjerg",
                    ForestryEnterprise = "EsbjergEnterprise"
                }
            };
        }

        // Checking if Service is Using Interface
        [Fact]
        public void ProprietaryService_IsIProprietaryService()
        {
            Assert.True(_service is IProprietaryService);
        }
        
        // Checking throw exception if IProprietaryService is null
        [Fact]
        public void ProprietaryService_WithNullRepositoryException_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new ProprietaryService(null,null));
        }

        [Fact]
        public void ProprietaryService_WithNullRepositoryException_ThrowsInvalidDataExceptionMessage()
        {
            var expected = "Proprietary Repositury failure";
            var actual = Assert.Throws<InvalidDataException>(() => new ProprietaryService(null,null));
            Assert.Equal(expected,actual.Message);
        }
        
        // Checks if ReadAll method calls ProprietaryRepository only one time
        [Fact]
        public void ReadAll_CallsProprietaryRepositoryReadAll_ExactlyOnce()
        {
            _service.GetAllProprietaries();
            _mockProprietaryRepository.Verify(r=>r.ReadAll(), Times.Once);
        }
         
        // Checks if ReadAll method returns list of Proprietaries
        [Fact]
        public void ReadAll_NoFilter_ReturnsListOfProprietary()
        {
            _mockProprietaryRepository.Setup(r => r.ReadAll()).Returns(_expected);
            var actual = _service.GetAllProprietaries();
            Assert.Equal(_expected,actual);
        }
        
        // Checks if GetProprietaryById throws exception if id is less than 1
        [Fact]
        public void GetProprietaryById_withZeroOrLess_ThrowsException()
        {
            Assert.Throws<InvalidDataException>(() => _service.GetProprietaryById(0));
            Assert.Throws<InvalidDataException>(() => _service.GetProprietaryById(-5));
        }
        
        // Checks if GetProprietaryById  throws exception message if id is less than 1
        [Fact]
        public void GetProprietaryById_withZeroOrLess_ThrowsExceptionMessage()
        {
            var expected = "Proprietary Id value is invalid";
            var actual = Assert.Throws<InvalidDataException>(() => _service.GetProprietaryById(0));
            Assert.Equal(expected,actual.Message);
            var actual2 = Assert.Throws<InvalidDataException>(() => _service.GetProprietaryById(-5));
            Assert.Equal(expected,actual2.Message);
        }
        
        // Checks if GetProprietaryById with null throws exception
        [Theory]
        [InlineData(null)]
        public void GetProprietaryById_Null_ThrowsException(int value)
        {
            Assert.Throws<InvalidDataException>(() => _service.GetProprietaryById(value));
        }
        
        // Checks if GetProprietaryById with null throws exception message
        [Theory]
        [InlineData(null)]
        public void GetProprietaryById_Null_ThrowsExceptionMessage(int value)
        {
            var expected = "Proprietary Id value is invalid";
            var actual = Assert.Throws<InvalidDataException>(() => _service.GetProprietaryById(value));
            Assert.Equal(expected,actual.Message);
        }
        
        // Checks if Creating proprietary Object is possible
        [Theory]
        [ClassData(typeof(TestCreateBidDataClass))]
        public void Create_WithNull_ThrowsExceptionWithMessage(string cadastreNumber, string forestryEnterprise, string city, List<Bid> bids, string expected)
        {
            var actual = Assert.Throws<InvalidDataException>(() =>
                _service.CreateProprietary(new Proprietary()
                {
                    CadastreNumber = cadastreNumber,
                    ForestryEnterprise = forestryEnterprise,
                    City = city,
                    Bids = bids
                }));
            Assert.Equal(expected,actual.Message);
        }
        
        private class TestCreateBidDataClass : IEnumerable<object[]>
        {
            private const string Expected1 = "Proprietary Cadastre Number value is invalid";
            private const string Expected2 = "Proprietary Forestry Enterprise value is invalid";
            private const string Expected3 = "Proprietary City value is invalid";
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] {null, "EsbjergEnterprise", "Esbjerg", new List<Bid>{(new Bid(){Id = 1})}, Expected1},
                new object[] {"123/123:123", null, "Esbjerg", new List<Bid>{(new Bid(){Id = 1})}, Expected2},
                new object[] {"123/123:123", "EsbjergEnterprise", null, new List<Bid>{(new Bid(){Id = 1})}, Expected3},
            };
            
            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();


            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
        
        // Checks if Updating Object is possible
        [Fact]
        public void Update_WithNull_ThrowsExceptionWithMessage()
        {
            var update1 = new Proprietary() {Id = 0,
                CadastreNumber = "123/123/123",
                ForestryEnterprise = "EsbjergEnterprise"};
            var update2 = new Proprietary()
            {
                Id = 0,
                CadastreNumber = "123/123/123",
                City = "Esbjerg"

            };
            var expected1 = "Proprietary City value is invalid";
            var expected2 = "Proprietary Forestry Enterprise value is invalid";
            var actual1 = Assert.Throws<InvalidDataException>(() => _service.UpdateProprietary(update1));
            var actual2 = Assert.Throws<InvalidDataException>(() => _service.UpdateProprietary(update2));
            Assert.Equal(expected1,actual1.Message);
            Assert.Equal(expected2,actual2.Message);
        }

        // Check if Delete Method throws exception
        [Theory]
        [InlineData(null)]
        public void Delete_Null_ThrowsException(int value)
        {
            Assert.Throws<InvalidDataException>(() => _service.Delete(value));
        }
        
        // Checks if Delete with null throws exception message
        [Theory]
        [InlineData(null)]
        public void Delete_Null_ThrowsExceptionMessage(int value)
        {
            var expected = "Proprietary Id value is invalid";
            var actual = Assert.Throws<InvalidDataException>(() => _service.Delete(value));
            Assert.Equal(expected,actual.Message);
        }
        
        [Fact]
        public void Delete_Int_DeletesCustomerDetails()
        {
            Assert.Null(_service.Delete(1));
        }
    }
}