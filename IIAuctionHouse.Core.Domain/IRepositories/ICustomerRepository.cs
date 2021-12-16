using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.Domain.IRepositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> ReadAll();
        Customer GetById(int id);
        Customer Create(Customer customer);
        Customer Update(Customer updateCustomer);
        Customer Delete(int id);
        Customer ReadyByIdIncludeBids(int id);
        Customer ReadyByIdIncludeProprietaries(int id);
        List<CustomerType> ReadCustomerTypes();
    }
}