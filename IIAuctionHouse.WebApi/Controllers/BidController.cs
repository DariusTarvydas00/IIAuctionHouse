using System.Collections.Generic;
using System.IO;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace IIAuctionHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidController: ControllerBase
    {
        private readonly IBidService _bidService;
        
        public BidController(IBidService bidService)
        {
            _bidService = bidService ?? throw new InvalidDataException("Bid Controller is not initialized");
        }

        [HttpGet]
        public ActionResult<List<Bid>> GetAll()
        {
            return Ok(_bidService.ReadAll());
        }

        [HttpGet("id")]
        public ActionResult<Bid> GetById([FromBody] int id)
        {
            var Bid = _bidService.GetById(id);
            return Ok(new Bid()
            {
                Id = Bid.Id,
                BidAmount = Bid.BidAmount,
                BidDateTime = Bid.BidDateTime
            });
        }

        [HttpPost]
        public ActionResult<Bid> Post([FromBody] Bid Bid)
        {
            var BidUpdate = _bidService.Update(Bid);
            return Ok(new Bid()
            {
                Id = BidUpdate.Id,
                BidAmount = BidUpdate.BidAmount,
                BidDateTime = BidUpdate.BidDateTime
            });
        }

        [HttpDelete]
        public ActionResult<Bid> Delete([FromBody] int id)
        {
            var Bid = _bidService.Delete(id);
            return Ok(new Bid()
            {
                Id = Bid.Id,
                BidAmount = Bid.BidAmount,
                BidDateTime = Bid.BidDateTime
            });
        }
    } 
}