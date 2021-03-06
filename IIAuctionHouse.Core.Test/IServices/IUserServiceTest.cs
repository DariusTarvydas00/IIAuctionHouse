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
        public void ReadAll_ReturnsListOfAllUsers()
        {
            var mock = new Mock<IUserService>();
            var fakeList = new List<User>();
            mock.Setup(s => s.GetAllUsers()).Returns(fakeList);
            var service = mock.Object;
            Assert.Equal(fakeList,service.GetAllUsers());
        }
        
        // Checking if GetById returns a User object
        // [Fact]
        // public void GetById_Id_ReturnsUser()
        // {
        //     var mock = new Mock<IUserService>();
        //     var fakeList = new List<User>();
        //     var user = new User()
        //     {
        //         Id = 1,
        //         FirstName = "User",
        //         LastName = "User",
        //         Address = new Address(),
        //         Proprietaries = new List<Proprietary>(),
        //         Bids = new List<Bid>()
        //     };
        //     fakeList.Add(user);
        //     mock.Setup(s => s.GetById(1)).Returns(fakeList.Find(a => a.Id == 1));
        //     var service = mock.Object;
        //     Assert.Equal(user,service.GetById(1));
        // }
        //
        // // Checking if User object is created
        // [Fact]
        // public void Create_User_IsCreated()
        // {
        //     var mock = new Mock<IUserService>();
        //     var fakeUser = new User()
        //     {
        //         Id = 1,
        //         FirstName = "User",
        //         LastName = "User",
        //         Address = new Address(),
        //         Proprietaries = new List<Proprietary>(),
        //         Bids = new List<Bid>()
        //     };
        //     mock.Setup(s => s.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Address>(), It.IsAny<List<Proprietary>>(), It.IsAny<List<Bid>>()))
        //         .Returns(() => fakeUser);
        //     var service = mock.Object;
        //     Assert.Equal(fakeUser,service.Create("User", "User", new Address(), new List<Proprietary>(), new List<Bid>()));
        // }
        //
        // // Checking if User object is updated
        // [Fact]
        // public void Update_User_IsUpdated()
        // {
        //     var mock = new Mock<IUserService>();
        //     var fakeUser = new User()
        //     {
        //         Id = 1,
        //         FirstName = "User2",
        //         LastName = "User2",
        //         Address = new Address(),
        //         Proprietaries = new List<Proprietary>(),
        //         Bids = new List<Bid>()
        //     };
        //     mock.Setup(s => s.Update(fakeUser)).Returns(fakeUser);
        //     var service = mock.Object;
        //     Assert.Equal(fakeUser,service.Update(fakeUser));
        // }
        //
        // // Checks if Delete method deletes object
        // [Fact]
        // public void Delete_Id_ReturnNull()
        // {
        //     var mock = new Mock<IUserService>();
        //     var fakeList = new List<User>();
        //     var user = new User()
        //     {
        //         Id = 1,
        //         FirstName = "User",
        //         LastName = "User",
        //         Address = new Address(),
        //         Proprietaries = new List<Proprietary>(),
        //         Bids = new List<Bid>()
        //     };
        //     fakeList.Add(user);
        //     mock.Setup(s => s.Delete(1)).Returns(() => null);
        //     var service = mock.Object;
        //     Assert.Null(service.Delete(1));
        // }
    }
}