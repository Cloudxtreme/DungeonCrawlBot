using System.Windows;
using GalaSoft.MvvmLight.Threading;

namespace DungeonCrawlBot
{
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }
    }
}
