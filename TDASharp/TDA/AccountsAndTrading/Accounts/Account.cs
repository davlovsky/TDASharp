using System.Collections.Generic;
using TDASharp.Properties;
using Newtonsoft.Json;
using RestSharp;

namespace TDASharp
{
    public interface IAccounts
    {
        Account GetAccount(string AccountID, fields Fields);
        List<Account> GetAccounts(fields Fields);
    }

    public enum fields
    {
        positions, orders, both
    }

    public partial class TDAClient
    {
        public Account GetAccount(string AccountID, fields Fields)
        {
            string _fields = "";
            if (Fields.ToString() == "both")
            {
                _fields = "positions,orders";
            }
            else _fields = Fields.ToString();
            var client = new RestClient(Settings.Default.TDA_URI);
            var request = new RestRequest("/accounts/" + AccountID, Method.GET).
                AddParameter("fields", _fields);
            request.AddHeader("Authorization", "Bearer " + accessToken);

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            Account tokens = JsonConvert.DeserializeObject<Account>(content);
            return tokens;
        }

        public List<Account> GetAccounts(fields Fields)
        {
            string _fields = "";
            if (Fields.ToString() == "both")
            {
                _fields = "positions,orders";
            }
            else _fields = Fields.ToString();

            var client = new RestClient(Settings.Default.TDA_URI);
            var request = new RestRequest("/accounts", Method.GET).
                AddParameter("fields", _fields);
            request.AddHeader("Authorization", "Bearer " + accessToken);

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            List<Account> tokens = JsonConvert.DeserializeObject<List<Account>>(content);
            return tokens;
        }
    }

    public class Account
    {
        public SecuritiesAccount securitiesAccount { get; set; }

        public class Instrument
        {
            public string assetType { get; set; }
            public string cusip { get; set; }
            public string symbol { get; set; }
            public string description { get; set; }
            public string type { get; set; }
            public string putCall { get; set; }
            public string underlyingSymbol { get; set; }
        }

        public class Position
        {
            public double shortQuantity { get; set; }
            public double averagePrice { get; set; }
            public double currentDayProfitLoss { get; set; }
            public double currentDayProfitLossPercentage { get; set; }
            public double longQuantity { get; set; }
            public double settledLongQuantity { get; set; }
            public double settledShortQuantity { get; set; }
            public Instrument instrument { get; set; }
            public double marketValue { get; set; }
            public double maintenanceRequirement { get; set; }
        }

        public class InitialBalances
        {
            public double accruedInterest { get; set; }
            public double cashAvailableForTrading { get; set; }
            public double cashAvailableForWithdrawal { get; set; }
            public double cashBalance { get; set; }
            public double bondValue { get; set; }
            public double cashReceipts { get; set; }
            public double liquidationValue { get; set; }
            public double longOptionMarketValue { get; set; }
            public double longStockValue { get; set; }
            public double moneyMarketFund { get; set; }
            public double mutualFundValue { get; set; }
            public double shortOptionMarketValue { get; set; }
            public double shortStockValue { get; set; }
            public bool isInCall { get; set; }
            public double unsettledCash { get; set; }
            public double cashDebitCallValue { get; set; }
            public double pendingDeposits { get; set; }
            public double accountValue { get; set; }
        }

        public class CurrentBalances
        {
            public double accruedInterest { get; set; }
            public double cashBalance { get; set; }
            public double cashReceipts { get; set; }
            public double longOptionMarketValue { get; set; }
            public double liquidationValue { get; set; }
            public double longMarketValue { get; set; }
            public double moneyMarketFund { get; set; }
            public double savings { get; set; }
            public double shortMarketValue { get; set; }
            public double pendingDeposits { get; set; }
            public double cashAvailableForTrading { get; set; }
            public double cashAvailableForWithdrawal { get; set; }
            public double cashCall { get; set; }
            public double longNonMarginableMarketValue { get; set; }
            public double totalCash { get; set; }
            public double shortOptionMarketValue { get; set; }
            public double mutualFundValue { get; set; }
            public double bondValue { get; set; }
            public double cashDebitCallValue { get; set; }
            public double unsettledCash { get; set; }
        }

        public class ProjectedBalances
        {
            public double cashAvailableForTrading { get; set; }
            public double cashAvailableForWithdrawal { get; set; }
        }

        public class SecuritiesAccount
        {
            public string type { get; set; }
            public string accountId { get; set; }
            public int roundTrips { get; set; }
            public bool isDayTrader { get; set; }
            public bool isClosingOnlyRestricted { get; set; }
            public List<Position> positions { get; set; }
            public InitialBalances initialBalances { get; set; }
            public CurrentBalances currentBalances { get; set; }
            public ProjectedBalances projectedBalances { get; set; }
        }

    }
}
