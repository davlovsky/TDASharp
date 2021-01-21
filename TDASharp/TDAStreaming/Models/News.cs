using System.Collections.Generic;
using Newtonsoft.Json;

namespace TDASharp
{
    public partial class TDAWebsocket
    {
        public void GetNewsHeadlines(string symbol)
        {
            RequestRoot requestRoot = new RequestRoot();
            List<Request> Requests = new List<Request>();
            requestRoot.requests = Requests;

            Request request;
            request = new Request
            {
                service = ServiceName.NEWS_HEADLINE,
                command = Command.SUBS,
                requestid = requestID++.ToString(),
                account = userPrincipal.accounts[0].accountId,
                source = userPrincipal.streamerInfo.appId,
                parameters = new Parameters
                {
                    keys = symbol,
                    fields = "0,1,2,3,4,5,6,7,8,9,10"
                }
            };
            Requests.Add(request);
            var req = JsonConvert.SerializeObject(requestRoot);
            websocket.Send(req);
        }

        public class NewsContent
        {
            [JsonProperty("seq")]
            public int Seq { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }

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
        }

        public class NewsData
        {
            public string service { get; set; }
            public long timestamp { get; set; }
            public string command { get; set; }
            public List<NewsContent> content { get; set; }
        }

        public class NewsResponse
        {
            public List<NewsData> data { get; set; }
        }
    }
}
