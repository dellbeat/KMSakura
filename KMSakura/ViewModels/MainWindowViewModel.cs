using KMSakuraLib;
using KMSakuraLib.Models;
using Mirai.CSharp.HttpApi.Models.ChatMessages;
using Mirai.CSharp.Models.EventArgs;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using HttpApiModel = Mirai.CSharp.HttpApi.Models.EventArgs;
using Prism.Commands;
using System.Collections.ObjectModel;
using Mirai.CSharp.HttpApi.Models;
using System.Windows;
using Newtonsoft.Json;
using Prism.Services.Dialogs;

namespace KMSakura.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        BotConnectConfig Aconfig = null;
        BotConnectConfig BConfig = null;
        Bot botA = null;
        Bot botB = null;
        IDialogService _dialogService = null;

        private string _title = "测试";

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private long _targetNumber;

        public long TargetNumber
        {
            get => _targetNumber;
            set => SetProperty(ref _targetNumber, value);
        }

        private long _profile_FriendQQ;

        public long Profile_FriendQQ
        {
            get => _profile_FriendQQ;
            set => SetProperty(ref _profile_FriendQQ, value);
        }

        private long _profile_GroupQQ;

        public long Profile_GroupQQ
        {
            get => _profile_GroupQQ;
            set => SetProperty(ref _profile_GroupQQ, value);
        }

        private long _profile_GroupMemberQQ;

        public long Profile_GroupMemberQQ
        {
            get => _profile_GroupMemberQQ;
            set => SetProperty(ref _profile_GroupMemberQQ, value);
        }

        public MainWindowViewModel(IDialogService service)
        {
            _dialogService = service;
            Common.CommonInit();
            InitBotConfig();
            LoginBot();
            InitCommand();
        }

        private ObservableCollection<object> _dataCol;
        public ObservableCollection<object> DataCol
        {
            get => _dataCol;
            set => SetProperty(ref _dataCol, value);
        }

        public void InitCommand()
        {
            GetFriendCommand = new DelegateCommand(GetFriend);
            GetGroupListCommand = new DelegateCommand(GetGroupList);
            GetGroupMemberListCommand = new DelegateCommand(GetGroupMemberList);
            GetBotProfileCommand = new DelegateCommand(GetBotProfile);
            GetFriendPorifileCommand = new DelegateCommand(GetFriendPorifile);
            GetGroupMemberProfileCommand = new DelegateCommand(GetGroupMemberProfile);
            ShowSendMsgWindowCommand = new DelegateCommand(ShowSendMsgWindow);
            DataCol = new ObservableCollection<object>();
        }

        private void ShowSendMsgWindow()
        {
            var param = new DialogParameters();
            param.Add("bot", botA);
            _dialogService.Show("SendMessage", param, null);
        }

        private async void GetGroupList()
        {
            GroupInfo[] infos = await botA.GetGroupList() as GroupInfo[];

            DataCol.Clear();
            DataCol.AddRange(infos);
        }

        private async void GetGroupMemberProfile()
        {
            GroupMemberProfile memberProfile = await botA.GetGroupMemberProfile(Profile_GroupQQ, Profile_GroupMemberQQ) as GroupMemberProfile;

            MessageBox.Show(JsonConvert.SerializeObject(memberProfile));
        }

        private async void GetFriendPorifile()
        {
            FriendProfile friendProfile = await botA.GetFriendProfile(Profile_FriendQQ) as FriendProfile;

            MessageBox.Show(JsonConvert.SerializeObject(friendProfile));
        }

        private async void GetBotProfile()
        {
            BotProfile botProfile = await botA.GetBotProfile() as BotProfile;

            MessageBox.Show(JsonConvert.SerializeObject(botProfile));
        }

        private async void GetGroupMemberList()
        {
            if (TargetNumber <= 0)
            {
                return;
            }

            GroupMemberInfo[] infos = await botA.GetGroupMemberList(TargetNumber) as GroupMemberInfo[];

            DataCol.Clear();
            DataCol.AddRange(infos);
        }

        private async void GetFriend()
        {
            FriendInfo[] infos = await botA.GetFriendList() as FriendInfo[];

            DataCol.Clear();
            DataCol.AddRange(infos);
        }

        public DelegateCommand GetFriendCommand { get; set; }
        public DelegateCommand GetGroupListCommand { get; set; }
        public DelegateCommand GetGroupMemberListCommand { get; set; }
        public DelegateCommand GetBotProfileCommand { get; set; }
        public DelegateCommand GetFriendPorifileCommand { get; set; }
        public DelegateCommand GetGroupMemberProfileCommand { get; set; }
        public DelegateCommand ShowSendMsgWindowCommand { get; set; }

        private void InitBotConfig()
        {
            botA = new Bot();
            botB = new Bot();
            Aconfig = new BotConnectConfig
            {
                AuthKey = "8299b471ca7d1a63",
                IPAddress = "127.0.0.1",
                Port = 2333,
                QQNumber = 0,
                ConfigName = "AConfig"
            };

            BConfig = new BotConnectConfig
            {
                AuthKey = "8299b471ca7d1a63",
                IPAddress = "127.0.0.1",
                Port = 2333,
                QQNumber = 0,
                ConfigName = "BConfig"
            };
        }

        private async void LoginBot()
        {
            string AStatu = await botA.InitBot(Aconfig);

            Common.RunLogger.Info(AStatu);

            //string BStatu = await botB.InitBot(BConfig);

            //Common.RunLogger.Info(BStatu);

            //MessageBox.Show(AStatu + "|" + BStatu);
        }
    }
}
