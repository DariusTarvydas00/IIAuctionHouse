using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.DataAccess.Repositories
{
    public class ProprietaryRepository:IProprietaryRepository
    {
        private readonly MainDbContext _ctx;

        public ProprietaryRepository(MainDbContext ctx)
        {
            if (ctx == null) throw new InvalidDataException("Non existing DbContext");
            _ctx = ctx;
        }

        public List<Proprietary> ReadAll()
        {
            return _ctx.Proprietaries.Select(ae => new Proprietary()
            {
                Id = ae.Id,
                CadastreNumber = ae.CadastreNumber,
                ForestryEnterprise = ae.ForestryEnterprise,
                City = ae.City
            }).ToList();
        }

        public Proprietary GetById(int id)
        {
            var proprietaryEntity = _ctx.Proprietaries.Select(ae => new ProprietaryEntity()
            {
                Id = ae.Id,
                CadastreNumber = ae.CadastreNumber,
                ForestryEnterprise = ae.ForestryEnterprise,
                City = ae.City
            }).FirstOrDefault();
            if (proprietaryEntity != null)
            {
                return new Proprietary()
                {
                    Id = proprietaryEntity.Id,
                    CadastreNumber = proprietaryEntity.CadastreNumber,
                    ForestryEnterprise = proprietaryEntity.ForestryEnterprise,
                    City = proprietaryEntity.City
                };
            }
            return null;
        }

        public Proprietary Create(string cadastreNumber, string forestryEnterprise, string city)
        {
            var entity = _ctx.Proprietaries.Add(new ProprietaryEntity()
            {
                CadastreNumber = cadastreNumber,
                ForestryEnterprise = forestryEnterprise,
                City = city
            }).Entity;
            return new Proprietary()
            {
                CadastreNumber = entity.CadastreNumber,
                ForestryEnterprise = entity.ForestryEnterprise,
                City = entity.City
            };
        }

        public Proprietary Update(Proprietary proprietary)
        {
            var entity = _ctx.Proprietaries.Update(new ProprietaryEntity()
            {
                Id = proprietary.Id,
                CadastreNumber = proprietary.CadastreNumber,
                ForestryEnterprise = proprietary.ForestryEnterprise,
                City = proprietary.City
            }).Entity;
            _ctx.SaveChanges();
            return new Proprietary()
            {
                Id = entity.Id,
                CadastreNumber = entity.CadastreNumber,
                ForestryEnterprise = entity.ForestryEnterprise,
                City = entity.City
            };
        }

        public Proprietary Delete(int id)
        {
            var entity = _ctx.Proprietaries.Remove(new ProprietaryEntity()
            {
                Id = id
            }).Entity;
            _ctx.SaveChanges();
            return new Proprietary()
            {
                Id = entity.Id,
                CadastreNumber = entity.CadastreNumber,
                ForestryEnterprise = entity.ForestryEnterprise,
                City = entity.City
            };
        }
    }
}