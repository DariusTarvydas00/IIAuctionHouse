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
            return Ok(_proprietaryService.ReadAll());
        }

        [HttpGet("id")]
        public ActionResult<Proprietary> GetById([FromBody] int id)
        {
            var Proprietary = _proprietaryService.GetById(id);
            return Ok(new Proprietary()
            {
                Id = Proprietary.Id,
                CadastreNumber = Proprietary.CadastreNumber,
                ForestryEnterprise = Proprietary.ForestryEnterprise,
                City = Proprietary.City
            });
        }

        [HttpPost]
        public ActionResult<Proprietary> Post([FromBody] Proprietary Proprietary)
        {
            var ProprietaryUpdate = _proprietaryService.Update(Proprietary);
            return Ok(new Proprietary()
            {
                Id = ProprietaryUpdate.Id,
                CadastreNumber = ProprietaryUpdate.CadastreNumber,
                ForestryEnterprise = ProprietaryUpdate.ForestryEnterprise,
                City = ProprietaryUpdate.City
            });
        }

        [HttpDelete]
        public ActionResult<Proprietary> Delete([FromBody] int id)
        {
            var Proprietary = _proprietaryService.Delete(id);
            return Ok(new Proprietary()
            {
                Id = Proprietary.Id,
                CadastreNumber = Proprietary.CadastreNumber,
                ForestryEnterprise = Proprietary.ForestryEnterprise,
                City = Proprietary.City
            });
        }
    }
}