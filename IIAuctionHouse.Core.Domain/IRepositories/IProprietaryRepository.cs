using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.Domain.IRepositories
{
    public interface IProprietaryRepository
    {
        IEnumerable<Proprietary> ReadAll();
        Proprietary Create(Proprietary proprietary);
        Proprietary Update(Proprietary updateProprietary);
        Proprietary Delete(int id);
        Proprietary ReadById(int id);
        Proprietary ReadProprietaryByIdIncludeBids(int id);
    }
} 