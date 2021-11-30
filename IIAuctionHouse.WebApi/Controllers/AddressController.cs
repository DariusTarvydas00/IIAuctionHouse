using System.IO;
using IIAuctionHouse.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController: ControllerBase
    {
        private readonly IAddressService _addressService;
        
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService ?? throw new InvalidDataException("Address Controller is not initialized");
        }

        [HttpGet]
        public AddressController GetAll()
        {
            return null;
        }

        [HttpGet("id")]
        public AddressController GetById([FromBody] int id)
        {
            return null;
        }

        [HttpPost]
        public AddressController Post([FromBody] int id)
        {
            return null;
        }

        [HttpDelete]
        public AddressController Delete([FromBody] int id)
        {
            return null;
        }
    }
}