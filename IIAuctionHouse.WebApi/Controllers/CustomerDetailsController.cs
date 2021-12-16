using System.Collections.Generic;
using System.IO;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDetailsController: ControllerBase
    {
        private readonly ICustomerDetailsService _customerDetails;
        
        public CustomerDetailsController(ICustomerDetailsService customerDetailsService)
        {
            _customerDetails = customerDetailsService ?? throw new InvalidDataException("Address Controller is not initialized");
        }

        [HttpGet]
        public ActionResult<List<CustomerDetails>> GetAll()
        {
            return Ok(_customerDetails.GetAllCustomerDetails());
        }

        [HttpGet("id")]
        public ActionResult<CustomerDetails> GetById([FromQuery] int id)
        {
            var address = _customerDetails.GetCustomerDetailsById(id);
            return Ok(new CustomerDetails()
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
        public ActionResult<CustomerDetails> Post([FromBody] CustomerDetails address)
        {
            var addressUpdate = _customerDetails.UpdateCustomerDetails(address);
            return Ok(new CustomerDetails()
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
        public ActionResult<CustomerDetails> Delete([FromQuery] int id)
        {
            var address = _customerDetails.DeleteCustomerDetails(id);
            return Ok(new CustomerDetails()
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