using Ninject;
using WebSocketSharp;

namespace DungeonCrawlBot.ViewModel
{
    public class ViewModelLocator
    {
        public const string DungeonCrawlUrl = "wss://crawl.s-z.org/socket";

        private static WebSocket Client = new WebSocket(DungeonCrawlUrl);

        public static void Cleanup() => Client.Close();

        private static ClientModule ServerModule = new ClientModule(Client);

        private static StandardKernel Kernel = new StandardKernel(ServerModule);

        public ViewModelLocator()
        {
            Client.Connect();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main => Kernel.Get<MainViewModel>();
    }
}