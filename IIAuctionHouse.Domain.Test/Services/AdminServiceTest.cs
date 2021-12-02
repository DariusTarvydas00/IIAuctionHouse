using System.Collections.Generic;
using System.IO;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.AccDetails;
using IIAuctionHouse.Domain.IRepositories;
using IIAuctionHouse.Domain.Services;
using Moq;
using Xunit;

namespace IIAuctionHouse.Domain.Test.Services
{
    public class AdminServiceTest
    {
        private readonly AdminService _service;
        private readonly Mock<IAdminRepository> _mock;
        private readonly List<Admin> _expected;

        public AdminServiceTest()
        {
            _mock = new Mock<IAdminRepository>();
            _service = new AdminService(_mock.Object);
            _expected = new List<Admin>()
            {
                new Admin()
                {
                    Id = 1,
                    FirstName = "Admin",
                    LastName = "Admin",
                    Address = new Address(),
                    Proprietaries = new List<Proprietary>(),
                    Bids = new List<Bid>()
                },
                new Admin()
                {
                    Id = 2,
                    FirstName = "Admin2",
                    LastName = "Admin2",
                    Address = new Address(),
                    Proprietaries = new List<Proprietary>(),
                    Bids = new List<Bid>()
                }
            };
        }

        // Checking if Service is Using Interface
        [Fact]
        public void AdminService_IsIAdminService()
        {
            Assert.True(_service is IAdminService);
        }
        
        // Checking throw exception if IAdminService is null
        [Fact]
        public void AdminService_WithNullRepositoryException_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new AdminService(null));
        }

        [Fact]
        public void AdminService_WithNullRepositoryException_ThrowsInvalidDataExceptionMessage()
        {
            var expected = "Admin Service can not be null";
            var actual = Assert.Throws<InvalidDataException>(() => new AdminService(null));
            Assert.Equal(expected,actual.Message);
        }
        
        // Checks if ReadAll method calls AdminRepository only one time
        [Fact]
        public void ReadAll_CallsAdminRepositoryReadAll_ExactlyOnce()
        {
            _service.ReadAll();
            _mock.Verify(r=>r.ReadAll(), Times.Once);
        }
        
        // Checks if ReadAll method returns list of Admines
        [Fact]
        public void ReadAll_NoFilter_ReturnsListOfAdmines()
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
            var expected = "Admin Id must be higher than 0";
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
            var expected = "Admin Id must be higher than 0";
            var actual = Assert.Throws<InvalidDataException>(() => _service.GetById(value));
            Assert.Equal(expected,actual.Message);
        }
        
        // Checks if Creating Admin Object is possible
        [Theory]
        [InlineData(null, "Admin", null, null, null)]
        [InlineData("Admin", null, null, null, null)]
        public void Create_WithNull_ThrowsExceptionWithMessage(string firstName, string lastName, Address address, List<Proprietary> proprietary, List<Bid> bid)
        {
            var expected = "One of the values is empty or entered incorrectly";
            var actual = Assert.Throws<InvalidDataException>(() =>
                _service.Create(firstName,lastName,address,proprietary,bid));
            Assert.Equal(expected,actual.Message);
        }
        
        // Checks if Updating Object is possible
        [Fact]
        public void Update_WithNull_ThrowsExceptionWithMessage()
        {
            var fakeList = new List<Admin>();
            fakeList.Add(new Admin() {Id = 0, FirstName = "Admin", LastName = "Admin", Address = new Address(), Proprietaries = new List<Proprietary>(), Bids = new List<Bid>()});
            var update1 = new Admin() {Id = 0, FirstName = "Admin", Address  = new Address(), Proprietaries = new List<Proprietary>(), Bids = new List<Bid>()};
            var update2 = new Admin() {Id = 0, LastName = "Admin", Address  = new Address(), Proprietaries = new List<Proprietary>(), Bids = new List<Bid>()};
            var update3 = new Admin() {Id = 0, FirstName = "Admin", LastName = "Admin", Proprietaries = new List<Proprietary>(), Bids = new List<Bid>()};
            var update4 = new Admin() {Id = 0, FirstName = "Admin", LastName = "Admin", Address  = new Address(), Bids = new List<Bid>() };
            var update5 = new Admin() {Id = 0, FirstName = "Admin", LastName = "Admin", Address  = new Address(), Proprietaries = new List<Proprietary>() };
            var expected = "One of the values is empty or entered incorrectly";
            var actual1 = Assert.Throws<InvalidDataException>(() => _service.Update(update1));
            var actual2 = Assert.Throws<InvalidDataException>(() => _service.Update(update2));
            var actual3 = Assert.Throws<InvalidDataException>(() => _service.Update(update3));
            var actual4 = Assert.Throws<InvalidDataException>(() => _service.Update(update4));
            var actual5 = Assert.Throws<InvalidDataException>(() => _service.Update(update5));
            Assert.Equal(expected,actual1.Message);
            Assert.Equal(expected,actual2.Message);
            Assert.Equal(expected,actual3.Message);
            Assert.Equal(expected,actual4.Message);
            Assert.Equal(expected,actual5.Message);
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
            var expected = "Admin Id must be higher than 0";
            var actual = Assert.Throws<InvalidDataException>(() => _service.Delete(value));
            Assert.Equal(expected,actual.Message);
        }
        
    }
}