using System.Collections.Generic;

namespace TDASharp.TDA.OptionChains
{
    public class OptionsChain
    {
        public Symbol symbol { get; set; }
        public Status status { get; set; }
        public Underlying underlying { get; set; }
        public Strategy strategy { get; set; }
        public Interval interval { get; set; }
        public IsDelayed isDelayed { get; set; }
        public IsIndex isIndex { get; set; }
        public DaysToExpiration daysToExpiration { get; set; }
        public InterestRate interestRate { get; set; }
        public UnderlyingPrice underlyingPrice { get; set; }
        public Volatility volatility { get; set; }
        public CallExpDateMap callExpDateMap { get; set; }
        public PutExpDateMap putExpDateMap { get; set; }

        public class Symbol
        {
            public string type { get; set; }
        }

        public class Status
        {
            public string type { get; set; }
        }

        public class Ask
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class AskSize
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class Bid
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class BidSize
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class Change
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class Close
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class Delayed
        {
            public string type { get; set; }
        }

        public class Description
        {
            public string type { get; set; }
        }

        public class ExchangeName
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class FiftyTwoWeekHigh
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class FiftyTwoWeekLow
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class HighPrice
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class Last
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class LowPrice
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class Mark
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class MarkChange
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class MarkPercentChange
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class OpenPrice
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class PercentChange
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class QuoteTime
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class TotalVolume
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class TradeTime
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class Properties
        {
            public Ask ask { get; set; }
            public AskSize askSize { get; set; }
            public Bid bid { get; set; }
            public BidSize bidSize { get; set; }
            public Change change { get; set; }
            public Close close { get; set; }
            public Delayed delayed { get; set; }
            public Description description { get; set; }
            public ExchangeName exchangeName { get; set; }
            public FiftyTwoWeekHigh fiftyTwoWeekHigh { get; set; }
            public FiftyTwoWeekLow fiftyTwoWeekLow { get; set; }
            public HighPrice highPrice { get; set; }
            public Last last { get; set; }
            public LowPrice lowPrice { get; set; }
            public Mark mark { get; set; }
            public MarkChange markChange { get; set; }
            public MarkPercentChange markPercentChange { get; set; }
            public OpenPrice openPrice { get; set; }
            public PercentChange percentChange { get; set; }
            public QuoteTime quoteTime { get; set; }
            public Symbol symbol { get; set; }
            public TotalVolume totalVolume { get; set; }
            public TradeTime tradeTime { get; set; }
        }

        public class Underlying
        {
            public string type { get; set; }
            public Properties properties { get; set; }
        }

        public class Strategy
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class Interval
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class IsDelayed
        {
            public string type { get; set; }
        }

        public class IsIndex
        {
            public string type { get; set; }
        }

        public class DaysToExpiration
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class InterestRate
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class UnderlyingPrice
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class Volatility
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class AdditionalProperties
        {
            public string type { get; set; }
        }

        public class CallExpDateMap
        {
            public string type { get; set; }
            public AdditionalProperties additionalProperties { get; set; }
        }

        public class PutExpDateMap
        {
            public string type { get; set; }
            public AdditionalProperties additionalProperties { get; set; }
        }
    }
}
