using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.Domain.IRepositories
{
    public interface ICustomerDetailsRepository
    {
        IEnumerable<CustomerDetails> ReadAll();
        CustomerDetails ReadById(int id);
        CustomerDetails Create(CustomerDetails customerDetails);
        CustomerDetails Update(CustomerDetails updateCustomerDetails);
        CustomerDetails Delete(int id);
        
    }
}