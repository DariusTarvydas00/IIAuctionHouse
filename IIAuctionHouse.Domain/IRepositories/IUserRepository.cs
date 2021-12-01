using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Domain.IRepositories
{
    public interface IUserRepository
    {
        List<User> ReadAll();
        User GetById(int id);
        User Create(string firstName, string lastName, Address address, Proprietary proprietary, Bid bid);
        User Update(User user);
        User Delete(int id);
    }
}