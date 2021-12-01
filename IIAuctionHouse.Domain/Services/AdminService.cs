using System.Collections.Generic;
using System.IO;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.Domain.Services
{
    public class AdminService: IAdminService
    {
        private readonly IAdminRepository _AdminRepository;

        public AdminService(IAdminRepository AdminRepository)
        {
            _AdminRepository = AdminRepository ?? throw new InvalidDataException("Admin Service can not be null");
        }

        public List<Admin> ReadAll()
        {
            return _AdminRepository.ReadAll();
        }

        public Admin GetById(int id)
        {
            if (id < 1) throw new InvalidDataException("Admin Id must be higher than 0");
            return _AdminRepository.GetById(id);
        }

        public Admin Create(string firstName, string lastName, Address address, Proprietary proprietary, Bid bid)
        {
            if (firstName is null || lastName is null || address is null || proprietary is null || bid is null)
                throw new InvalidDataException("One of the values is empty or entered incorrectly"); 
            return _AdminRepository.Create(firstName, lastName, address, proprietary, bid);
        }

        public Admin Update(Admin Admin)
        {
            if (Admin.FirstName is null || Admin.LastName is null || Admin.Address is null || Admin.Proprietary is null || Admin.Bid is null)
                throw new InvalidDataException("One of the values is empty or entered incorrectly");
            return _AdminRepository.Update(Admin);
        }

        public Admin Delete(int id)
        {
            if (id < 1) throw new InvalidDataException("Admin Id must be higher than 0");
            return _AdminRepository.Delete(id);
        }
    }
}