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

        #endregion
    }
}