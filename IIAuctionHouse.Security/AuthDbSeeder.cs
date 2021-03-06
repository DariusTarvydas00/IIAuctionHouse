using System.Text;
using IIAuctionHouse.Security.Entities;
using IIAuctionHouse.Security.IServices;

namespace IIAuctionHouse.Security
{
    public class AuthDbSeeder: IAuthDbSeeder
    {
        
        private readonly AuthDbContext _ctx;
        private readonly ISecurityService _securityService;
        
        public AuthDbSeeder(AuthDbContext ctx,ISecurityService securityService)
        {
            _ctx = ctx;
            _securityService = securityService;
        }
        public void SeedDevelopment()
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();
            
            var salt = "123#!";
            _ctx.AuthUsers.Add(new AuthUserEntity
            {
                Salt = salt,
                HashedPassword = _securityService.HashedPassword("123",Encoding.ASCII.GetBytes(salt)),
                Email = "faust@gmail.com"
            });
        }

        public void SeedProduction()
        {
            throw new System.NotImplementedException();
        }
    }
}