using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Web;
using System;

namespace TDASharp
{
    public partial class TDAWebsocket
    {
        public void ChangeQOSLevel(qoslevel level)
        {
            List<Request> Requests = new List<Request>();
            var request = new Request
            {
                service = ServiceName.ADMIN,
                command = Command.QOS,
                requestid = requestID++.ToString(),
                account = userPrincipal.accounts[0].accountId,
                source = userPrincipal.streamerInfo.appId,
                parameters = new Parameters { qoslevel = level }
            };
            Requests.Add(request);
            var req = JsonConvert.SerializeObject(request, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            websocket.Send(req);
        }

        public void StopStreaming()
        {
            List<Request> Requests = new List<Request>();
            var request = new Request
            {
                service = ServiceName.ADMIN,
                command = Command.LOGOUT,
                requestid = requestID++.ToString(),
                account = userPrincipal.accounts[0].accountId,
                source = userPrincipal.streamerInfo.appId,
                parameters = new Parameters
                { }
            };
            Requests.Add(request);
            var req = JsonConvert.SerializeObject(request, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            websocket.Send(req);
        }

        public void StartStreaming()
        {
            List<Request> Requests = new List<Request>();
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime tokenDate = Convert.ToDateTime(userPrincipal.streamerInfo.tokenTimestamp);
            TimeSpan tokenEpoch = tokenDate.ToUniversalTime() - epoch;
            long tokenTimeStampAsMs = (long)Math.Floor(tokenEpoch.TotalMilliseconds);

            var credentials = new Credentials
            {
                userid = userPrincipal.accounts[0].accountId,
                token = userPrincipal.streamerInfo.token,
                company = userPrincipal.accounts[0].company,
                segment = userPrincipal.accounts[0].segment,
                cddomain = userPrincipal.accounts[0].accountCdDomainId,
                usergroup = userPrincipal.streamerInfo.userGroup,
                accesslevel = userPrincipal.streamerInfo.accessLevel,
                authorized = "Y",
                timestamp = tokenTimeStampAsMs.ToString(),
                appid = userPrincipal.streamerInfo.appId,
                acl = userPrincipal.streamerInfo.acl
            };
            var credentialArr = credentials.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).Select(p => new KeyValuePair<string, string>(p.Name, p.GetValue(credentials, null).ToString()));

            var request = new Request
            {
                service = ServiceName.ADMIN,
                command = Command.LOGIN,
                requestid = requestID++.ToString(),
                account = userPrincipal.accounts[0].accountId,
                source = userPrincipal.streamerInfo.appId,
                parameters = new Parameters
                {
                    credential = string.Join("&", credentialArr.Where(c => !string.IsNullOrWhiteSpace(c.Value)).Select(c => string.Format("{0}={1}", HttpUtility.UrlEncode(c.Key, Encoding.UTF8), HttpUtility.UrlEncode(c.Value, Encoding.UTF8)))),
                    token = userPrincipal.streamerInfo.token,
                    version = "1.0"
                }
            };
            Requests.Add(request);
            var req = JsonConvert.SerializeObject(request, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            websocket.Send(req);
        }

        public class AdminResponseRoot
        {
            public List<AdminResponse> response { get; set; }
        }

        public class AdminResponseContent
        {
            public int code { get; set; }
            public string msg { get; set; }
        }

        public class AdminResponse
        {
            public string service { get; set; }
            public string requestid { get; set; }
            public string command { get; set; }
            public long timestamp { get; set; }
            public AdminResponseContent content { get; set; }
        }

        public enum qoslevel
        {
            Zero, One, Two, Three, Four, Five
        }

        public class Credentials
        {
            public string userid { get; set; }
            public string token { get; set; }
            public string company { get; set; }
            public string segment { get; set; }
            public string cddomain { get; set; }
            public string usergroup { get; set; }
            public string accesslevel { get; set; }
            public string authorized { get; set; }
            public string timestamp { get; set; }
            public string appid { get; set; }
            public string acl { get; set; }
        }
    }
}
