using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.IServices
{
    public interface IProprietaryService
    {
        Proprietary NewProprietary(string cadastreNumber, string forestryEnterprise, string city, List<Bid> bids);
        Proprietary CreateProprietary(Proprietary proprietary);
        List<Proprietary> GetAllProprietaries();
        Proprietary GetProprietaryById(int id);
        Proprietary GetProprietaryByIdIncludeBids(int id);
        Proprietary UpdateProprietary(Proprietary proprietaryUpdate);
        Proprietary DeleteProprietary(int id); 
    }
}