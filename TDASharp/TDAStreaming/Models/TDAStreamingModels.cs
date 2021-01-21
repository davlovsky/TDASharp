using System.Collections.Generic;

namespace TDASharp
{
    public partial class TDAWebsocket
    {

        public enum ResponseCode
        {
            ACCT_ACTIVITY, ADMIN, ACTIVES_NASDAQ,
            ACTIVES_NYSE, ACTIVES_OTCBB, ACTIVES_OPTIONS
        }

        public class HeartBeat
        {
            public string heartbeat { get; set; }
        }

        public class Notify
        {
            public List<HeartBeat> notify { get; set; }
        }

        public class Content
        {
            public int code { get; set; }
            public string msg { get; set; }
        }

        public class Response
        {
            public string service { get; set; }
            public string requestid { get; set; }
            public string command { get; set; }
            public long timestamp { get; set; }
            public Content content { get; set; }
        }
    }
}
