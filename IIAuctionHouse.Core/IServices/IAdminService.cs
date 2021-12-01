using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.IServices
{
    public interface IAdminService
    {
        List<Admin> ReadAll();
        Admin GetById(int id);
        Admin Create(string firstName, string lastName, Address address, Proprietary proprietary, Bid bid);
        Admin Update(Admin Admin);
        Admin Delete(int id);
    }
}