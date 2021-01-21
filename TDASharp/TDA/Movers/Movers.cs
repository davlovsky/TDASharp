using System.Collections.Generic;
using TDASharp.Properties;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace TDASharp
{
    public interface IMovers
    {
        Movers GetMovers(index Index, direction Direction, change Change);
    }

    public enum index
    {
        DJI, COMPX, SPX
    }

    public enum direction
    {
        up, down
    }

    public enum change
    {
        value, percent
    }

    public partial class TDAClient
    {
        public Movers GetMovers(index Index, direction Direction, change Change)
        {
            Movers movers = new Movers();
            try
            {
                var client = new RestClient(Settings.Default.TDA_URI);
                var request = new RestRequest("/marketdata/" +
                    Index.ToString().Insert(0, "$") +
                    "/movers", Method.GET).
                    AddParameter("apikey", apiKey).
                    AddParameter("direction", Direction.ToString()).
                    AddParameter("change", Change.ToString());
                request.AddHeader("Authorization", "Bearer " + accessToken);
                var queryResult = client.Execute(request);
                movers = JsonConvert.DeserializeObject<Movers>(queryResult.Content);
            }
            catch (Exception ex)
            {
                //
            }
            return movers;
        }
    }

    public class Movers
    {
        public Change change { get; set; }
        public Description description { get; set; }
        public Direction direction { get; set; }
        public Last last { get; set; }
        public Symbol symbol { get; set; }
        public TotalVolume totalVolume { get; set; }
        public class Change
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class Description
        {
            public string type { get; set; }
        }

        public class Direction
        {
            public string type { get; set; }
            public List<string> @enum { get; set; }
        }

        public class Last
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class Symbol
        {
            public string type { get; set; }
        }

        public class TotalVolume
        {
            public string type { get; set; }
            public string format { get; set; }
        }
    }
}
