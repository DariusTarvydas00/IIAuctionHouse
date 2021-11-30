using System.Collections.Generic;
using System.IO;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Domain.IRepositories;
using IIAuctionHouse.Domain.Services;
using Moq;
using Xunit;

namespace IIAuctionHouse.Domain.Test.Services
{
    public class ProprietaryServiceTest
    {
        private readonly ProprietaryService _service;
        private readonly Mock<IProprietaryRepository> _mock;
        private readonly List<Proprietary> _expected;

        public ProprietaryServiceTest()
        {
            _mock = new Mock<IProprietaryRepository>();
            _service = new ProprietaryService(_mock.Object);
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
            Assert.Throws<InvalidDataException>(() => new ProprietaryService(null));
        }

        [Fact]
        public void ProprietaryService_WithNullRepositoryException_ThrowsInvalidDataExceptionMessage()
        {
            var expected = "Proprietary Repository can not be null";
            var actual = Assert.Throws<InvalidDataException>(() => new ProprietaryService(null));
            Assert.Equal(expected,actual.Message);
        }
        
        // Checks if ReadAll method calls ProprietaryRepository only one time
        [Fact]
        public void ReadAll_CallsProprietaryRepositoryReadAll_ExactlyOnce()
        {
            _service.ReadAll();
            _mock.Verify(r=>r.ReadAll(), Times.Once);
        }
        
        // Checks if ReadAll method returns list of Proprietaries
        [Fact]
        public void ReadAll_NoFilter_ReturnsListOfProprietary()
        {
            _mock.Setup(r => r.ReadAll()).Returns(_expected);
            var actual = _service.ReadAll();
            Assert.Equal(_expected,actual);
        }
        
        // Checks if GetById throws exception if id is less than 1
        [Fact]
        public void GetById_withZeroOrLess_ThrowsException()
        {
            Assert.Throws<InvalidDataException>(() => _service.GetById(0));
            Assert.Throws<InvalidDataException>(() => _service.GetById(-5));
        }
        
        // Checks if GetById  throws exception message if id is less than 1
        [Fact]
        public void GetById_withZeroOrLess_ThrowsExceptionMessage()
        {
            var expected = "Proprietary Id must be higher than 0";
            var actual = Assert.Throws<InvalidDataException>(() => _service.GetById(0));
            Assert.Equal(expected,actual.Message);
            var actual2 = Assert.Throws<InvalidDataException>(() => _service.GetById(-5));
            Assert.Equal(expected,actual2.Message);
        }
        
        // Checks if GetById with null throws exception
        [Theory]
        [InlineData(null)]
        public void GetById_Null_ThrowsException(int value)
        {
            Assert.Throws<InvalidDataException>(() => _service.GetById(value));
        }
        
        // Checks if GetById with null throws exception message
        [Theory]
        [InlineData(null)]
        public void GetById_Null_ThrowsExceptionMessage(int value)
        {
            var expected = "Proprietary Id must be higher than 0";
            var actual = Assert.Throws<InvalidDataException>(() => _service.GetById(value));
            Assert.Equal(expected,actual.Message);
        }
        
        // Checks if Creating proprietary Object is possible
        [Theory]
        [InlineData("123/123:123", "EsbjergEnterprise", null)]
        [InlineData("123/123:123", null, "Esbjerg")]
        [InlineData(null, "EsbjergEnterprise", "Esbjerg")]
        public void Create_WithNull_ThrowsExceptionWithMessage(string cadastreNumber, string forestryEnterprise, string City)
        {
            var expected = "One of the values is empty or entered incorrectly";
            var actual = Assert.Throws<InvalidDataException>(() =>
                _service.Create(cadastreNumber, forestryEnterprise, City));
            Assert.Equal(expected,actual.Message);
        }
        
        
        
        // Checks if Updating Object is possible
        [Fact]
        public void Update_WithNull_ThrowsExceptionWithMessage()
        {
            var fakeList = new List<Proprietary>();
            fakeList.Add(new Proprietary() {Id = 0,
                CadastreNumber = "123/123/123",
                City = "Esbjerg",
                ForestryEnterprise = "EsbjergEnterprise"});
            var update1 = new Proprietary() {Id = 0,
                CadastreNumber = "123/123/123",
                ForestryEnterprise = "EsbjergEnterprise"};
            var update2 = new Proprietary()
            {
                Id = 0,
                CadastreNumber = "123/123/123",
                City = "Esbjerg"

            };
            var expected = "One of the values is empty or entered incorrectly";
            var actual1 = Assert.Throws<InvalidDataException>(() => _service.Update(update1));
            var actual2 = Assert.Throws<InvalidDataException>(() => _service.Update(update2));
            Assert.Equal(expected,actual1.Message);
            Assert.Equal(expected,actual2.Message);
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
            var expected = "Proprietary Id must be higher than 0";
            var actual = Assert.Throws<InvalidDataException>(() => _service.Delete(value));
            Assert.Equal(expected,actual.Message);
        }
    }
}