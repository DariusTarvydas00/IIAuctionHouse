using System.Collections.Generic;
using System.IO;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
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
        public ActionResult<List<Address>> GetAll()
        {
            return Ok(_addressService.ReadAll());
        }

        [HttpGet("id")]
        public ActionResult<Address> GetById([FromBody] int id)
        {
            var address = _addressService.GetById(id);
            return Ok(new Address()
            {
                Id = address.Id,
                Country = address.Country,
                City = address.City,
                PostCode = address.PostCode,
                StreetName = address.StreetName,
                StreetNumber = address.StreetNumber
            });
        }

        [HttpPost]
        public ActionResult<Address> Post([FromBody] Address address)
        {
            var addressUpdate = _addressService.Update(address);
            return Ok(new Address()
            {
                Id = addressUpdate.Id,
                Country = addressUpdate.Country,
                City = addressUpdate.City,
                PostCode = addressUpdate.PostCode,
                StreetName = addressUpdate.StreetName,
                StreetNumber = addressUpdate.StreetNumber
            });
        }

        [HttpDelete]
        public ActionResult<Address> Delete([FromBody] int id)
        {
            var address = _addressService.Delete(id);
            return Ok(new Address()
            {
                Id = address.Id,
                Country = address.Country,
                City = address.City,
                PostCode = address.PostCode,
                StreetName = address.StreetName,
                StreetNumber = address.StreetNumber 
            });
        }
    }
}