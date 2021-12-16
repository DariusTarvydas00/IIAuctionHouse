using System;
using System.Collections.Generic;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using Moq;
using Xunit;

namespace IIAuctionHouse.Core.Test.IServices
{
    public class ICustomerDetailsServiceTest
    {
        [Fact]
        public void ICustomerDetails_IsAvailable()
        {
            var service = new Mock<ICustomerDetailsService>();
            Assert.NotNull(service);
        }
        
        // Checking if ReadAll method return a list
        [Fact]
        public void ReadAll_ReturnsListOfAllCustomerDetails()
        {
            var mock = new Mock<ICustomerDetailsService>();
            var fakeList = new List<CustomerDetails>();
            mock.Setup(s => s.GetAllCustomerDetails()).Returns(fakeList);
            var service = mock.Object;
            Assert.Equal(fakeList,service.GetAllCustomerDetails());
        }
        
        // Checking if GetById returns a CustomerDetails object
        [Fact]
        public void GetById_Id_ReturnsCustomerDetails()
        {
            var mock = new Mock<ICustomerDetailsService>();
            var fakeList = new List<CustomerDetails>();
            var customerDetails = new CustomerDetails()
            {
                Id = 1,
                Country = "DK",
                City = "Esbjerg",
                PostCode = 6700,
                StreetName = "Strandbygade",
                StreetNumber = 30,
                PhoneNumber = 123456789,
                Email = "test@test.com",
                AccCreationDateTime = DateTime.Today
            };
            fakeList.Add(customerDetails);
            mock.Setup(s => s.GetCustomerDetailsById(1)).Returns(fakeList.Find(a => a.Id == 1));
            var service = mock.Object;
            Assert.Equal(customerDetails,service.GetCustomerDetailsById(1));
        }
        
        // Checking if CustomerDetails object is created
        [Fact]
        public void Create_CustomerDetails_IsCreated()
        {
            var mock = new Mock<ICustomerDetailsService>();
            var customerDetails = new CustomerDetails()
            {
                Id = 1,
                Country = "DK",
                City = "Esbjerg",
                PostCode = 6700,
                StreetName = "Strandbygade",
                StreetNumber = 30,
                PhoneNumber = 123456789,
                Email = "test@test.com",
                AccCreationDateTime = DateTime.Today
            };
            mock.Setup(s => s.NewCustomerDetails(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), 
                    It.IsAny<string>(),It.IsAny<int>(),It.IsAny<int>(),It.IsAny<string>(),It.IsAny<DateTime>()))
                .Returns(() => customerDetails);
            var service = mock.Object;
            Assert.Equal(customerDetails,service.NewCustomerDetails("DK", "Esbjerg", 6700, "Strandbygade",30,123456789,"test@test.com",DateTime.Today));
        }
        
        // Checking if CustomerDetails object is updated
        [Fact]
        public void Update_CustomerDetails_IsUpdated()
        {
            var mock = new Mock<ICustomerDetailsService>();
            var customerDetails = new CustomerDetails()
            {
                Id = 1,
                Country = "DK",
                City = "Esbjerg",
                PostCode = 6700,
                StreetName = "Strandbygade",
                StreetNumber = 30,
                PhoneNumber = 123456789,
                Email = "test@test.com",
                AccCreationDateTime = DateTime.Today
            };
            mock.Setup(s => s.UpdateCustomerDetails(customerDetails)).Returns(customerDetails);
            var service = mock.Object;
            Assert.Equal(customerDetails,service.UpdateCustomerDetails(customerDetails));
        }
        
        // Checks if Delete method deletes object
        [Fact]
        public void Delete_Id_ReturnNull()
        {
            var mock = new Mock<ICustomerDetailsService>();
            var list = new List<CustomerDetails>();
            var customerDetails = new CustomerDetails()
            {
                Id = 1,
                Country = "DK",
                City = "Esbjerg",
                PostCode = 6700,
                StreetName = "Strandbygade",
                StreetNumber = 30,
                PhoneNumber = 123456789,
                Email = "test@test.com",
                AccCreationDateTime = DateTime.Today
            };
            list.Add(customerDetails);
            mock.Setup(s => s.DeleteCustomerDetails(1)).Returns(() => null);
            var service = mock.Object;
            Assert.Null(service.DeleteCustomerDetails(1));
        }
        
    }
}