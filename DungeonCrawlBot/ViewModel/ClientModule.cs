using DungeonCrawlBot.Model;
using Ninject.Modules;
using WebSocketSharp;

namespace DungeonCrawlBot.ViewModel
{
    public class ClientModule : NinjectModule
    {
        private readonly WebSocket mWebSocket;

        public override void Load()
        {
            Bind<IRawSender>().To<RawSender>()
                .WithConstructorArgument("client", mWebSocket);
            Bind<IMessageReceiver>().To<MessageReceiver>()
                .WithConstructorArgument("client", mWebSocket);
            Bind<IMessageSender>().To<MessageSender>();
            Bind<IMessageDecompressor>().To<DeflateDecompressor>();
            Bind<IMessageDecoder>().To<MessageDecoder>();
        }

        public ClientModule(WebSocket webSocket)
        {
            mWebSocket = webSocket;
        }
    }
}
