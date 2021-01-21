using System.Collections.Generic;
using System;

namespace TDASharp
{
    public interface ITDAClient
    {
        Account Login();
        List<string> GetPortfolioSymbols();
    }

    public partial class TDAClient : ITDAClient, IPriceHistory, IQuotes, IMovers, IInstruments, ITokens, IAccounts, IUserInfoAndPreferences
    {
        private string accountNumber;
        private string refreshToken;
        private string accessToken;
        private string apiKey;
        Account tdaAccount;

        public TDAClient(string AccountNumber, string ApiKey, string RefreshToken)
        {
            accountNumber = AccountNumber;
            apiKey = ApiKey;
            refreshToken = RefreshToken;
            tdaAccount = new Account();
        }

        public Account Login()
        {
            try
            {
                accessToken = PostAccessToken().access_token;
                tdaAccount = GetAccounts(fields.positions)[0];
            }
            catch (Exception ex)
            {
                //
            }
            return tdaAccount;
        }

        public List<string> GetPortfolioSymbols()
        {
            List<string> Symbols = new List<string>();
            foreach (var position in tdaAccount.securitiesAccount.positions)
            {
                string symbol = position.instrument.symbol;
                if (symbol.Contains("_"))
                {
                    symbol = symbol.Remove(symbol.IndexOf('_'), symbol.Length - symbol.IndexOf('_'));

                }
                if (symbol.Contains("MM"))
                {
                    continue;
                }
                Symbols.Add(symbol);
            }
            return Symbols;
        }
    }
}