using System.Collections.Generic;
using System.IO;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProprietaryController : Controller
    {
        private readonly IProprietaryService _proprietaryService;
        
        public ProprietaryController(IProprietaryService proprietaryService)
        {
            _proprietaryService = proprietaryService ?? throw new InvalidDataException("Proprietary Controller is not initialized");
        }

        [HttpGet]
        public ActionResult<List<Proprietary>> GetAll()
        {
            return Ok(_proprietaryService.GetAllProprietaries());
        }

        [HttpGet("id")]
        public ActionResult<Proprietary> GetById([FromQuery] int id)
        {
            var proprietary = _proprietaryService.GetProprietaryById(id);
            return Ok(new Proprietary()
            {
                Id = proprietary.Id,
                CadastreNumber = proprietary.CadastreNumber,
                ForestryEnterprise = proprietary.ForestryEnterprise,
                City = proprietary.City
            });
        }
        //
        // [HttpGet("id")]
        // public ActionResult<Proprietary> GetProprietaryByIdWithBids([FromBody] int id)
        // {
        //     var proprietary = _proprietaryService.GetProprietaryByIdIncludeBids(id);
        //     return Ok(new Proprietary()
        //     {
        //         Id = proprietary.Id,
        //         CadastreNumber = proprietary.CadastreNumber,
        //         ForestryEnterprise = proprietary.ForestryEnterprise,
        //         City = proprietary.City
        //     });
        // }

        [HttpPost]
        public ActionResult<Proprietary> Post([FromBody] Proprietary proprietary)
        {
            var proprietaryUpdate = _proprietaryService.UpdateProprietary(proprietary);
            return Ok(new Proprietary()
            {
                Id = proprietaryUpdate.Id,
                CadastreNumber = proprietaryUpdate.CadastreNumber,
                ForestryEnterprise = proprietaryUpdate.ForestryEnterprise,
                City = proprietaryUpdate.City
            });
        }

        [HttpDelete]
        public ActionResult<Proprietary> Delete([FromQuery] int id)
        {
            var proprietary = _proprietaryService.DeleteProprietary(id);
            return Ok(new Proprietary()
            {
                Id = proprietary.Id,
                CadastreNumber = proprietary.CadastreNumber,
                ForestryEnterprise = proprietary.ForestryEnterprise,
                City = proprietary.City
            });
        }
    }
} 