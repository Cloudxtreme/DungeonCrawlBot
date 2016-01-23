using System;
using WebSocketSharp;

namespace DungeonCrawlBot.Model
{
    public interface IMessageReceiver
    {
        event DecodeMessageEventHandler ReceivedMessage;
    }

    public delegate void DecodeMessageEventHandler(object sender, MessageEventArgs e);

    public class DecodedMessageEventArgs : EventArgs
    {
        public string Data { get; }

        public DecodedMessageEventArgs(string data)
        {
            Data = data;
        }
    }
}
