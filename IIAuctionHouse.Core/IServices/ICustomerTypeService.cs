using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.IServices
{
    public interface ICustomerTypeService
    {
        List<CustomerType> GetAllCustomerTypes();
        CustomerType GetCustomerTypeById(int id);
        CustomerType CreateCustomerType(string name, List<Customer> customers);
        CustomerType UpdateCustomerType(Proprietary proprietary);
        CustomerType DeleteCustomerType(int id); 
    }
}