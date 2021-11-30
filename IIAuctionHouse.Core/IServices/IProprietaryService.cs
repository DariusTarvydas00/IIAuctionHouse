using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.IServices
{
    public interface IProprietaryService
    {
        
        List<Proprietary> ReadAll();
        Proprietary GetById(int id);
        Proprietary Create(string cadastreNumber, string forestryEnterprise, string City);
        Proprietary Update(Proprietary proprietary);
        Proprietary Delete(int id);
    }
}