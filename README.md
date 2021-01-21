# TDASharp

<H1>Instructions</H1>

<H2>For APIs</H2>
<ol>
  <li>TDAClient tdaclient = new TDAClient(TDA_Account, TDA_API, RefreshToken);</li>
  <li>tdaclient.Login();</li>
</ol>
<h3>Examples</h3>
<ul>
  <li>tdaclient.GetPriceHistory("AAPL", frequencyType.minute, 1, periodType.day, 2);</li>
  <li>tdaclient.GetPriceHistory("AAPL", 1, new DateTime(2021, 01, 13, 12, 30, 00), new DateTime(2021, 01, 13, 12, 00, 00));</li>
  <li>tdaclient.GetQuote("AAPL");</li>
</ul>

<H2>For Streaming</H2>
<ol>
  <li>To Start Websocket</li>
var principals = tdaclient.GetUserPrincipals(preferencefields.streamer);
  
tdaWebsocket = new TDAWebsocket(principals);

tdaWebsocket.StartWebSocket();

  <li>To Stop Websocket</li>

tdaWebsocket.StopWebSocket();

  <li>WebSocket Example</li>

tdaWebsocket.GetNewsHeadlines("GOOG");

</ol>
