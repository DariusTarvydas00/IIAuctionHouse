using System.IO;
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
        
        // Checking if Product Repository contains empty DbContext if not throws InvalidDataException
        [Fact]
        public void AddressRepository_WithNullDbContext_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new AddressRepository(null));
        }
        
        // Checking if Product Repository contains empty DbContext if not throws InvalidDataException Message
        [Fact]
        public void AddressRepository_WithNullDbContext_ThrowsInvalidDataExceptionMessage()
        {
            var expected = "Non existing DbContext";
            var actual = Assert.Throws<InvalidDataException>(() => new AddressRepository(null));
            Assert.Equal(expected,actual.Message);
        }
    }
}