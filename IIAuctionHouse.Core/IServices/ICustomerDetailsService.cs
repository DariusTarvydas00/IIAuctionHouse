using System;
using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.IServices
{
    public interface ICustomerDetailsService
    {
        CustomerDetails NewCustomerDetails(string country, string city, int postCode, string streetName,
            int streetNumber, int phoneNumber, string email, DateTime accCreationDate);
        CustomerDetails CreateCustomerDetails(CustomerDetails customerDetails);
        List<CustomerDetails> GetAllCustomerDetails();
        CustomerDetails GetCustomerDetailsById(int id);
        CustomerDetails UpdateCustomerDetails(CustomerDetails customerDetailsUpdate);
        CustomerDetails DeleteCustomerDetails(int id);
    }
}