using System.Text;
using Newtonsoft.Json;

namespace DungeonCrawlBot.Model
{
    public class MessageDecoder : IMessageDecoder
    {
        public string Decode(byte[] byteArray) =>
            Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
    }
}
