using System.Collections.Generic;
using System.IO;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccDetailsController: ControllerBase
    {
        private readonly IAccDetailsService _accDetailsService;
        
        public AccDetailsController(IAccDetailsService accDetailsService)
        {
            _accDetailsService = accDetailsService ?? throw new InvalidDataException("AccDetails Controller is not initialized");
        }

        [HttpGet]
        public ActionResult<List<AccDetails>> GetAll()
        {
            return Ok(_accDetailsService.ReadAll());
        }

        [HttpGet("id")]
        public ActionResult<AccDetails> GetById([FromBody] int id)
        {
            var accDetails = _accDetailsService.GetById(id);
            return Ok(new AccDetails()
            {
                Id = accDetails.Id,
                Address = accDetails.Address,
                Email = accDetails.Email,
                PhoneNumber = accDetails.PhoneNumber,
                AccCreationDateTime = accDetails.AccCreationDateTime
            });
        }

        [HttpPost]
        public ActionResult<AccDetails> Post([FromBody] AccDetails accDetails)
        {
            var accDetailsUpdate = _accDetailsService.Update(accDetails);
            return Ok(new AccDetails()
            {
                Id = accDetails.Id,
                Address = accDetails.Address,
                Email = accDetails.Email,
                PhoneNumber = accDetails.PhoneNumber,
                AccCreationDateTime = accDetails.AccCreationDateTime
            });
        }

        [HttpDelete]
        public ActionResult<AccDetails> Delete([FromBody] int id)
        {
            var accDetails = _accDetailsService.Delete(id);
            return Ok(new AccDetails()
            {
                Id = accDetails.Id,
                Address = accDetails.Address,
                Email = accDetails.Email,
                PhoneNumber = accDetails.PhoneNumber,
                AccCreationDateTime = accDetails.AccCreationDateTime
            });
        }
    }
}