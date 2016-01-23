using System.Collections.Generic;

namespace DungeonCrawlBot.Model
{
    public class DungeonCrawlMessageSender
    {
        private readonly IMessageSender mMessageSender;

        public void GoLobby() =>
            mMessageSender.SendMessage(ServerCommands.GoLobbyMsg, new Dictionary<string, string>());

        public void SetCookie()
        {
            mMessageSender.SendMessage(ServerCommands.SetCookie);
        }

        public void RegAccount(string name, string pass, string email)
        {
            var regInfo = new Dictionary<string, string>()
            {
                ["username"] = name,
                ["password"] = pass,
                ["email"] = email
            };
            mMessageSender.SendMessage(ServerCommands.RegMsg, regInfo);
        }

        public void EnterGame(string playerName)
        {
            var enterGameInfo = new Dictionary<string, string>()
            {
                ["username"] = playerName
            };
            mMessageSender.SendMessage(ServerCommands.EnterGameMsg, enterGameInfo);
        }

        public void LoginAccount(string name, string pass)
        {
            var loginInfo = new Dictionary<string, string>()
            {
                ["username"] = name,
                ["password"] = pass
            };
            mMessageSender.SendMessage(ServerCommands.LoginMsg, loginInfo);
        }

        public void SendChatMessage(string chatMessage)
        {
            var sendMessageIno = new Dictionary<string, string>()
            {
                ["text"] = chatMessage
            };
            mMessageSender.SendMessage(ServerCommands.ChatSendMessageMsg, sendMessageIno);
        }

        public DungeonCrawlMessageSender(IMessageSender messageSender)
        {
            mMessageSender = messageSender;
        }
    }
}
