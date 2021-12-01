using System.Collections.Generic;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.AccDetails;

namespace IIAuctionHouse.Core.IServices
{
    public interface IUserService
    {
        List<User> ReadAll();
        User GetById(int id);
        User Create(string firstName, string lastName, Address address, List<Proprietary> proprietary, List<Bid> bid);
        User Update(User user);
        User Delete(int id);
    }
}