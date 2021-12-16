using System.Collections.Generic;


namespace IIAuctionHouse.DataAccess.Repositories
{
    // public class UserRepository: IUserRepository
    // {
    //     private readonly AuctionHouseDbContext _ctx;
    //
    //     public UserRepository(AuctionHouseDbContext ctx)
    //     {
    //         if (ctx == null) throw new InvalidDataException("Non existing DbContext");
    //         _ctx = ctx;
    //     }
    //
    //     public IEnumerable<User> ReadAll()
    //     {
    //         return _ctx.Users.Select(ae=>new User()
    //         {
    //             Id = ae.Id,
    //             FirstName = ae.FirstName,
    //             LastName = ae.LastName,
    //          //   Address = ae.Address,
    //          //   Proprietaries = ae.Proprietary,
    //          //   Bids = ae.Bid
    //         }).ToList();
    //     }
    //
    //     public User GetById(int id)
    //     {
    //         var UserEntity = _ctx.Users.Select(ae => new UserEntity()
    //         {
    //             Id = ae.Id,
    //             FirstName = ae.FirstName,
    //             LastName = ae.LastName,
    //           //  Address = ae.Address,
    //           //  Proprietary = ae.Proprietary,
    //           //  Bid = ae.Bid
    //         }).FirstOrDefault();
    //         if (UserEntity != null)
    //         {
    //             return new User()
    //             {
    //                 Id = UserEntity.Id,
    //                 FirstName = UserEntity.FirstName,
    //                 LastName = UserEntity.LastName,
    //              //   Address = UserEntity.Address,
    //              //   Proprietaries = UserEntity.Proprietary,
    //              //   Bids = UserEntity.Bid
    //             };
    //         }
    //         return null;
    //     }
    //
    //     public User Create(string firstName, string lastName, Address address, List<Proprietary> proprietary,
    //         List<Bid> bid)
    //     {
    //         var entity = _ctx.Users.Add(new UserEntity()
    //         {
    //             FirstName = firstName,
    //             LastName = lastName,
    //          //   Address = address,
    //          //   Proprietary = proprietary,
    //          //   Bid = bid
    //         }).Entity;
    //         return new User()
    //         {
    //             FirstName = entity.FirstName,
    //             LastName = entity.LastName,
    //          //   Address = entity.Address,
    //          //   Proprietaries = entity.Proprietary,
    //          //   Bids = entity.Bid
    //         };
    //     }
    //
    //     public User Update(User User)
    //     {
    //         var entity = _ctx.Users.Update(new UserEntity()
    //         {
    //             Id = User.Id,
    //             FirstName = User.FirstName,
    //             LastName = User.LastName,
    //           //  Address = User.Address,
    //           //  Proprietary = User.Proprietaries,
    //           //  Bid = User.Bids
    //         }).Entity;
    //         _ctx.SaveChanges();
    //         return new User()
    //         {
    //             Id = entity.Id,
    //             FirstName = entity.FirstName,
    //             LastName = entity.LastName,
    //           //  Address = entity.Address,
    //           //  Proprietaries = entity.Proprietary,
    //           //  Bids = entity.Bid
    //         };
    //     }
    //
    //     public User Delete(int id)
    //     {
    //         var entity = _ctx.Users.Remove(new UserEntity()
    //         {
    //             Id = id
    //         }).Entity; 
    //         _ctx.SaveChanges();
    //         return new User()
    //         {
    //             Id = entity.Id,
    //             FirstName = entity.FirstName,
    //             LastName = entity.LastName,
    //           //  Address = entity.Address,
    //          //   Proprietaries = entity.Proprietary,
    //           //  Bids = entity.Bid
    //         };
    //
    //     }
    // }
}