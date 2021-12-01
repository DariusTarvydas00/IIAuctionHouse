using System.Collections.Generic;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using Moq;
using Xunit;

namespace IIAuctionHouse.Core.Test.IServices
{
    public class IUserServiceTest
    {
         // Checking if IUserService is available
        [Fact]
        public void IUserService_IsAvailable()
        {
            var service = new Mock<IUserService>();
            Assert.NotNull(service);
        }
        
        // Checking if ReadAll method return a list
        [Fact]
        public void ReadAll_NoParam_ReturnsListOfAllUseres()
        {
            var mock = new Mock<IUserService>();
            var fakeList = new List<User>();
            mock.Setup(s => s.ReadAll()).Returns(fakeList);
            var service = mock.Object;
            Assert.Equal(fakeList,service.ReadAll());
        }
        
        // Checking if GetById returns a User object
        [Fact]
        public void GetById_Id_ReturnsUser()
        {
            var mock = new Mock<IUserService>();
            var fakeList = new List<User>();
            var User = new User()
            {
                Id = 1,
                FirstName = "User",
                LastName = "User",
                Address = new Address(),
                Proprietary = new Proprietary(),
                Bid = new Bid()
            };
            fakeList.Add(User);
            mock.Setup(s => s.GetById(1)).Returns(fakeList.Find(a => a.Id == 1));
            var service = mock.Object;
            Assert.Equal(User,service.GetById(1));
        }
        
        // Checking if User object is created
        [Fact]
        public void Create_AllUserProperties_IsCreated()
        {
            var mock = new Mock<IUserService>();
            var fakeUser = new User()
            {
                Id = 1,
                FirstName = "User",
                LastName = "User",
                Address = new Address(),
                Proprietary = new Proprietary(),
                Bid = new Bid()
            };
            mock.Setup(s => s.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Address>(), It.IsAny<Proprietary>(), It.IsAny<Bid>()))
                .Returns(() => fakeUser);
            var service = mock.Object;
            Assert.Equal(fakeUser,service.Create("User", "User", new Address(), new Proprietary(), new Bid()));
        }
        
        // Checking if User object is updated
        [Fact]
        public void Update_User_IsUpdated()
        {
            var mock = new Mock<IUserService>();
            var fakeUser = new User()
            {
                Id = 1,
                FirstName = "User",
                LastName = "User",
                Address = new Address(),
                Proprietary = new Proprietary(),
                Bid = new Bid()
            };
            var newFakeUser = new User()
            {
                Id = 1,
                FirstName = "User2",
                LastName = "User2",
                Address = new Address(),
                Proprietary = new Proprietary(),
                Bid = new Bid()
            };
            mock.Setup(s => s.Update(newFakeUser)).Returns(newFakeUser);
            var service = mock.Object;
            Assert.Equal(newFakeUser,service.Update(newFakeUser));
        }
        
        // Checks if Delete method deletes object
        [Fact]
        public void Delete_Id_ReturnNull()
        {
            var mock = new Mock<IUserService>();
            var fakeList = new List<User>();
            var User = new User()
            {
                Id = 1,
                FirstName = "User",
                LastName = "User",
                Address = new Address(),
                Proprietary = new Proprietary(),
                Bid = new Bid()
            };
            fakeList.Add(User);
            mock.Setup(s => s.Delete(1)).Returns(() => null);
            var service = mock.Object;
            Assert.Null(service.Delete(1));
        }
    }
}