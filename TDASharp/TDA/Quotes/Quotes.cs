using System.Collections.Generic;
using TDASharp.Properties;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace TDASharp
{
    public interface IQuotes
    {
        Quote GetQuote(string Symbol);
        Quote GetQuotes(List<string> Symbols);
    }

    public partial class TDAClient
    {
        public Quote GetQuote(string Symbol)
        {
            Quote quote = new Quote();
            try
            {
                var client = new RestClient(Settings.Default.TDA_URI);
                var request = new RestRequest("/marketdata/" + Symbol + "/quotes", Method.GET).
                    AddParameter("apikey", apiKey);
                request.AddHeader("Authorization", "Bearer " + accessToken);
                var queryResult = client.Execute(request);
                dynamic stuff = JsonConvert.DeserializeObject(queryResult.Content);
                quote = JsonConvert.DeserializeObject<Quote>(stuff[Symbol].ToString());
            }
            catch (Exception ex)
            {
                //
            }
            return quote;
        }

        public Quote GetQuotes(List<string> Symbols)
        {
            Quote quote = new Quote();
            try
            {
                var client = new RestClient(Settings.Default.TDA_URI);
                var request = new RestRequest("/marketdata/quotes", Method.GET).
                    AddParameter("apikey", apiKey).
                    AddParameter("symbol", String.Join(",", Symbols));
                request.AddHeader("Authorization", "Bearer " + accessToken);
                var queryResult = client.Execute(request);
                quote = JsonConvert.DeserializeObject<Quote>(queryResult.Content);
            }
            catch (Exception ex)
            {
                //
            }
            return quote;
        }
    }

    public class Quote
    {
        [JsonProperty("assetType")]
        public string AssetType { get; set; }

        [JsonProperty("assetMainType")]
        public string AssetMainType { get; set; }

        [JsonProperty("cusip")]
        public string Cusip { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("bidPrice")]
        public double BidPrice { get; set; }

        [JsonProperty("bidSize")]
        public int BidSize { get; set; }

        [JsonProperty("bidId")]
        public string BidId { get; set; }

        [JsonProperty("askPrice")]
        public double AskPrice { get; set; }

        [JsonProperty("askSize")]
        public int AskSize { get; set; }

        [JsonProperty("askId")]
        public string AskId { get; set; }

        [JsonProperty("lastPrice")]
        public double LastPrice { get; set; }

        [JsonProperty("lastSize")]
        public int LastSize { get; set; }

        [JsonProperty("lastId")]
        public string LastId { get; set; }

        [JsonProperty("openPrice")]
        public double OpenPrice { get; set; }

        [JsonProperty("highPrice")]
        public double HighPrice { get; set; }

        [JsonProperty("lowPrice")]
        public double LowPrice { get; set; }

        [JsonProperty("bidTick")]
        public string BidTick { get; set; }

        [JsonProperty("closePrice")]
        public double ClosePrice { get; set; }

        [JsonProperty("netChange")]
        public double NetChange { get; set; }

        [JsonProperty("totalVolume")]
        public int TotalVolume { get; set; }

        [JsonProperty("quoteTimeInLong")]
        public long QuoteTimeInLong { get; set; }

        [JsonProperty("tradeTimeInLong")]
        public long TradeTimeInLong { get; set; }

        [JsonProperty("mark")]
        public double Mark { get; set; }

        [JsonProperty("exchange")]
        public string Exchange { get; set; }

        [JsonProperty("exchangeName")]
        public string ExchangeName { get; set; }

        [JsonProperty("marginable")]
        public bool Marginable { get; set; }

        [JsonProperty("shortable")]
        public bool Shortable { get; set; }

        [JsonProperty("volatility")]
        public double Volatility { get; set; }

        [JsonProperty("digits")]
        public int Digits { get; set; }

        [JsonProperty("52WkHigh")]
        public double _52WkHigh { get; set; }

        [JsonProperty("52WkLow")]
        public double _52WkLow { get; set; }

        [JsonProperty("nAV")]
        public double NAV { get; set; }

        [JsonProperty("peRatio")]
        public double PeRatio { get; set; }

        [JsonProperty("divAmount")]
        public double DivAmount { get; set; }

        [JsonProperty("divYield")]
        public double DivYield { get; set; }

        [JsonProperty("divDate")]
        public string DivDate { get; set; }

        [JsonProperty("securityStatus")]
        public string SecurityStatus { get; set; }

        [JsonProperty("regularMarketLastPrice")]
        public double RegularMarketLastPrice { get; set; }

        [JsonProperty("regularMarketLastSize")]
        public int RegularMarketLastSize { get; set; }

        [JsonProperty("regularMarketNetChange")]
        public double RegularMarketNetChange { get; set; }

        [JsonProperty("regularMarketTradeTimeInLong")]
        public long RegularMarketTradeTimeInLong { get; set; }

        [JsonProperty("netPercentChangeInDouble")]
        public double NetPercentChangeInDouble { get; set; }

        [JsonProperty("markChangeInDouble")]
        public double MarkChangeInDouble { get; set; }

        [JsonProperty("markPercentChangeInDouble")]
        public double MarkPercentChangeInDouble { get; set; }

        [JsonProperty("regularMarketPercentChangeInDouble")]
        public double RegularMarketPercentChangeInDouble { get; set; }

        [JsonProperty("delayed")]
        public bool Delayed { get; set; }
    }
}
