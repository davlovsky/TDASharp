using System.Collections.Generic;
using Newtonsoft.Json;

namespace TDASharp
{
    public partial class TDAWebsocket
    {
        public class DataContent
        {
            [JsonProperty("1")]
            public int _1 { get; set; }

            [JsonProperty("2")]
            public long _2 { get; set; }

            [JsonProperty("3")]
            public string _3 { get; set; }

            [JsonProperty("4")]
            public string _4 { get; set; }

            [JsonProperty("5")]
            public string _5 { get; set; }

            [JsonProperty("6")]
            public string _6 { get; set; }

            [JsonProperty("7")]
            public int _7 { get; set; }

            [JsonProperty("8")]
            public string _8 { get; set; }

            [JsonProperty("9")]
            public bool _9 { get; set; }

            [JsonProperty("10")]
            public string _10 { get; set; }

            [JsonProperty("seq")]
            public int Seq { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }
        }

        public class Datum
        {
            [JsonProperty("service")]
            public string Service { get; set; }

            [JsonProperty("timestamp")]
            public long Timestamp { get; set; }

            [JsonProperty("command")]
            public string Command { get; set; }

            [JsonProperty("content")]
            public List<DataContent> Content { get; set; }
        }

        public class DataContentRoot
        {
            [JsonProperty("data")]
            public List<Datum> Data { get; set; }
        }


    }
}
