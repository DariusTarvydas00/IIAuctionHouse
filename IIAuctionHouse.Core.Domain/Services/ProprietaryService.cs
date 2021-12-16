using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.Domain.Exceptions;
using IIAuctionHouse.Core.Domain.IRepositories;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.Domain.Services
{
    public class ProprietaryService: IProprietaryService
    {
        private readonly IProprietaryRepository _proprietaryRepository;
        private readonly IBidRepository _bidRepository;

        public ProprietaryService(IProprietaryRepository proprietaryRepository, IBidRepository bidRepository)
        {
            _proprietaryRepository = proprietaryRepository ?? throw new InvalidDataException(ProprietaryExceptions.PropRepoCannotBeNull);
            _bidRepository = bidRepository ?? throw new InvalidDataException(BidExceptions.BidRepoCannotBeNull);
        }

        public Proprietary NewProprietary(string cadastreNumber, string forestryEnterprise, string city, List<Bid> bids)
        {
            return new Proprietary()
            {
                CadastreNumber = cadastreNumber,
                ForestryEnterprise = forestryEnterprise,
                City = city
            };
        }

        public Proprietary CreateProprietary(Proprietary proprietary)
        {
            if (proprietary is null)
                throw new InvalidDataException(ProprietaryExceptions.PropIncorrect);
            if (proprietary.CadastreNumber is null)
                throw new InvalidDataException(ProprietaryExceptions.PropCadastreIncorrect);
            if (proprietary.ForestryEnterprise is null)
                throw new InvalidDataException(ProprietaryExceptions.PropForestryEnterpriseIncorrect);
            if (proprietary.City is null)
                throw new InvalidDataException(ProprietaryExceptions.PropCityIncorrect);
            return _proprietaryRepository.Create(proprietary);
        }
        
        public Proprietary GetProprietaryById(int id)
        {
            if (id < 1)
                throw new InvalidDataException(ProprietaryExceptions.PropIdIncorrect);
            return _proprietaryRepository.ReadById(id);
        }
        
        public Proprietary GetProprietaryByIdIncludeBids(int id)
        {
            if (id < 1)
                throw new InvalidDataException(ProprietaryExceptions.PropIdIncorrect);
            return _proprietaryRepository.ReadProprietaryByIdIncludeBids(id);
        }

        public List<Proprietary> GetAllProprietaries()
        {
            return _proprietaryRepository.ReadAll().ToList();
        }

        public List<Bid> GetAllProprietaryBids()
        {
            return _bidRepository.ReadAll().ToList();
        }

        public Proprietary DeleteProprietary(int id)
        {
            throw new System.NotImplementedException();
        }

        public Proprietary UpdateProprietary(Proprietary proprietaryUpdate)
        {
            if (proprietaryUpdate is null)
                throw new InvalidDataException(ProprietaryExceptions.PropIncorrect);
            if (proprietaryUpdate.CadastreNumber is null)
                throw new InvalidDataException(ProprietaryExceptions.PropCadastreIncorrect);
            if (proprietaryUpdate.ForestryEnterprise is null)
                throw new InvalidDataException(ProprietaryExceptions.PropForestryEnterpriseIncorrect);
            if (proprietaryUpdate.City is null)
                throw new InvalidDataException(ProprietaryExceptions.PropCityIncorrect);
            return _proprietaryRepository.Update(proprietaryUpdate);
        }

        public Proprietary Delete(int id)
        {
            if (id < 1) 
                throw new InvalidDataException(ProprietaryExceptions.PropIdIncorrect);
            return _proprietaryRepository.Delete(id);
        }
    }
}