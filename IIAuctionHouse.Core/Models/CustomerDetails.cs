﻿using System;

namespace IIAuctionHouse.Core.Models
{
    public class CustomerDetails
    {
        public int Id { get; set; } 
        public string Country { get; set; }
        public string City { get; set; }
        public int PostCode { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime AccCreationDateTime { get; set; }
    }
}