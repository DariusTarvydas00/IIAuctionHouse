using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.IServices
{
    public interface IUserService
    {
        List<User> ReadAll();
        User GetById(int id);
        User Create(string firstName, string lastName, Address address, Proprietary proprietary, Bid bid);
        User Update(User user);
        User Delete(int id);
    }
}