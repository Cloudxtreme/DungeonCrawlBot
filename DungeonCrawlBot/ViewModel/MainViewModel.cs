using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using DungeonCrawlBot.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace DungeonCrawlBot.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public RelayCommand RegAccountCommand { get; }
        public RelayCommand LoginAccountCommand { get; }
        public RelayCommand SendChatMessageCommand { get; }
        public RelayCommand EnterGameCommand { get; }
        public RelayCommand GoLobbyCommand { get; }

        public ObservableCollection<string> ConsoleMessages { get; } = new ObservableCollection<string>();

        private string mName;
        public string Name
        {
            get
            {
                return mName;
            }
            set
            {
                Set("Name", ref mName, value);
            }
        }
        private string mPass;
        public string Pass
        {
            get
            {
                return mPass;
            }
            set
            {
                Set("Pass", ref mPass, value);
            }
        }
        public string Email { get; set; }
        public string ChatMessage { get; set; }
        public string PlayerName { get; set; }

        private readonly DungeonCrawlMessageSender mDungeonCrawlMessageSender;
        private readonly IMessageReceiver mMessageReceiver;

        public MainViewModel(IMessageSender messageSender, IMessageReceiver messageReceiver)
        {
            mDungeonCrawlMessageSender = new DungeonCrawlMessageSender(messageSender);
            mMessageReceiver = messageReceiver;

            RegAccountCommand = new RelayCommand(() =>
            {
                mDungeonCrawlMessageSender.RegAccount(Name, Pass, Email);
                mDungeonCrawlMessageSender.SetCookie();
            });
            SendChatMessageCommand = new RelayCommand(() => mDungeonCrawlMessageSender.SendChatMessage(ChatMessage));
            LoginAccountCommand = new RelayCommand(() =>
            {
                mDungeonCrawlMessageSender.LoginAccount(Name, Pass);
                mDungeonCrawlMessageSender.SetCookie();
            });
            EnterGameCommand = new RelayCommand(() => mDungeonCrawlMessageSender.EnterGame(PlayerName));
            GoLobbyCommand = new RelayCommand(() => mDungeonCrawlMessageSender.GoLobby());
        }
    }
}