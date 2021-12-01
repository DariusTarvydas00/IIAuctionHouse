namespace IIAuctionHouse.Core.Models.AccDetails
{
    public class Address
    {
        public int Id { get; set; } 
        public string Country { get; set; }
        public string City { get; set; }
        public int PostCode { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
    }
}