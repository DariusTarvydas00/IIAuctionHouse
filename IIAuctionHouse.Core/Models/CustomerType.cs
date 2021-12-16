using System.Collections.Generic;

namespace IIAuctionHouse.Core.Models
{
    public class CustomerType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Customer> Customers { get; set; }
    }
}