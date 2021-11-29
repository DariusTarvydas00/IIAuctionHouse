using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.IServices
{
    public interface IAddressService
    {
        List<Address> ReadAll();
    }
}