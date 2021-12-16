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
            return Ok(_bidService.GetAllBids());
        }

        [HttpGet("id")]
        public ActionResult<Bid> GetById([FromQuery] int id)
        {
            var bid = _bidService.GetBidById(id);
            return Ok(new Bid()
            {
                Id = bid.Id,
                BidAmount = bid.BidAmount,
                BidDateTime = bid.BidDateTime
            });
        }

        [HttpPost]
        public ActionResult<Bid> Post([FromBody] Bid bid)
        {
            var bidUpdate = _bidService.UpdateBid(bid);
            return Ok(new Bid()
            {
                Id = bidUpdate.Id,
                BidAmount = bidUpdate.BidAmount,
                BidDateTime = bidUpdate.BidDateTime
            });
        }

        [HttpDelete]
        public ActionResult<Bid> Delete([FromQuery] int id)
        {
            var bid = _bidService.DeleteBid(id);
            return Ok(new Bid()
            {
                Id = bid.Id,
                BidAmount = bid.BidAmount,
                BidDateTime = bid.BidDateTime
            });
        }
    } 
}