using System.Collections.Generic;

namespace TDASharp
{
    public partial class TDAWebsocket
    {
        public static class ServiceName
        {
            public const string ACCT_ACTIVITY = "ACCT_ACTIVITY";
            public const string ADMIN = "ADMIN";
            public const string ACTIVES_NASDAQ = "ACTIVES_NASDAQ";
            public const string ACTIVES_NYSE = "ACTIVES_NYSE";
            public const string ACTIVES_OTCBB = "ACTIVES_OTCBB";
            public const string NEWS_HEADLINE = "NEWS_HEADLINE";
        }

        public static class Command
        {
            public const string LOGIN = "LOGIN";
            public const string LOGOUT = "LOGOUT";
            public const string QOS = "QOS";
            public const string SUBS = "SUBS";
        }

        public class RequestRoot
        {
            public List<Request> requests { get; set; }
        }

        public class Parameters
        {
            public string token { get; set; }
            public string version { get; set; }
            public string credential { get; set; }
            public qoslevel qoslevel { get; set; }

            public string keys { get; set; }
            public string fields { get; set; }
        }

        public enum fields
        {
            Zero, One, Two, Three, All
        }

        public class Request
        {
            public string service { get; set; }
            public string requestid { get; set; }
            public string command { get; set; }
            public string account { get; set; }
            public string source { get; set; }
            public Parameters parameters { get; set; }
        }
    }
}
