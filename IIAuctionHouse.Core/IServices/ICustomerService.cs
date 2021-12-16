using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.IServices
{
    public interface ICustomerService
    {
        Customer NewCustomer(string firstName, string lastName, CustomerDetails customerDetails, CustomerType customerType, 
            List<Bid> bids, List<Proprietary> proprietaries);
        Customer CreateCustomer(Customer customer);
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        Customer GetCustomerByIdIncludeBids(int id);
        Customer GetCustomerByIdIncludeProprietaries(int id);
        List<CustomerType> GetAllCustomerTypes();
        Customer UpdateCustomer(Customer customerUpdate);
        Customer DeleteCustomer(int id);
    }
}