using TDASharp.Properties;
using Newtonsoft.Json;
using RestSharp;

namespace TDASharp
{
    public interface ITokens
    {
        Tokens PostAccessToken();
    }

    public partial class TDAClient
    {
        public Tokens PostAccessToken()
        {
            var client = new RestClient(Settings.Default.TDA_URI);
            var request = new RestRequest("/oauth2/token", Method.POST).
                AddParameter("grant_type", "refresh_token").
                AddParameter("refresh_token", refreshToken).
                AddParameter("access_type", "").
                AddParameter("code", "").
                AddParameter("client_id", apiKey).
                AddParameter("redirect_url", "");

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            Tokens tokens = JsonConvert.DeserializeObject<Tokens>(content);
            return tokens;
        }
    }

    public class Tokens
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string scope { get; set; }
        public int refresh_token_expires_in { get; set; }
    }
}
