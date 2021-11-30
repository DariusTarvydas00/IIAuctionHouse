using System;
using System.Collections.Generic;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using Moq;
using Xunit;

namespace IIAuctionHouse.Core.Test.IServices
{
    public class IAccDetailsServiceTest
    {
        // Checking if IAccDetails is available
        [Fact]
        public void IAccDetails_IsAvailable()
        {
            var service = new Mock<IAccDetailsService>();
            Assert.NotNull(service);
        }
        
        // Checking if ReadAll method return a list
        [Fact]
        public void ReadAll_NoParam_ReturnsListOfAllAccDetail()
        {
            var mock = new Mock<IAccDetailsService>();
            var fakeList = new List<AccDetails>();
            mock.Setup(s => s.ReadAll()).Returns(fakeList);
            var service = mock.Object;
            Assert.Equal(fakeList,service.ReadAll());
        }
        
        // Checking if GetById returns a AccDetails object
        [Fact]
        public void GetById_Id_ReturnsAccDetails()
        {
            var mock = new Mock<IAccDetailsService>();
            var fakeList = new List<AccDetails>();
            var AccDetails = new AccDetails()
            {
                Id = 1,
                Address = new Address(),
                Email = "test@test.com",
                PhoneNumber = 123456789,
                AccCreationDateTime = new DateTime(2021,11,23)
            };
            fakeList.Add(AccDetails);
            mock.Setup(s => s.GetById(1)).Returns(fakeList.Find(a => a.Id == 1));
            var service = mock.Object;
            Assert.Equal(AccDetails,service.GetById(1));
        }
        
        // Checking if AccDetails object is created
        [Fact]
        public void Create_AllAccDetailsProperties_IsCreated()
        {
            var mock = new Mock<IAccDetailsService>();
            var fakeAccDetails = new AccDetails()
            {
                Id = 1,
                Address = new Address(),
                Email = "test@test.com",
                PhoneNumber = 123456789,
                AccCreationDateTime = new DateTime(2021,11,23)
            };
            mock.Setup(s => s.Create(It.IsAny<Address>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<DateTime>()))
                .Returns(() => fakeAccDetails);
            var service = mock.Object;
            Assert.Equal(fakeAccDetails,service.Create(new Address(), "test@test.com", 123456789, new DateTime(2021,11,23)));
        }
        
        // Checking if AccDetails object is updated
        [Fact]
        public void Update_AccDetails_IsUpdated()
        {
            var mock = new Mock<IAccDetailsService>();
            var fakeAccDetails = new AccDetails()
            {
                Id = 1,
                Address = new Address(),
                Email = "test@test.com",
                PhoneNumber = 123456789,
                AccCreationDateTime = new DateTime(2021,11,23)
            };
            var newFakeAccDetails = new AccDetails()
            {
                Id = 1,
                Address = new Address(),
                Email = "test2@test2.com",
                PhoneNumber = 123456789,
                AccCreationDateTime = new DateTime(2021,11,23)
            };
            mock.Setup(s => s.Update(newFakeAccDetails)).Returns(newFakeAccDetails);
            var service = mock.Object;
            Assert.Equal(newFakeAccDetails,service.Update(newFakeAccDetails));
        }
        
        // Checks if Delete method deletes object
        [Fact]
        public void Delete_Id_ReturnNull()
        {
            var mock = new Mock<IAccDetailsService>();
            var fakeList = new List<AccDetails>();
            var AccDetails = new AccDetails()
            {
                Id = 1,
                Address = new Address(),
                Email = "test2@test2.com",
                PhoneNumber = 123456789,
                AccCreationDateTime = new DateTime(2021,11,23)
            };
            fakeList.Add(AccDetails);
            mock.Setup(s => s.Delete(1)).Returns(() => null);
            var service = mock.Object;
            Assert.Null(service.Delete(1));
        }
    }
}