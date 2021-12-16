namespace IIAuctionHouse.Core.Domain.Exceptions
{
    public class CustomerDetailsExceptions
    {
        public const string CustomerDetailsRepoCannotBeNull = "Customer Details repository failure";
        public const string CustomerDetailsCountryIncorrect = "Country value is invalid";
        public const string CustomerDetailsCityIncorrect = "City value is invalid";
        public const string CustomerDetailsPostCodeIncorrect = "Post Code value is invalid";
        public const string CustomerDetailsStreetNameIncorrect = "Street Name value is invalid";
        public const string CustomerDetailsStreetNumberIncorrect = "Street Number value is invalid";
        public const string CustomerDetailsPhoneNumberIncorrect = "Phone Number value is invalid";
        public const string CustomerDetailsEmailIncorrect = "Email value is invalid";
        public const string CustomerDetailsAccountCreationDateIncorrect = "Account Creation Date Time value is invalid";
        public const string CustomerDetailsIdIncorrect = "Customer Details Id value is invalid";
        public const string CustomerDetailsIncorrect = "Customer Details failure";
    }
}