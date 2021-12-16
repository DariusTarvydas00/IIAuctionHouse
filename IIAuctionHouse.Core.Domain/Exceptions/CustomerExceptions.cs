namespace IIAuctionHouse.Core.Domain.Exceptions
{
    public class CustomerExceptions
    {
        public const string CustomerRepoCannotBeNull = "Customer repository failure";
        public const string CustomerFirstNameIncorrect = "First Name value is invalid";
        public const string CustomerLastNameIncorrect = "Last Name value is invalid";
        public const string CustomerDetailsIncorrect = "Account Details values is invalid";
        public const string CustomerTypeIncorrect = "Customer Type value is invalid";
        public const string CustomerIsIncorrect = "Customer failure";
        public const string CustomerIdIncorrect = "Customer Id is invalid";
    }
}