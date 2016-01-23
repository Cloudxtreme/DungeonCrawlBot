using WebSocketSharp;

namespace DungeonCrawlBot.Model
{
    public class RawSender : IRawSender
    {
        private readonly WebSocket mClient;

        public void SendRawMessage(byte[] byteArray)
        {
            mClient.Send(byteArray);
        }

        public RawSender(WebSocket client)
        {
            mClient = client;
        }
    }
}
