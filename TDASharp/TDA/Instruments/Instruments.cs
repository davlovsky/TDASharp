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

    public class Instrument
    {
        public string cusip { get; set; }
        public string symbol { get; set; }
        public string description { get; set; }
        public string exchange { get; set; }
        public string assetType { get; set; }
    }
}
