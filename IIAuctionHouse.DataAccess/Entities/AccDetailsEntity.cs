using System;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.DataAccess.Entities
{
    public class AccDetailsEntity
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; } 
        public DateTime AccCreationDateTime { get; set; }
    }
}