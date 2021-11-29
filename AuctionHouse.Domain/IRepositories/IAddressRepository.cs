using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace AuctionHouse.Domain.IRepositories
{
    public interface IAddressRepository
    {
        List<Address> ReadAll();
    }
}