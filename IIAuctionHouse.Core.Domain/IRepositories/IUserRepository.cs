using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.Domain.IRepositories
{
    public interface IUserRepository
    {
        IEnumerable<User> ReadAll();
        User GetById(int id);
        User Create(User user);
        User Update(User updateUser);
        User Delete(int id);
    }
}