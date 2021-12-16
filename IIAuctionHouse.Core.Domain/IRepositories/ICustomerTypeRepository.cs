using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.Domain.IRepositories
{
    public interface ICustomerTypeRepository
    {
        IEnumerable<CustomerType> ReadAll();
        CustomerType GetById(int id);
        CustomerType Create(CustomerType customerType);
        CustomerType Update(CustomerType updateCustomerType);
        CustomerType Delete(int id);
    }
}