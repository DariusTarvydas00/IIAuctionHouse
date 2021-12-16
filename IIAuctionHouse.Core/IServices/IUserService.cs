using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.IServices
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User CreateUser(User user, string password);
        User SignIn(User user, string password);
        List<User> ReadAllUsers();
        User GetUserById(int id);
        User CreateUser(string userName, string email, string passwordHash, Role role);
        User UpdateUser(User user);
        User DeleteUser(int id);
    }
}