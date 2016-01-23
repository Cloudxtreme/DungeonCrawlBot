using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DungeonCrawlBot.Model
{
    public class MessageSender : IMessageSender
    {
        private readonly IRawSender mRawSender;

        public void SendMessage(string msg, Dictionary<string, string> data = null)
        {
            var msgData = data != null ? new Dictionary<string, string>(data) : new Dictionary<string, string>();
            msgData.Add("msg", msg);

            var jsonRegInfo = JsonConvert.SerializeObject(msgData);
            var dataBytes = Encoding.ASCII.GetBytes(jsonRegInfo);

            mRawSender.SendRawMessage(dataBytes);
        }

        public MessageSender(IRawSender rawSender)
        {
            mRawSender = rawSender;
        }
    }
}
