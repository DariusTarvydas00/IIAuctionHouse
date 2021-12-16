using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.IServices
{
    public interface IRoleService
    {
        List<Role> GetAllRoles();
        Role GetRoleById(int id);
        Role CreateRole(string name, List<User> users);
        Role UpdateRole(User user);
        Role DeleteRole(int id);
    }
}