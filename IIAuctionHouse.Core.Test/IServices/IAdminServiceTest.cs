using System.Collections.Generic;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.AccDetails;
using Moq;
using Xunit;

namespace IIAuctionHouse.Core.Test.IServices
{
    public class IAdminServiceTest
    {
          // Checking if IAdminService is available
        [Fact]
        public void IAdminService_IsAvailable()
        {
            var service = new Mock<IAdminService>();
            Assert.NotNull(service);
        }
        
        // Checking if ReadAll method return a list
        [Fact]
        public void ReadAll_NoParam_ReturnsListOfAllAdmines()
        {
            var mock = new Mock<IAdminService>();
            var fakeList = new List<Admin>();
            mock.Setup(s => s.ReadAll()).Returns(fakeList);
            var service = mock.Object;
            Assert.Equal(fakeList,service.ReadAll());
        }
        
        // Checking if GetById returns a Admin object
        [Fact]
        public void GetById_Id_ReturnsAdmin()
        {
            var mock = new Mock<IAdminService>();
            var fakeList = new List<Admin>();
            var Admin = new Admin()
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "Admin",
                Address = new Address(),
                Proprietaries = new List<Proprietary>(),
                Bids = new List<Bid>()
            };
            fakeList.Add(Admin);
            mock.Setup(s => s.GetById(1)).Returns(fakeList.Find(a => a.Id == 1));
            var service = mock.Object;
            Assert.Equal(Admin,service.GetById(1));
        }
        
        // Checking if Admin object is created
        [Fact]
        public void Create_AllAdminProperties_IsCreated()
        {
            var mock = new Mock<IAdminService>();
            var fakeAdmin = new Admin()
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "Admin",
                Address = new Address(),
                Proprietaries = new List<Proprietary>(),
                Bids = new List<Bid>()
            };
            mock.Setup(s => s.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Address>(), It.IsAny<List<Proprietary>>(), It.IsAny<List<Bid>>()))
                .Returns(() => fakeAdmin);
            var service = mock.Object;
            Assert.Equal(fakeAdmin,service.Create("Admin", "Admin", new Address(), new List<Proprietary>(), new List<Bid>()));
        }
        
        // Checking if Admin object is updated
        [Fact]
        public void Update_Admin_IsUpdated()
        {
            var mock = new Mock<IAdminService>();
            var fakeAdmin = new Admin()
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "Admin",
                Address = new Address(),
                Proprietaries = new List<Proprietary>(),
                Bids = new List<Bid>()
            };
            var newFakeAdmin = new Admin()
            {
                Id = 1,
                FirstName = "Admin2",
                LastName = "Admin2",
                Address = new Address(),
                Proprietaries = new List<Proprietary>(),
                Bids = new List<Bid>()
            };
            mock.Setup(s => s.Update(newFakeAdmin)).Returns(newFakeAdmin);
            var service = mock.Object;
            Assert.Equal(newFakeAdmin,service.Update(newFakeAdmin));
        }
        
        // Checks if Delete method deletes object
        [Fact]
        public void Delete_Id_ReturnNull()
        {
            var mock = new Mock<IAdminService>();
            var fakeList = new List<Admin>();
            var Admin = new Admin()
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "Admin",
                Address = new Address(),
                Proprietaries = new List<Proprietary>(),
                Bids = new List<Bid>()
            };
            fakeList.Add(Admin);
            mock.Setup(s => s.Delete(1)).Returns(() => null);
            var service = mock.Object;
            Assert.Null(service.Delete(1));
        }
    }
}