using System.Collections.Generic;
using TDASharp.Properties;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace TDASharp
{
    public interface IUserInfoAndPreferences
    {
        Preferences GetPreferences(string AccountID);
        List<Keys> GetStreamerSubscriptionKeys(List<string> AccountIds);
        UserPrincipal GetUserPrincipals(preferencefields Fields);
        bool UpdatePreferences(UpdatePreferences updatePreferences);
    }

    public enum preferencefields
    {
        streamerSubscriptionKeys, streamerConnectionInfo, preferences, surrogateIds, all, streamer
    }

    public partial class TDAClient
    {
        public Preferences GetPreferences(string AccountID)
        {
            Preferences preferences = new Preferences();
            try
            {
                var client = new RestClient(Settings.Default.TDA_URI);
                var request = new RestRequest("/accounts/" + AccountID + "/preferences", Method.GET);
                request.AddHeader("Authorization", "Bearer " + accessToken);
                var queryResult = client.Execute(request);
                preferences = JsonConvert.DeserializeObject<Preferences>(queryResult.Content);
            }
            catch (Exception ex)
            {
                //
            }
            return preferences;
        }

        public List<Keys> GetStreamerSubscriptionKeys(List<string> AccountIds)
        {
            List<Keys> keys = new List<Keys>();
            try
            {
                var client = new RestClient(Settings.Default.TDA_URI);
                var request = new RestRequest("/userprincipals/streamersubscriptionkeys", Method.GET).
                    AddParameter("accountIds", string.Join(",", AccountIds));
                request.AddHeader("Authorization", "Bearer " + accessToken);
                var queryResult = client.Execute(request);
                keys = JsonConvert.DeserializeObject<List<Keys>>(queryResult.Content);
            }
            catch (Exception ex)
            {
                //
            }
            return keys;
        }

        public UserPrincipal GetUserPrincipals(preferencefields Fields)
        {
            string _fields = "";
            if (Fields.ToString() == "all")
            {
                _fields = preferencefields.preferences.ToString() + "," +
                    preferencefields.streamerConnectionInfo.ToString() + "," +
                    preferencefields.streamerSubscriptionKeys.ToString() + "," +
                    preferencefields.surrogateIds.ToString();
            }
            else if (Fields.ToString() == "streamer")
            {
                _fields = preferencefields.streamerSubscriptionKeys.ToString() + "," +
                    preferencefields.streamerConnectionInfo.ToString();
            }
            else _fields = Fields.ToString();

            UserPrincipal userPrincipal = new UserPrincipal();
            try
            {
                var client = new RestClient(Settings.Default.TDA_URI);
                var request = new RestRequest("/userprincipals", Method.GET).
                    AddParameter("fields", _fields);
                request.AddHeader("Authorization", "Bearer " + accessToken);
                var queryResult = client.Execute(request);
                userPrincipal = JsonConvert.DeserializeObject<UserPrincipal>(queryResult.Content);
            }
            catch (Exception ex)
            {
                //
            }
            return userPrincipal;
        }

        public bool UpdatePreferences(UpdatePreferences updatePreferences)
        {
            try
            {
                var client = new RestClient(Settings.Default.TDA_URI);
                var request = new RestRequest("/marketdata/quotes", Method.PUT);
                request.AddHeader("Authorization", "Bearer " + accessToken);
                var queryResult = client.Execute(request);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

    public class UpdatePreferences
    {
        public bool expressTrading { get; set; }
        public bool directOptionsRouting { get; set; }
        public bool directEquityRouting { get; set; }
        public string defaultEquityOrderLegInstruction { get; set; }
        public string defaultEquityOrderType { get; set; }
        public string defaultEquityOrderPriceLinkType { get; set; }
        public string defaultEquityOrderDuration { get; set; }
        public string defaultEquityOrderMarketSession { get; set; }
        public int defaultEquityQuantity { get; set; }
        public string mutualFundTaxLotMethod { get; set; }
        public string optionTaxLotMethod { get; set; }
        public string equityTaxLotMethod { get; set; }
        public string defaultAdvancedToolLaunch { get; set; }
        public string authTokenTimeout { get; set; }
    }

    public class UserPrincipal
    {
        public string authToken { get; set; }
        public string userId { get; set; }
        public string userCdDomainId { get; set; }
        public string primaryAccountId { get; set; }
        public string lastLoginTime { get; set; }
        public string tokenExpirationTime { get; set; }
        public string loginTime { get; set; }
        public string accessLevel { get; set; }
        public bool stalePassword { get; set; }
        public StreamerInfo streamerInfo { get; set; }
        public string professionalStatus { get; set; }
        public Quotes quotes { get; set; }
        public StreamerSubscriptionKeys streamerSubscriptionKeys { get; set; }
        public List<Account> accounts { get; set; }

        public class StreamerInfo
        {
            public string streamerBinaryUrl { get; set; }
            public string streamerSocketUrl { get; set; }
            public string token { get; set; }
            public string tokenTimestamp { get; set; }
            public string userGroup { get; set; }
            public string accessLevel { get; set; }
            public string acl { get; set; }
            public string appId { get; set; }
        }

        public class Quotes
        {
            public bool isNyseDelayed { get; set; }
            public bool isNasdaqDelayed { get; set; }
            public bool isOpraDelayed { get; set; }
            public bool isAmexDelayed { get; set; }
            public bool isCmeDelayed { get; set; }
            public bool isIceDelayed { get; set; }
            public bool isForexDelayed { get; set; }
        }

        public class Key
        {
            public string key { get; set; }
        }

        public class StreamerSubscriptionKeys
        {
            public List<Key> keys { get; set; }
        }

        public class Preferences
        {
            public bool expressTrading { get; set; }
            public bool directOptionsRouting { get; set; }
            public bool directEquityRouting { get; set; }
            public string defaultEquityOrderLegInstruction { get; set; }
            public string defaultEquityOrderType { get; set; }
            public string defaultEquityOrderPriceLinkType { get; set; }
            public string defaultEquityOrderDuration { get; set; }
            public string defaultEquityOrderMarketSession { get; set; }
            public int defaultEquityQuantity { get; set; }
            public string mutualFundTaxLotMethod { get; set; }
            public string optionTaxLotMethod { get; set; }
            public string equityTaxLotMethod { get; set; }
            public string defaultAdvancedToolLaunch { get; set; }
            public string authTokenTimeout { get; set; }
        }

        public class Authorizations
        {
            public bool apex { get; set; }
            public bool levelTwoQuotes { get; set; }
            public bool stockTrading { get; set; }
            public bool marginTrading { get; set; }
            public bool streamingNews { get; set; }
            public string optionTradingLevel { get; set; }
            public bool streamerAccess { get; set; }
            public bool advancedMargin { get; set; }
            public bool scottradeAccount { get; set; }
        }

        public class Account
        {
            public string accountId { get; set; }
            public string description { get; set; }
            public string displayName { get; set; }
            public string accountCdDomainId { get; set; }
            public string company { get; set; }
            public string segment { get; set; }
            public string surrogateIds { get; set; }
            public Preferences preferences { get; set; }
            public string acl { get; set; }
            public Authorizations authorizations { get; set; }
        }
    }


    public class Keys
    {
        public string key { get; set; }
    }

    public class Preferences
    {
        public bool expressTrading { get; set; }
        public bool directOptionsRouting { get; set; }
        public bool directEquityRouting { get; set; }
        public string defaultEquityOrderLegInstruction { get; set; }
        public string defaultEquityOrderType { get; set; }
        public string defaultEquityOrderPriceLinkType { get; set; }
        public string defaultEquityOrderDuration { get; set; }
        public string defaultEquityOrderMarketSession { get; set; }
        public int defaultEquityQuantity { get; set; }
        public string mutualFundTaxLotMethod { get; set; }
        public string optionTaxLotMethod { get; set; }
        public string equityTaxLotMethod { get; set; }
        public string defaultAdvancedToolLaunch { get; set; }
        public string authTokenTimeout { get; set; }
    }
}
