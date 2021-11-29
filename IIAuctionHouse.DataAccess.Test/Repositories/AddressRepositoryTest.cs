using IIAuctionHouse.Domain.IRepositories;
using EntityFrameworkCore.Testing.Moq;
using IIAuctionHouse.DataAccess;
using IIAuctionHouse.DataAccess.Repositories;
using Xunit;

namespace IIAuctionHouseDataAccess.Repositories
{
    public class AddressRepositoryTest
    {
        // Checking if AddressRepository is Interface of Address Repository
        [Fact]
        public void AddressRepository_IsIAddressRepository()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new AddressRepository(fakeContext);
            Assert.IsAssignableFrom<IAddressRepository>(repository);
        }
    }
}