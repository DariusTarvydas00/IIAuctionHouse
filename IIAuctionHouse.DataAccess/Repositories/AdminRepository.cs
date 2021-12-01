using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.AccDetails;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.DataAccess.Repositories
{
    public class AdminRepository: IAdminRepository
    {
         private readonly MainDbContext _ctx;

        public AdminRepository(MainDbContext ctx)
        {
            if (ctx == null) throw new InvalidDataException("Non existing DbContext");
            _ctx = ctx;
        }

        public List<Admin> ReadAll()
        {
            return _ctx.Admins.Select(ae=>new Admin()
            {
                Id = ae.Id,
                FirstName = ae.FirstName,
                LastName = ae.LastName,
                Address = ae.Address,
                Proprietary = ae.Proprietary,
                Bid = ae.Bid
            }).ToList();
        }

        public Admin GetById(int id)
        {
            var AdminEntity = _ctx.Admins.Select(ae => new AdminEntity()
            {
                Id = ae.Id,
                FirstName = ae.FirstName,
                LastName = ae.LastName,
                Address = ae.Address,
                Proprietary = ae.Proprietary,
                Bid = ae.Bid
            }).FirstOrDefault();
            if (AdminEntity != null)
            {
                return new Admin()
                {
                    Id = AdminEntity.Id,
                    FirstName = AdminEntity.FirstName,
                    LastName = AdminEntity.LastName,
                    Address = AdminEntity.Address,
                    Proprietary = AdminEntity.Proprietary,
                    Bid = AdminEntity.Bid
                };
            }
            return null;
        }

        public Admin Create(string firstName, string lastName, Address address, List<Proprietary> proprietary,
            List<Bid> bid)
        {
            var entity = _ctx.Admins.Add(new AdminEntity()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                Proprietary = proprietary,
                Bid = bid
            }).Entity;
            return new Admin()
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Address = entity.Address,
                Proprietary = entity.Proprietary,
                Bid = entity.Bid
            };
        }

        public Admin Update(Admin Admin)
        {
            var entity = _ctx.Admins.Update(new AdminEntity()
            {
                Id = Admin.Id,
                FirstName = Admin.FirstName,
                LastName = Admin.LastName,
                Address = Admin.Address,
                Proprietary = Admin.Proprietary,
                Bid = Admin.Bid
            }).Entity;
            _ctx.SaveChanges();
            return new Admin()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Address = entity.Address,
                Proprietary = entity.Proprietary,
                Bid = entity.Bid
            };
        }

        public Admin Delete(int id)
        {
            var entity = _ctx.Admins.Remove(new AdminEntity()
            {
                Id = id
            }).Entity; 
            _ctx.SaveChanges();
            return new Admin()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Address = entity.Address,
                Proprietary = entity.Proprietary,
                Bid = entity.Bid
            };

        }
    }
}