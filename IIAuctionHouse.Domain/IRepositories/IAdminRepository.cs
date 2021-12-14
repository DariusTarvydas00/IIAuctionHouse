﻿using System.Collections.Generic;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.AccDetails;

namespace IIAuctionHouse.Domain.IRepositories
{
    public interface IAdminRepository
    {
        IEnumerable<Admin> ReadAll();
        Admin GetById(int id);
        Admin Create(string firstName, string lastName, Address address, List<Proprietary> proprietary, List<Bid> bid);
        Admin Update(Admin Admin);
        Admin Delete(int id);
    }
}