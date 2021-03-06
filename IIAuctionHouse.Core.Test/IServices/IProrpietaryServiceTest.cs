using System.Collections.Generic;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using Moq;
using Xunit;

namespace IIAuctionHouse.Core.Test.IServices
{
    public class IProrpietaryServiceTest
    {
        // Checking if IProprietary is available
        [Fact]
        public void IProprietary_IsAvailable()
        {
            var service = new Mock<IProprietaryService>();
            Assert.NotNull(service);
        }
        
        // Checking if ReadAll method return a list
        [Fact]
        public void ReadAll_ReturnsListOfAllProprietaries()
        {
            var mock = new Mock<IProprietaryService>();
            var fakeList = new List<Proprietary>();
            mock.Setup(s => s.GetAllProprietaries()).Returns(fakeList);
            var service = mock.Object;
            Assert.Equal(fakeList,service.GetAllProprietaries());
        }
        
        // Checking if GetById returns a Proprietary object
        [Fact]
        public void GetById_Id_ReturnsProprietary()
        {
            var mock = new Mock<IProprietaryService>();
            var fakeList = new List<Proprietary>();
            var proprietary = new Proprietary()
            {
                Id = 1,
                CadastreNumber = "123/123/123",
                City = "Esbjerg",
                ForestryEnterprise = "EsbjergEnterprise",
                Bids = new List<Bid>()
            };
            fakeList.Add(proprietary);
            mock.Setup(s => s.GetProprietaryById(1)).Returns(fakeList.Find(a => a.Id == 1));
            var service = mock.Object;
            Assert.Equal(proprietary,service.GetProprietaryById(1));
        }
        
        // Checking if proprietary object is created
        [Fact]
        public void Create_Proprietary_IsCreated()
        {
            var mock = new Mock<IProprietaryService>();
            var fakeProprietary = new Proprietary()
            {
                Id = 1,
                CadastreNumber = "123/123/123",
                City = "Esbjerg",
                ForestryEnterprise = "EsbjergEnterprise"
            };
            mock.Setup(s => s.NewProprietary(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<Bid>>()))
                .Returns(() => fakeProprietary);
            var service = mock.Object;
            Assert.Equal(fakeProprietary,service.NewProprietary( "123/123/123", "EsbjergEnterprise", "Esbjerg",new List<Bid>()));
        }
        
        // Checking if proprietary object is updated
        [Fact]
        public void Update_proprietary_IsUpdated()
        {
            var mock = new Mock<IProprietaryService>();
            var fakeProprietary = new Proprietary()
            {
                Id = 1,
                CadastreNumber = "321/321/321",
                City = "Esbjerg",
                ForestryEnterprise = "EsbjergEnterprise"
            };
            mock.Setup(s => s.UpdateProprietary(fakeProprietary)).Returns(fakeProprietary);
            var service = mock.Object;
            Assert.Equal(fakeProprietary,service.UpdateProprietary(fakeProprietary));
        }
        
        // Checks if Delete method deletes object
        [Fact]
        public void Delete_Id_ReturnNull()
        {
            var mock = new Mock<IProprietaryService>();
            var fakeList = new List<Proprietary>();
            var proprietary = new Proprietary()
            {
                Id = 1,
                CadastreNumber = "321/321/321", 
                City = "Esbjerg",
                ForestryEnterprise = "EsbjergEnterprise"
            };
            fakeList.Add(proprietary);
            mock.Setup(s => s.DeleteProprietary(1)).Returns(() => null);
            var service = mock.Object;
            Assert.Null(service.DeleteProprietary(1));
        }
    }
}