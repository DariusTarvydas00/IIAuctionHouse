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
    public class CustomerDetailsServiceTest
    {
        private readonly CustomerDetailsService _service;
        private readonly Mock<ICustomerDetailsRepository> _mock;
        private readonly List<CustomerDetails> _expected;

        public CustomerDetailsServiceTest()
        {
            _mock = new Mock<ICustomerDetailsRepository>();
            _service = new CustomerDetailsService(_mock.Object);
            _expected = new List<CustomerDetails>()
            {
                new CustomerDetails()
                {
                    Id = 1,
                    Country = "Denmark",
                    City = "Esbjerg",
                    PostCode = 6700,
                    StreetName = "Strandbygade",
                    StreetNumber = 30,
                    PhoneNumber = 123456789,
                    Email = "test@test.com",
                    AccCreationDateTime = DateTime.Today
                },
                new CustomerDetails()
                {
                    Id = 2,
                    Country = "Lithuania",
                    City = "Kaunas",
                    PostCode = 123456,
                    StreetName = "New address",
                    StreetNumber = 30,
                    PhoneNumber = 987654321,
                    Email = "test2@test2.com",
                    AccCreationDateTime = DateTime.Today
                }
            };
        }

        // Checking if Service is Using Interface
        [Fact]
        public void AddressService_IsIAddressService()
        {
            Assert.True(_service is ICustomerDetailsService);
        }
        
        // Checking throw exception if IAddressService is null
        [Fact]
        public void AddressService_WithNullRepositoryException_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new CustomerDetailsService(null));
        }

        [Fact]
        public void AddressService_WithNullRepositoryException_ThrowsInvalidDataExceptionMessage()
        {
            var expected = "Customer Details repository failure";
            var actual = Assert.Throws<InvalidDataException>(() => new CustomerDetailsService(null));
            Assert.Equal(expected,actual.Message);
        }
        
        // Checks if ReadAll method calls AddressRepository only one time
        [Fact]
        public void ReadAll_CallsAddressRepositoryReadAll_ExactlyOnce()
        {
            _service.GetAllCustomerDetails();
            _mock.Verify(r=>r.ReadAll(), Times.Once);
        }
        
        // Checks if ReadAll method returns list of Addresses
        [Fact]
        public void ReadAll_NoFilter_ReturnsListOfAddresses()
        {
            _mock.Setup(r => r.ReadAll()).Returns(_expected);
            var actual = _service.GetAllCustomerDetails();
            Assert.Equal(_expected,actual);
        }
        
        // Checks if GetCustomerDetailsById throws exception if id is less than 1
        [Fact]
        public void GetCustomerDetailsById_withZeroOrLess_ThrowsException()
        {
            Assert.Throws<InvalidDataException>(() => _service.GetCustomerDetailsById(0));
            Assert.Throws<InvalidDataException>(() => _service.GetCustomerDetailsById(-5));
        }
        
        // Checks if GetCustomerDetailsById  throws exception message if id is less than 1
        [Fact]
        public void GetCustomerDetailsById_withZeroOrLess_ThrowsExceptionMessage()
        {
            var expected = "Customer Details Id value is invalid";
            var actual = Assert.Throws<InvalidDataException>(() => _service.GetCustomerDetailsById(0));
            Assert.Equal(expected,actual.Message);
            var actual2 = Assert.Throws<InvalidDataException>(() => _service.GetCustomerDetailsById(-5));
            Assert.Equal(expected,actual2.Message);
        }
        
        // Checks if GetCustomerDetailsById with null throws exception
        [Theory]
        [InlineData(null)]
        public void GetCustomerDetailsById_Null_ThrowsException(int value)
        {
            Assert.Throws<InvalidDataException>(() => _service.GetCustomerDetailsById(value));
        }
        
        // Checks if GetCustomerDetailsById with null throws exception message
        [Theory]
        [InlineData(null)]
        public void GetCustomerDetailsById_Null_ThrowsExceptionMessage(int value)
        {
            var expected = "Customer Details Id value is invalid";
            var actual = Assert.Throws<InvalidDataException>(() => _service.GetCustomerDetailsById(value));
            Assert.Equal(expected,actual.Message);
        }
        
        // Checks if Creating Address Object is possible
        [Theory]
        [ClassData(typeof(TestCreateDataClass))]
        public void Create_WithNull_ThrowsExceptionWithMessage(string country, string city, int postCode, string streetName, int streetNumber, int phoneNumber, string email, DateTime accCreationDateTime, string expected)
        {
            var actual = Assert.Throws<InvalidDataException>(() =>
                _service.CreateCustomerDetails(new CustomerDetails()
                {
                    Country = country, City = city, PostCode = postCode, StreetName = streetName, StreetNumber = streetNumber,
                    PhoneNumber = phoneNumber,Email = email,AccCreationDateTime = accCreationDateTime 
                }));
            Assert.Equal(expected,actual.Message);
        }
        
        private class TestCreateDataClass : IEnumerable<object[]>
        {
            private const string Expected1 = "Country value is invalid";
            private const string Expected2 = "City value is invalid";
            private const string Expected3 = "Post Code value is invalid";
            private const string Expected4 = "Street Name value is invalid";
            private const string Expected5 = "Street Number value is invalid";
            private const string Expected6 = "Phone Number value is invalid";
            private const string Expected7 = "Email value is invalid";
            private const string Expected8 = "Account Creation Date Time value is invalid";
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] {null,"Esbjerg",6700,"Strandbygade", 30, 123456789, "test@test.com", DateTime.Today, Expected1},
                new object[] {"DK",null,6700,"Strandbygade", 30, 123456789, "test@test.com", DateTime.Today, Expected2},
                new object[] {"DK","Esbjerg",null,"Strandbygade", 30, 123456789, "test@test.com", DateTime.Today, Expected3},
                new object[] {"DK","Esbjerg",6700,null, 30, 123456789, "test@test.com", DateTime.Today, Expected4},
                new object[] {"DK","Esbjerg",6700,"Strandbygade", null, 123456789, "test@test.com", DateTime.Today, Expected5},
                new object[] {"DK","Esbjerg",6700,"Strandbygade", 30, null, "test@test.com", DateTime.Today, Expected6},
                new object[] {"DK","Esbjerg",6700,"Strandbygade", 30, 123456789, null, DateTime.Today, Expected7},
                new object[] {"DK","Esbjerg",6700,"Strandbygade", 30, 123456789, "test@test.com", null, Expected8},
            };

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();


            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
        
        // Checks if Updating Object is possible
        [Theory]
        [ClassData(typeof(TestCreateDataClass))]
        public void Update_WithNull_ThrowsExceptionWithMessage(string country, string city, int postCode, string StreetName,
            int streetNumber, int phoneNumber, string email, DateTime accCreationDateTime, string expected)
        {
            var actual = Assert.Throws<InvalidDataException>(() => _service.UpdateCustomerDetails(new CustomerDetails()
            {
                Country = country,
                City = city,
                PostCode = postCode,
                StreetName = StreetName,
                StreetNumber = streetNumber,
                PhoneNumber = phoneNumber,
                Email = email,
                AccCreationDateTime = accCreationDateTime
            }));
            Assert.Equal(expected,actual.Message);
        }
        
        // Check if Delete Method throws exception
        [Theory]
        [InlineData(null)]
        public void Delete_Null_ThrowsException(int value)
        {
            Assert.Throws<InvalidDataException>(() => _service.DeleteCustomerDetails(value));
        }
        
        // Checks if Delete with null throws exception message
        [Theory]
        [InlineData(null)]
        public void Delete_Null_ThrowsExceptionMessage(int value)
        {
            var expected = "Customer Details Id value is invalid";
            var actual = Assert.Throws<InvalidDataException>(() => _service.DeleteCustomerDetails(value));
            Assert.Equal(expected,actual.Message);
        }

        [Fact]
        public void Delete_Int_DeletesCustomerDetails()
        {
            Assert.Null(_service.DeleteCustomerDetails(1));
        }
    }
}