using System.Collections.Generic;
using TDASharp.Properties;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace TDASharp
{
    public interface IInstruments
    {
        Instrument SearchInstruments(string Symbol, projection Projection);
        List<Instrument> GetInstrument(string CUSIP);
    }

    public enum projection
    {
        symbol_search, symbol_regex, desc_search, desc_regex, fundamental
    }

    public partial class TDAClient
    {
        public Instrument SearchInstruments(string Symbol, projection Projection)
        {
            Instrument instruments = new Instrument();
            try
            {
                var client = new RestClient(Settings.Default.TDA_URI);
                var request = new RestRequest("/instruments", Method.GET).
                    AddParameter("apikey", apiKey).
                    AddParameter("symbol", Symbol).
                    AddParameter("projection", Projection.ToString().Replace('_', '-'));
                request.AddHeader("Authorization", "Bearer " + accessToken);
                var queryResult = client.Execute(request);

                dynamic jObj = JsonConvert.DeserializeObject(queryResult.Content);
                var jObj2 = jObj[Symbol].ToString();
                instruments = JsonConvert.DeserializeObject<Instrument>(jObj2);
            }
            catch (Exception ex)
            {
                //
            }
            return instruments;
        }

        public List<Instrument> GetInstrument(string CUSIP)
        {
            List<Instrument> instruments = new List<Instrument>();
            try
            {
                var client = new RestClient(Settings.Default.TDA_URI);
                var request = new RestRequest("/instruments/" + CUSIP, Method.GET).
                    AddParameter("apikey", apiKey);
                request.AddHeader("Authorization", "Bearer " + accessToken);
                var queryResult = client.Execute(request);
                instruments = JsonConvert.DeserializeObject<List<Instrument>>(queryResult.Content);
            }
            catch (Exception ex)
            {
                //
            }
            return instruments;
        }
    }

    /*public class Instrument
    {
        public string cusip { get; set; }
        public string symbol { get; set; }
        public string description { get; set; }
        public string exchange { get; set; }
        public string assetType { get; set; }
    }*/

    public class Fundamental
    {
        public string symbol { get; set; }
        public double high52 { get; set; }
        public double low52 { get; set; }
        public double dividendAmount { get; set; }
        public double dividendYield { get; set; }
        public string dividendDate { get; set; }
        public double peRatio { get; set; }
        public double pegRatio { get; set; }
        public double pbRatio { get; set; }
        public double prRatio { get; set; }
        public double pcfRatio { get; set; }
        public double grossMarginTTM { get; set; }
        public double grossMarginMRQ { get; set; }
        public double netProfitMarginTTM { get; set; }
        public double netProfitMarginMRQ { get; set; }
        public double operatingMarginTTM { get; set; }
        public double operatingMarginMRQ { get; set; }
        public double returnOnEquity { get; set; }
        public double returnOnAssets { get; set; }
        public double returnOnInvestment { get; set; }
        public double quickRatio { get; set; }
        public double currentRatio { get; set; }
        public double interestCoverage { get; set; }
        public double totalDebtToCapital { get; set; }
        public double ltDebtToEquity { get; set; }
        public double totalDebtToEquity { get; set; }
        public double epsTTM { get; set; }
        public double epsChangePercentTTM { get; set; }
        public double epsChangeYear { get; set; }
        public double epsChange { get; set; }
        public double revChangeYear { get; set; }
        public double revChangeTTM { get; set; }
        public double revChangeIn { get; set; }
        public double sharesOutstanding { get; set; }
        public double marketCapFloat { get; set; }
        public double marketCap { get; set; }
        public double bookValuePerShare { get; set; }
        public double shortIntToFloat { get; set; }
        public double shortIntDayToCover { get; set; }
        public double divGrowthRate3Year { get; set; }
        public double dividendPayAmount { get; set; }
        public string dividendPayDate { get; set; }
        public double beta { get; set; }
        public double vol1DayAvg { get; set; }
        public double vol10DayAvg { get; set; }
        public double vol3MonthAvg { get; set; }
    }

    public class Instrument
    {
        public Fundamental fundamental { get; set; }
        public string cusip { get; set; }
        public string symbol { get; set; }
        public string description { get; set; }
        public string exchange { get; set; }
        public string assetType { get; set; }
    }
}
