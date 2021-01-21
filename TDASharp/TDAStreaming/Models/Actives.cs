using Newtonsoft.Json;
using System.Collections.Generic;

namespace TDASharp
{
    public partial class TDAWebsocket
    {
        public enum Actives
        {
            ACTIVES_NASDAQ, ACTIVES_NYSE, ACTIVES_OPTIONS, ACTIVES_OTCBB
        }

        public enum Venue
        {
            NASDAQ, NYSE, OTCBB, CALLS, OPTS, PUTS, CALLS_DESC, OPTS_DESC, PUTS_DESC
        }

        public enum Duration
        {
            ALL, THREETHOUSANDSIXHUNDRED, EIGHTEENHUNDRED, SIXHUNDRED, THREEHUNDRED, SIXTY
        }

        public void GetDaysTopMostTradedSymbols(Actives actives, Venue venue, Duration duration)
        {
            string _duration = "";
            if (duration.ToString() == "THREETHOUSANDSIXHUNDRED")
                _duration = "3600";
            else if (duration.ToString() == "EIGHTEENHUNDRED")
                _duration = "1800";
            else if (duration.ToString() == "SIXHUNDRED")
                _duration = "600";
            else if (duration.ToString() == "THREEHUNDRED")
                _duration = "300";
            else if (duration.ToString() == "SIXTY")
                _duration = "60";
            else _duration = duration.ToString();

            string _venue = "";
            if (venue.ToString() == "CALLS_DESC")
                _venue = "CALLS-DESC";
            else if (venue.ToString() == "OPTS_DESC")
                _venue = "OPTS-DESC";
            else if (venue.ToString() == "PUTS_DESC")
                _venue = "PUTS-DESC";
            else _venue = venue.ToString();

            List<Request> Requests = new List<Request>();
            var request = new Request
            {
                service = actives.ToString(),
                command = AccountActivityCommand.SUBS,
                requestid = requestID++.ToString(),
                account = userPrincipal.accounts[0].accountId,
                source = userPrincipal.streamerInfo.appId,
                parameters = new Parameters
                {
                    keys = _venue + "-" + _duration,
                    fields = "1"
                }
            };
            Requests.Add(request);
            var req = JsonConvert.SerializeObject(request, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            websocket.Send(req);
        }
    }
}
