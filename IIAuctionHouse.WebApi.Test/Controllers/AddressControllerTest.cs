using System.IO;
using System.Linq;
using System.Reflection;
using IIAuctionHouse.Controllers;
using IIAuctionHouse.Core.IServices;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace IIAuctionHouse.WebApi.Test.Controllers
{
    public class AddressControllerTest
    {
        #region Controller Initialization
        // Checks if AddressController has AddressService and is controller base type
        [Fact]
        public void AddressController_HasAddressService_IsTypeOfController()
        {
            var service = new Mock<IAddressService>();
            var controller = new AddressController(service.Object);
            Assert.IsAssignableFrom<ControllerBase>(controller);
        }
        
        // Checks if AddressController is null, throws exception
        [Fact]
        public void AddressController_WithNullAddressService_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new AddressController(null));
        }
        
        // Checks if AddressController is null, throws exception message
        [Fact]
        public void AddressController_WithNullAddressService_ThrowsInvalidDataExceptionMessage()
        {
            var expected = "Address Controller is not initialized";
            var actual = Assert.Throws<InvalidDataException>(() => new AddressController(null));
            Assert.Equal(expected,actual.Message);
        }
        
        // Checks if Address Controller uses Api Controller Attribute
        [Fact]
        public void AddressController_UsesApiControllerAttribute()
        {
            var typeInfo = typeof(AddressController).GetTypeInfo();
            var attribute = typeInfo.GetCustomAttributes()
                .FirstOrDefault(a => a.GetType().Name.Equals("ApiControllerAttribute"));
            Assert.NotNull(attribute);
        }

        #endregion
    }
}