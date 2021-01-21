using Newtonsoft.Json;
using WebSocketSharp;
using System;

namespace TDASharp
{
    public partial class TDAWebsocket
    {
        private UserPrincipal userPrincipal;
        private int requestID = 0;
        WebSocket websocket;

        public TDAWebsocket(UserPrincipal UserPrincipal)
        {
            userPrincipal = UserPrincipal;
        }

        public bool StartWebSocket()
        {
            try
            {
                string URI = "wss://" + userPrincipal.streamerInfo.streamerSocketUrl + "/ws";
                websocket = new WebSocket(URI);
                websocket.OnOpen += new EventHandler(websocket_Opened);
                websocket.OnClose += new EventHandler<CloseEventArgs>(websocket_Closed);
                websocket.OnMessage += new EventHandler<MessageEventArgs>(websocket_MessageReceived);
                websocket.OnError += new EventHandler<ErrorEventArgs>(websocket_Error);

                if (Environment.OSVersion.Version.Major > 5)
                {
                    websocket.SslConfiguration.EnabledSslProtocols = (System.Security.Authentication.SslProtocols)3072;
                    websocket.SslConfiguration.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                }
                websocket.Connect();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void websocket_Opened(object sender, EventArgs e)
        {
            StartStreaming();
        }

        private void websocket_Error(object sender, ErrorEventArgs e)
        {
            Console.WriteLine(e.Message.ToString());
        }
        private void websocket_Closed(object sender, CloseEventArgs e)
        {
            Console.WriteLine(e.Code.ToString() + ": " + e.Reason.ToString());
        }
        private void websocket_MessageReceived(object sender, MessageEventArgs e)
        {
            if (e.Data.Contains("notify"))
            {
                var Heartbeat = JsonConvert.DeserializeObject<Notify>(e.Data);
            }
            else if (e.Data.Contains("response"))
            {
                var Response = JsonConvert.DeserializeObject<AdminResponseRoot>(e.Data);
            }
            else if (e.Data.Contains("data"))
            {

            }
            Console.WriteLine(e.Data.ToString());
        }
    }
}
