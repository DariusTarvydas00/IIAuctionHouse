using System;

namespace IIAuctionHouse.Core.Models.AccDetails
{
    public class AccDetails
    {
        public int Id { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public DateTime AccCreationDateTime { get; set; }
        
    }
}