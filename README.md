# TDASharp

Instructions

For APIs

(1) TDAClient tdaclient = new TDAClient(TDA_Account, TDA_API, RefreshToken);

-Examples

tdaclient.GetPriceHistory("AAPL", frequencyType.minute, 1, periodType.day, 2);

tdaclient.GetPriceHistory("AAPL", 1, new DateTime(2021, 01, 13, 12, 30, 00), new DateTime(2021, 01, 13, 12, 00, 00));

tdaclient.GetQuote("AAPL");


For Streaming

(1) To Start Websocket

var principals = tdaclient.GetUserPrincipals(preferencefields.streamer);

tdaWebsocket = new TDAWebsocket(principals);

tdaWebsocket.StartWebSocket();

(2) To Stop Websocket

tdaWebsocket.StopWebSocket();

(3) WebSocket Example

tdaWebsocket.GetNewsHeadlines("GOOG");
