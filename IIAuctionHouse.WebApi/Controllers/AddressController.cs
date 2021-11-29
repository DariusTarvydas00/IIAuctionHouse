using IIAuctionHouse.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.Controllers
{
    public class AddressController: ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }
    }
}