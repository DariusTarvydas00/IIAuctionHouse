using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.Domain.Exceptions;
using IIAuctionHouse.Core.Domain.IRepositories;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.Domain.Services
{
    public class CustomerDetailsService : ICustomerDetailsService
    {
        private readonly ICustomerDetailsRepository _customerDetailsRepository;

        public CustomerDetailsService(ICustomerDetailsRepository customerDetails)
        {
            _customerDetailsRepository = customerDetails ?? throw new InvalidDataException(CustomerDetailsExceptions.CustomerDetailsRepoCannotBeNull);
        }
        
        public CustomerDetails NewCustomerDetails(string country, string city, int postCode, string streetName, int streetNumber,
            int phoneNumber, string email, DateTime accCreationDate)
        {
            return new CustomerDetails()
            {
                Country = country,
                City = city,
                PostCode = postCode,
                StreetName = streetName,
                StreetNumber = streetNumber,
                PhoneNumber = phoneNumber,
                Email = email,
                AccCreationDateTime = accCreationDate
            };
        }

        public CustomerDetails CreateCustomerDetails(CustomerDetails customerDetails)
        {
            if (customerDetails == null)
                throw new InvalidDataException(CustomerDetailsExceptions.CustomerDetailsIncorrect);
            if (customerDetails.Country is null)
                throw new InvalidDataException(CustomerDetailsExceptions.CustomerDetailsCountryIncorrect);
            if (customerDetails.City is null)
                throw new InvalidDataException(CustomerDetailsExceptions.CustomerDetailsCityIncorrect);
            if (customerDetails.PostCode < 1)
                throw new InvalidDataException(CustomerDetailsExceptions.CustomerDetailsPostCodeIncorrect);
            if (customerDetails.StreetName is null)
                throw new InvalidDataException(CustomerDetailsExceptions.CustomerDetailsStreetNameIncorrect);
            if (customerDetails.StreetNumber < 1)
                throw new InvalidDataException(CustomerDetailsExceptions.CustomerDetailsStreetNumberIncorrect);
            if (customerDetails.PhoneNumber < 1)
                throw new InvalidDataException(CustomerDetailsExceptions.CustomerDetailsPhoneNumberIncorrect);
            if (customerDetails.Email is null)
                throw new InvalidDataException(CustomerDetailsExceptions.CustomerDetailsEmailIncorrect);
            if (customerDetails.AccCreationDateTime == null || customerDetails.AccCreationDateTime == DateTime.MinValue)
                throw new InvalidDataException(CustomerDetailsExceptions.CustomerDetailsAccountCreationDateIncorrect);
            return _customerDetailsRepository.Create(customerDetails);
        }

        public List<CustomerDetails> GetAllCustomerDetails()
        {
            return _customerDetailsRepository.ReadAll().ToList();
        }

        public CustomerDetails GetCustomerDetailsById(int id)
        {
            if (id < 1)
                throw new InvalidDataException(CustomerDetailsExceptions.CustomerDetailsIdIncorrect);
            return _customerDetailsRepository.ReadById(id);
        }

        public CustomerDetails UpdateCustomerDetails(CustomerDetails customerDetailsUpdate)
        {
            if (customerDetailsUpdate == null)
                throw new InvalidDataException(CustomerDetailsExceptions.CustomerDetailsIncorrect);
            if (customerDetailsUpdate.Country is null)
                throw new InvalidDataException(CustomerDetailsExceptions.CustomerDetailsCountryIncorrect);
            if (customerDetailsUpdate.City is null)
                throw new InvalidDataException(CustomerDetailsExceptions.CustomerDetailsCityIncorrect);
            if (customerDetailsUpdate.PostCode < 1)
                throw new InvalidDataException(CustomerDetailsExceptions.CustomerDetailsPostCodeIncorrect);
            if (customerDetailsUpdate.StreetName is null)
                throw new InvalidDataException(CustomerDetailsExceptions.CustomerDetailsStreetNameIncorrect);
            if (customerDetailsUpdate.StreetNumber < 1)
                throw new InvalidDataException(CustomerDetailsExceptions.CustomerDetailsStreetNumberIncorrect);
            if (customerDetailsUpdate.PhoneNumber < 1)
                throw new InvalidDataException(CustomerDetailsExceptions.CustomerDetailsPhoneNumberIncorrect);
            if (customerDetailsUpdate.Email is null)
                throw new InvalidDataException(CustomerDetailsExceptions.CustomerDetailsEmailIncorrect);
            if (customerDetailsUpdate.AccCreationDateTime == null || customerDetailsUpdate.AccCreationDateTime == DateTime.MinValue)
                throw new InvalidDataException(CustomerDetailsExceptions.CustomerDetailsAccountCreationDateIncorrect);
            return _customerDetailsRepository.Update(customerDetailsUpdate);
        }

        public CustomerDetails DeleteCustomerDetails(int id)
        {
            if (id < 1) 
                throw new InvalidDataException(CustomerDetailsExceptions.CustomerDetailsIdIncorrect);
            return _customerDetailsRepository.Delete(id);
        }
    }
}