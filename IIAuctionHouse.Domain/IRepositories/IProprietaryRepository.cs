using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Domain.IRepositories
{
    public interface IProprietaryRepository
    {
        IEnumerable<Proprietary> ReadAll();
        Proprietary GetById(int id);
        Proprietary Create(string cadastreNumber, string forestryEnterprise, string city);
        Proprietary Update(Proprietary proprietary);
        Proprietary Delete(int id);
    }
} 