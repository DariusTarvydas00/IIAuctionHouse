using System.Collections.Generic;
using System.IO;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.Domain.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new InvalidDataException("User Service can not be null");
        }

        public List<User> ReadAll()
        {
            return _userRepository.ReadAll();
        }

        public User GetById(int id)
        {
            if (id < 1) throw new InvalidDataException("User Id must be higher than 0");
            return _userRepository.GetById(id);
        }

        public User Create(string firstName, string lastName, Address address, List<Proprietary> proprietary, List<Bid> bid)
        {
            if (firstName is null || lastName is null || address is null || proprietary is null || bid is null)
                throw new InvalidDataException("One of the values is empty or entered incorrectly"); 
            return _userRepository.Create(firstName, lastName, address, proprietary, bid);
        }

        public User Update(User User)
        {
            if (User.FirstName is null || User.LastName is null || User.Address is null || User.Proprietary is null || User.Bid is null)
                throw new InvalidDataException("One of the values is empty or entered incorrectly");
            return _userRepository.Update(User);
        }

        public User Delete(int id)
        {
            if (id < 1) throw new InvalidDataException("User Id must be higher than 0");
            return _userRepository.Delete(id);
        }
    }
}