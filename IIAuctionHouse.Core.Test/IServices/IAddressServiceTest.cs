using System.Collections.Generic;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using Moq;
using Xunit;

namespace IIAuctionHouse.Core.Test.IServices
{
    public class IAddressServiceTest
    {
        // Checking if IAddressService is available
        [Fact]
        public void IAddressService_IsAvailable()
        {
            var service = new Mock<IAddressService>();
            Assert.NotNull(service);
        }
        
        // Checking if ReadAll method return a list
        [Fact]
        public void ReadAll_NoParam_ReturnsListOfAllAddresses()
        {
            var mock = new Mock<IAddressService>();
            var fakeList = new List<Address>();
            mock.Setup(s => s.ReadAll()).Returns(fakeList);
            var service = mock.Object;
            Assert.Equal(fakeList,service.ReadAll());
        }
        
        // Checking if GetById returns a Address object
        [Fact]
        public void GetById_Id_ReturnsAddress()
        {
            var mock = new Mock<IAddressService>();
            var fakeList = new List<Address>();
            var address = new Address()
            {
                Id = 1,
                Country = "Denmark",
                City = "Esbjerg",
                PostCode = 6700,
                StreetName = "Skolegade",
                StreetNumber = 30
            };
            fakeList.Add(address);
            mock.Setup(s => s.GetById(1)).Returns(fakeList.Find(a => a.Id == 1));
            var service = mock.Object;
            Assert.Equal(address,service.GetById(1));
        }
        
        // Checking if Address object is created
        [Fact]
        public void Create_AllAddressProperties_IsCreated()
        {
            var mock = new Mock<IAddressService>();
            var fakeAddress = new Address()
            {
                Id = 1,
                Country = "Denmark",
                City = "Esbjerg",
                PostCode = 6700,
                StreetName = "Skolegade",
                StreetNumber = 30
            };
            mock.Setup(s => s.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>()))
                .Returns(() => fakeAddress);
            var service = mock.Object;
            Assert.Equal(fakeAddress,service.Create("Denmark", "Esbjerg", 6700, "Skolegade", 30));
        }
        
        // Checking if Address object is updated
        [Fact]
        public void Update_Address_IsUpdated()
        {
            var mock = new Mock<IAddressService>();
            var fakeAddress = new Address()
            {
                Id = 1,
                Country = "Denmark",
                City = "Esbjerg",
                PostCode = 6700,
                StreetName = "Skolegadeeee",
                StreetNumber = 301
            };
            var newFakeAddress = new Address()
            {
                Id = 1,
                Country = "Denmark",
                City = "Copenhagen",
                PostCode = 6700, 
                StreetName = "Skolegadeeee",
                StreetNumber = 301
            };
            mock.Setup(s => s.Update(newFakeAddress)).Returns(newFakeAddress);
            var service = mock.Object;
            Assert.Equal(newFakeAddress,service.Update(newFakeAddress));
        }
        
        // Checks if Delete method deletes object
        [Fact]
        public void Delete_Id_ReturnNull()
        {
            var mock = new Mock<IAddressService>();
            var fakeList = new List<Address>();
            var address = new Address()
            {
                Id = 1,
                Country = "Denmark",
                City = "Esbjerg",
                PostCode = 6700,
                StreetName = "Skolegade",
                StreetNumber = 30
            };
            fakeList.Add(address);
            mock.Setup(s => s.Delete(1)).Returns(() => null);
            var service = mock.Object;
            Assert.Null(service.Delete(1));
        }
    }
}