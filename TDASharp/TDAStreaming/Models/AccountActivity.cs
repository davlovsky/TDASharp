using System.Collections.Generic;
using Newtonsoft.Json;

namespace TDASharp
{
    public partial class TDAWebsocket
    {
        public static class AccountActivityCommand
        {
            public const string SUBS = "SUBS";
        }

        public void StreamAccountUpdates(fields Fields)
        {
            string _fields = "";
            if (Fields.ToString() == "All")
            {
                _fields = 0 + "," + 1 + "," + 2 + "," + 3;
            }
            else _fields = Fields.ToString();

            List<Request> Requests = new List<Request>();
            var request = new Request
            {
                service = ServiceName.ACCT_ACTIVITY,
                command = AccountActivityCommand.SUBS,
                requestid = requestID++.ToString(),
                account = userPrincipal.accounts[0].accountId,
                source = userPrincipal.streamerInfo.appId,
                parameters = new Parameters
                {
                    keys = userPrincipal.streamerSubscriptionKeys.keys[0].key,
                    fields = _fields
                }
            };
            Requests.Add(request);
            var req = JsonConvert.SerializeObject(request, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            websocket.Send(req);
        }
    }
}
