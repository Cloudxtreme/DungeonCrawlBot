using WebSocketSharp;

namespace DungeonCrawlBot.Model
{
    public class MessageReceiver : IMessageReceiver
    {
        private readonly WebSocket mClient;
        private readonly IMessageDecoder mDecoder;
        private readonly IMessageDecompressor mDecompressor;

        public event DecodeMessageEventHandler ReceivedMessage;

        public MessageReceiver(WebSocket client, IMessageDecoder decoder, IMessageDecompressor decompressor)
        {
            mDecoder = decoder;
            mDecompressor = decompressor;
            mClient = client;
            mClient.OnMessage += OnMessage;
        }

        private byte[] CreateExtendedByteArray(byte[] defByteArray)
        {
            int byteArrayLenght = defByteArray.Length + 4;
            byte[] extendedByteArray = new byte[byteArrayLenght];
            for (int i = 0; i < defByteArray.Length; i++)
                extendedByteArray[i] = defByteArray[i];
            byte[] endArray = new byte[] { 0, 0, 255, 255 };
            int endArrayLenght = endArray.Length;
            for (int i = defByteArray.Length, j = 0; i < byteArrayLenght && j < endArrayLenght; i++, j++)
                extendedByteArray[i] = endArray[j];
            return extendedByteArray;
        }

        private void OnMessage(object sender, MessageEventArgs e)
        {
            if (ReceivedMessage != null)
            {
                var extendedByteArray = CreateExtendedByteArray(e.RawData);
                var decompressed = mDecompressor.Decompress(extendedByteArray);
                var decoded = mDecoder.Decode(decompressed);
                var decodedMessageEventArgs = new DecodedMessageEventArgs(decoded);
                ReceivedMessage(sender, e);
            }
        }
    }
}
