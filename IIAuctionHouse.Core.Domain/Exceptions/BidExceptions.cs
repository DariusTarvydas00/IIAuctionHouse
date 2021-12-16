using System.Collections.Generic;

namespace IIAuctionHouse.Core.Domain.Exceptions
{
    public class BidExceptions
    {
        public const string BidDateTimeIsIncorrect = "Bid Date Time is invalid";
        public const string BidAmountIsIncorrect = "Bid Amount is invalid";
        public const string BidIdIncorrect = "Bid Id is invalid";
        public const string BidRepoCannotBeNull = "Bid Repository failure";
        public const string BidIsIncorrect = "Bid cannot failure";
    }
}