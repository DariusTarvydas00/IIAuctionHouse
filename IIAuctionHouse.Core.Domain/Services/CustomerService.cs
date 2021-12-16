using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.Domain.Exceptions;
using IIAuctionHouse.Core.Domain.IRepositories;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.Domain.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository ?? throw new InvalidDataException(CustomerExceptions.CustomerRepoCannotBeNull);
        }

        public Customer NewCustomer(string firstName, string lastName, CustomerDetails customerDetails, CustomerType customerType,
            List<Bid> bids, List<Proprietary> proprietaries)
        {
            return new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                CustomerDetails = customerDetails,
                CustomerType = customerType,
                Bids = bids,
                Proprietaries = proprietaries
            };
        }

        public Customer CreateCustomer(Customer customer)
        {
            if (customer == null)
                throw new InvalidDataException(CustomerExceptions.CustomerIsIncorrect);
            if (customer.FirstName is null)
                throw new InvalidDataException(CustomerExceptions.CustomerFirstNameIncorrect);
            if (customer.LastName is null)
                throw new InvalidDataException(CustomerExceptions.CustomerLastNameIncorrect);
            if (customer.CustomerDetails is null)
                throw new InvalidDataException(CustomerExceptions.CustomerDetailsIncorrect);
            if (customer.CustomerType is null)
                throw new InvalidDataException(CustomerExceptions.CustomerTypeIncorrect);
            return _customerRepository.Create(customer);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.ReadAll().ToList();
        }

        public Customer GetCustomerById(int id)
        {
            if (id < 1)
                throw new InvalidDataException(CustomerExceptions.CustomerIdIncorrect);
            return _customerRepository.GetById(id);
        }

        public Customer GetCustomerByIdIncludeBids(int id)
        {
            if (id < 1)
                throw new InvalidDataException(CustomerExceptions.CustomerIdIncorrect);
            return _customerRepository.ReadyByIdIncludeBids(id);
        }

        public Customer GetCustomerByIdIncludeProprietaries(int id)
        {
            if (id < 1)
                throw new InvalidDataException(CustomerExceptions.CustomerIdIncorrect);
            return _customerRepository.ReadyByIdIncludeProprietaries(id);
        }

        public List<CustomerType> GetAllCustomerTypes()
        {
            return _customerRepository.ReadCustomerTypes();
        }

        public Customer UpdateCustomer(Customer customerUpdate)
        {
            if (customerUpdate == null)
                throw new InvalidDataException(CustomerExceptions.CustomerIsIncorrect);
            if (customerUpdate.FirstName is null)
                throw new InvalidDataException(CustomerExceptions.CustomerFirstNameIncorrect);
            if (customerUpdate.LastName is null)
                throw new InvalidDataException(CustomerExceptions.CustomerLastNameIncorrect);
            if (customerUpdate.CustomerDetails is null)
                throw new InvalidDataException(CustomerExceptions.CustomerDetailsIncorrect);
            if (customerUpdate.CustomerType is null)
                throw new InvalidDataException(CustomerExceptions.CustomerTypeIncorrect);
            return _customerRepository.Update(customerUpdate);
        }

        public Customer DeleteCustomer(int id)
        {
            if (id < 1)
                throw new InvalidDataException(CustomerExceptions.CustomerIdIncorrect);
            return _customerRepository.Delete(id);
        }
    }
}