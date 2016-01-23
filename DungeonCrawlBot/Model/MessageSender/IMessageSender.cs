using System.Collections.Generic;

namespace DungeonCrawlBot.Model
{
    public interface IMessageSender
    {
        void SendMessage(string msg, Dictionary<string, string> data = null);
    }
}
