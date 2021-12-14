using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.Domain.Services
{
    public class ProprietaryService: IProprietaryService
    {
        private readonly IProprietaryRepository _proprietaryRepository;

        public ProprietaryService(IProprietaryRepository proprietaryRepository)
        {
            _proprietaryRepository = proprietaryRepository ?? throw new InvalidDataException("Proprietary Repository can not be null");;
        }

        public List<Proprietary> ReadAll()
        {
            return _proprietaryRepository.ReadAll().ToList();
        }

        public Proprietary GetById(int id)
        {
            if (id < 1) throw new InvalidDataException("Proprietary Id must be higher than 0");
            return _proprietaryRepository.GetById(id);
        }

        public Proprietary Create(string cadastreNumber, string forestryEnterprise, string City)
        {
            if (cadastreNumber is null || forestryEnterprise is null || City is null)
                throw new InvalidDataException("One of the values is empty or entered incorrectly"); 
            return _proprietaryRepository.Create(cadastreNumber, forestryEnterprise, City);
        }

        public Proprietary Update(Proprietary proprietary)
        {
            if (proprietary.CadastreNumber is null || proprietary.ForestryEnterprise is null || proprietary.City is null)
                throw new InvalidDataException("One of the values is empty or entered incorrectly");
            return _proprietaryRepository.Update(proprietary);
        }

        public Proprietary Delete(int id)
        {
            if (id < 1) throw new InvalidDataException("Proprietary Id must be higher than 0");
            return _proprietaryRepository.Delete(id);
        }
    }
}