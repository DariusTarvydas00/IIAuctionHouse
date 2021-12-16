using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.Domain.Exceptions;
using IIAuctionHouse.Core.Domain.IRepositories;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.Domain.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new InvalidDataException(UserExceptions.UserRepoInvalid);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.ReadAll().ToList();
        }

        public User CreateUser(User user, string readablePassword)
        {
            throw new System.NotImplementedException();
        }

        public User SignIn(User user, string readablePassword)
        {
            throw new System.NotImplementedException();
        }

        public List<User> ReadAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public User GetUserById(int id)
        {
            if (id < 1) throw new InvalidDataException("User Id must be higher than 0");
            return _userRepository.GetById(id);
        }

        public User CreateUser(string userName, string email, string passwordHash, Role role)
        {
            throw new System.NotImplementedException();
        }

        public User CreateUser(User user)
        {
            // if (user is null)
            //     throw new InvalidDataException(UserExceptions.UserInvalid);
            // if (user.UserName is null)
            //     throw new InvalidDataException(UserExceptions.UserNameInvalid);
            // if (user.Email is null)
            //     throw new InvalidDataException(UserExceptions.UserEmailInvalid);
            // if (user.Role is null)
            //     throw new InvalidDataException(UserExceptions.UserRoleInvalid);
            // if (user.PasswordHash is null)
            //     throw new InvalidDataException(UserExceptions.UserPasswordHashInvalid);
             return _userRepository.Create(user);
        }

        public User UpdateUser(User user)
        {
            // if (user is null)
            //     throw new InvalidDataException(UserExceptions.UserInvalid);
            // if (user.UserName is null)
            //     throw new InvalidDataException(UserExceptions.UserNameInvalid);
            // if (user.Email is null)
            //     throw new InvalidDataException(UserExceptions.UserEmailInvalid);
            // if (user.Role is null)
            //     throw new InvalidDataException(UserExceptions.UserRoleInvalid);
            // if (user.PasswordHash is null)
            //     throw new InvalidDataException(UserExceptions.UserPasswordHashInvalid);
             return _userRepository.Update(user);
        }

        public User DeleteUser(int id)
        {
            if (id < 1) 
                throw new InvalidDataException(UserExceptions.UserIdInvalid);
            return _userRepository.Delete(id);
        }
    }
}