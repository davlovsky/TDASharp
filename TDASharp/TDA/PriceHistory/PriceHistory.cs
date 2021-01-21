using TDASharp.Properties;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace TDASharp
{
    public interface IPriceHistory
    {
        PriceHistory GetPriceHistory(string Symbol, frequencyType FrequencyType, int frequency, periodType PeriodType, int period, bool needExtendedHoursData = true);
        PriceHistory GetPriceHistory(string Symbol, int frequency, DateTime endDate, DateTime startDate, bool needExtendedHoursData = true);
    }

    public enum periodType
    {
        day, month, year, ytd
    }

    public enum frequencyType
    {
        minute, daily, weekly, monthly
    }

    public partial class TDAClient
    {
        public PriceHistory GetPriceHistory(string Symbol, frequencyType FrequencyType, int frequency, periodType PeriodType, int period, bool needExtendedHoursData = true)
        {
            PriceHistory priceHistory = new PriceHistory();
            var periodType = PeriodType.ToString();
            var frequencyType = FrequencyType.ToString();
            try
            {
                var client = new RestClient(Settings.Default.TDA_URI);
                var request = new RestRequest("/marketdata/" + Symbol + "/pricehistory", Method.GET).
                    AddParameter("apikey", apiKey).
                    AddParameter("periodType", periodType).
                    AddParameter("period", period.ToString()).
                    AddParameter("frequencyType", frequencyType).
                    AddParameter("frequency", frequency.ToString()).
                    AddParameter("needExtendedHoursData", needExtendedHoursData.ToString());
                request.AddHeader("Authorization", "Bearer " + accessToken);
                var queryResult = client.Execute(request);
                priceHistory = JsonConvert.DeserializeObject<PriceHistory>(queryResult.Content);
            }
            catch (Exception ex)
            {
                //
            }
            return priceHistory;
        }

        public PriceHistory GetPriceHistory(string Symbol, int frequency, DateTime endDate, DateTime startDate, bool needExtendedHoursData = true)
        {
            PriceHistory priceHistory = new PriceHistory();
            try
            {
                var client = new RestClient(Settings.Default.TDA_URI);
                var request = new RestRequest("/marketdata/" + Symbol + "/pricehistory", Method.GET).
                    AddParameter("apikey", apiKey).
                    AddParameter("frequency", frequency).
                    AddParameter("startDate", Conversions.MillisecondsSinceEpoch(endDate)).
                    AddParameter("endDate", Conversions.MillisecondsSinceEpoch(startDate)).
                    AddParameter("needExtendedHoursData", needExtendedHoursData.ToString());
                request.AddHeader("Authorization", "Bearer " + accessToken);
                var queryResult = client.Execute(request);
                priceHistory = JsonConvert.DeserializeObject<PriceHistory>(queryResult.Content);
            }
            catch (Exception ex)
            {
                //
            }
            return priceHistory;
        }
    }

    public class PriceHistory
    {
        public List<Candle> candles { get; set; }
        public string symbol { get; set; }
        public bool empty { get; set; }

        public class Candle
        {
            public double open { get; set; }
            public double high { get; set; }
            public double low { get; set; }
            public double close { get; set; }
            public int volume { get; set; }
            public object datetime { get; set; }
        }
    }
}
