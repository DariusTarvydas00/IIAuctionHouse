
namespace IIAuctionHouse.Domain.Test.Services
{
    public class UserServiceTest
    {
        // private readonly UserService _service;
        // private readonly Mock<IUserRepository> _mock;
        // private readonly List<User> _expected;
        //
        // public UserServiceTest()
        // {
        //     _mock = new Mock<IUserRepository>();
        //     _service = new UserService(_mock.Object);
        //     _expected = new List<User>()
        //     {
        //         new User()
        //         {
        //             Id = 1,
        //             FirstName = "User",
        //             LastName = "User",
        //             Address = new Address(),
        //             Proprietaries = new List<Proprietary>(),
        //             Bids = new List<Bid>()
        //         },
        //         new User()
        //         {
        //             Id = 2,
        //             FirstName = "User2",
        //             LastName = "User2",
        //             Address = new Address(),
        //             Proprietaries = new List<Proprietary>(),
        //             Bids = new List<Bid>()
        //         }
        //     };
        // }
        //
        // // Checking if Service is Using Interface
        // [Fact]
        // public void UserService_IsIUserService()
        // {
        //     Assert.True(_service is IUserService);
        // }
        //
        // // Checking throw exception if IUserService is null
        // [Fact]
        // public void UserService_WithNullRepositoryException_ThrowsInvalidDataException()
        // {
        //     Assert.Throws<InvalidDataException>(() => new UserService(null));
        // }
        //
        // [Fact]
        // public void UserService_WithNullRepositoryException_ThrowsInvalidDataExceptionMessage()
        // {
        //     var expected = "User Service can not be null";
        //     var actual = Assert.Throws<InvalidDataException>(() => new UserService(null));
        //     Assert.Equal(expected,actual.Message);
        // }
        //
        // // Checks if ReadAll method calls UserRepository only one time
        // [Fact]
        // public void ReadAll_CallsUserRepositoryReadAll_ExactlyOnce()
        // {
        //     _service.ReadAll();
        //     _mock.Verify(r=>r.ReadAll(), Times.Once);
        // }
        //
        // // Checks if ReadAll method returns list of Users
        // [Fact]
        // public void ReadAll_NoFilter_ReturnsListOfUsers()
        // {
        //     _mock.Setup(r => r.ReadAll()).Returns(_expected);
        //     var actual = _service.ReadAll();
        //     Assert.Equal(_expected,actual);
        // }
        //
        // // Checks if GetById throws exception if id is less than 1
        // [Fact]
        // public void GetById_withZeroOrLess_ThrowsException()
        // {
        //     Assert.Throws<InvalidDataException>(() => _service.GetById(0));
        //     Assert.Throws<InvalidDataException>(() => _service.GetById(-5));
        // }
        //
        // // Checks if GetById  throws exception message if id is less than 1
        // [Fact]
        // public void GetById_withZeroOrLess_ThrowsExceptionMessage()
        // {
        //     var expected = "User Id must be higher than 0";
        //     var actual = Assert.Throws<InvalidDataException>(() => _service.GetById(0));
        //     Assert.Equal(expected,actual.Message);
        //     var actual2 = Assert.Throws<InvalidDataException>(() => _service.GetById(-5));
        //     Assert.Equal(expected,actual2.Message);
        // }
        //
        // // Checks if GetById with null throws exception
        // [Theory]
        // [InlineData(null)]
        // public void GetById_Null_ThrowsException(int value)
        // {
        //     Assert.Throws<InvalidDataException>(() => _service.GetById(value));
        // }
        //
        // // Checks if GetById with null throws exception message
        // [Theory]
        // [InlineData(null)]
        // public void GetById_Null_ThrowsExceptionMessage(int value)
        // {
        //     var expected = "User Id must be higher than 0";
        //     var actual = Assert.Throws<InvalidDataException>(() => _service.GetById(value));
        //     Assert.Equal(expected,actual.Message);
        // }
        //
        // // Checks if Creating User Object is possible
        // [Theory]
        // [ClassData(typeof(TestCreateDataClass))]
        // public void Create_WithNull_ThrowsExceptionWithMessage(string firstName, string lastName, Address address, List<Proprietary> proprietary, List<Bid> bid)
        // {
        //     var expected = "One of the values is empty or entered incorrectly";
        //     var actual = Assert.Throws<InvalidDataException>(() =>
        //         _service.Create(firstName,lastName,address,proprietary,bid));
        //     Assert.Equal(expected,actual.Message);
        // }
        //
        // private class TestCreateDataClass : IEnumerable<object[]>
        // {
        //     private readonly List<object[]> _data = new List<object[]>
        //     {
        //         new object[] {null, "LastName", new Address() {Id = 1}, new List<Proprietary>(){new Proprietary(){Id = 1}}, new List<Bid>{(new Bid(){Id = 1})}},
        //         new object[] {"FirstName", null, new Address() {Id = 1}, new List<Proprietary>(){new Proprietary(){Id = 1}},new List<Bid>{(new Bid(){Id = 1})}},
        //         new object[] {"FirstName", "LastName", null, new List<Proprietary>(){new Proprietary(){Id = 1}}, new List<Bid>{(new Bid(){Id = 1})}},
        //         new object[] {"FirstName", "LastName", new Address() {Id = 1}, null, new List<Bid>{(new Bid(){Id = 1})}},
        //         new object[] {"FirstName", "LastName", new Address() {Id = 1}, new List<Proprietary>(){new Proprietary(){Id = 1}}, null}
        //     };
        //
        //     public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();
        //
        //
        //     IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        // }
        //
        // // Checks if Updating Object is possible
        // [Fact]
        // public void Update_WithNull_ThrowsExceptionWithMessage()
        // {
        //     var fakeList = new List<User>();
        //     fakeList.Add(new User() {Id = 0, FirstName = "User", LastName = "User", Address = new Address(), Proprietaries = new List<Proprietary>(), Bids = new List<Bid>()});
        //     var update1 = new User() {Id = 0, FirstName = "User", Address  = new Address(), Proprietaries = new List<Proprietary>(), Bids = new List<Bid>()};
        //     var update2 = new User() {Id = 0, LastName = "User", Address  = new Address(), Proprietaries = new List<Proprietary>(), Bids = new List<Bid>()};
        //     var update3 = new User() {Id = 0, FirstName = "User", LastName = "User", Proprietaries = new List<Proprietary>(), Bids = new List<Bid>()};
        //     var update4 = new User() {Id = 0, FirstName = "User", LastName = "User", Address  = new Address(), Bids = new List<Bid>() };
        //     var update5 = new User() {Id = 0, FirstName = "User", LastName = "User", Address  = new Address(), Proprietaries = new List<Proprietary>() };
        //     var expected = "One of the values is empty or entered incorrectly";
        //     var actual1 = Assert.Throws<InvalidDataException>(() => _service.Update(update1));
        //     var actual2 = Assert.Throws<InvalidDataException>(() => _service.Update(update2));
        //     var actual3 = Assert.Throws<InvalidDataException>(() => _service.Update(update3));
        //     var actual4 = Assert.Throws<InvalidDataException>(() => _service.Update(update4));
        //     var actual5 = Assert.Throws<InvalidDataException>(() => _service.Update(update5));
        //     Assert.Equal(expected,actual1.Message);
        //     Assert.Equal(expected,actual2.Message);
        //     Assert.Equal(expected,actual3.Message);
        //     Assert.Equal(expected,actual4.Message);
        //     Assert.Equal(expected,actual5.Message);
        // }
        //
        // // Check if Delete Method throws exception
        // [Theory]
        // [InlineData(null)]
        // public void Delete_Null_ThrowsException(int value)
        // {
        //     Assert.Throws<InvalidDataException>(() => _service.Delete(value));
        // }
        //
        // // Checks if Delete with null throws exception message
        // [Theory]
        // [InlineData(null)]
        // public void Delete_Null_ThrowsExceptionMessage(int value)
        // {
        //     var expected = "User Id must be higher than 0";
        //     var actual = Assert.Throws<InvalidDataException>(() => _service.Delete(value));
        //     Assert.Equal(expected,actual.Message);
        // }
        //
    }
}