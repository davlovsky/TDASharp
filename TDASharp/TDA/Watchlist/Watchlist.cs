using System.Collections.Generic;

namespace TDASharp.TDA.Watchlist
{
    class Watchlist
    {
        public Name name { get; set; }
        public WatchlistId watchlistId { get; set; }
        public AccountId accountId { get; set; }
        public Status status { get; set; }
        public WatchlistItems watchlistItems { get; set; }

        public class Name
        {
            public string type { get; set; }
        }

        public class WatchlistId
        {
            public string type { get; set; }
        }

        public class AccountId
        {
            public string type { get; set; }
        }

        public class Status
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class SequenceId
        {
            public string type { get; set; }
            public string format { get; set; }
            public int minimum { get; set; }
        }

        public class Quantity
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class AveragePrice
        {
            public string type { get; set; }
            public string format { get; set; }
            public int minimum { get; set; }
        }

        public class Commission
        {
            public string type { get; set; }
            public string format { get; set; }
            public int minimum { get; set; }
        }

        public class PurchasedDate
        {
            public string type { get; set; }
        }

        public class Symbol
        {
            public string type { get; set; }
        }

        public class Description
        {
            public string type { get; set; }
        }

        public class AssetType
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class Properties2
        {
            public Symbol symbol { get; set; }
            public Description description { get; set; }
            public AssetType assetType { get; set; }
            public SequenceId sequenceId { get; set; }
            public Quantity quantity { get; set; }
            public AveragePrice averagePrice { get; set; }
            public Commission commission { get; set; }
            public PurchasedDate purchasedDate { get; set; }
            public Instrument instrument { get; set; }
            public Status status { get; set; }
        }

        public class Instrument
        {
            public string type { get; set; }
            public Properties2 properties { get; set; }
        }

        public class Items
        {
            public string type { get; set; }
            public Properties2 properties { get; set; }
        }

        public class WatchlistItems
        {
            public string type { get; set; }
            public Items items { get; set; }
            public bool required { get; set; }
        }
    }
}
