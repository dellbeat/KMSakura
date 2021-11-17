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

        #region Params
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

        private long _delete_FriendQQ;

        public long Delete_FriendQQ
        {
            get => _delete_FriendQQ;
            set => SetProperty(ref _delete_FriendQQ, value);
        }

        private long _mute_MemberQQ;

        public long Mute_MemberQQ
        {
            get => _mute_MemberQQ;
            set => SetProperty(ref _mute_MemberQQ, value);
        }

        private long _mute_GroupQQ;

        public long Mute_GroupQQ
        {
            get => _mute_GroupQQ;
            set => SetProperty(ref _mute_GroupQQ, value);
        }

        private int _mute_Time;

        public int Mute_Time
        {
            get => _mute_Time;
            set => SetProperty(ref _mute_Time, value);
        }

        private long _kick_GroupQQ;

        public long Kick_GroupQQ
        {
            get => _kick_GroupQQ;
            set => SetProperty(ref _kick_GroupQQ, value);
        }

        private long _kick_MemberQQ;

        public long Kick_MemberQQ
        {
            get => _kick_MemberQQ;
            set => SetProperty(ref _kick_MemberQQ, value);
        }

        private long _leave_GroupQQ;

        public long Leave_GroupQQ
        {
            get => _leave_GroupQQ;
            set => SetProperty(ref _leave_GroupQQ, value);
        }

        private long _muteAll_GroupQQ;

        public long MuteAll_GroupQQ
        {
            get => _muteAll_GroupQQ;
            set => SetProperty(ref _muteAll_GroupQQ, value);
        }

        private int _essenceMessageId;

        public int EssenceMessageId
        {
            get => _essenceMessageId;
            set => SetProperty(ref _essenceMessageId, value);
        }

        private int _config_GroupQQ;

        public int Config_GroupQQ
        {
            get => _config_GroupQQ;
            set => SetProperty(ref _config_GroupQQ, value);
        }

        private long _card_GroupQQ;

        public long Card_GroupQQ
        {
            get => _card_GroupQQ;
            set => SetProperty(ref _card_GroupQQ, value);
        }

        private long _card_MemberQQ;

        public long Card_MemberQQ
        {
            get => _card_MemberQQ;
            set => SetProperty(ref _card_MemberQQ, value);
        }

        private long _setAdmin_GroupQQ;

        public long SetAdmin_GroupQQ
        {
            get => _setAdmin_GroupQQ;
            set => SetProperty(ref _setAdmin_GroupQQ, value);
        }

        private long _setAdmin_MemberQQ;

        public long SetAdmin_MemberQQ
        {
            get => _setAdmin_MemberQQ;
            set => SetProperty(ref _setAdmin_MemberQQ, value);
        }

        private bool _setAdmin_Statu;

        public bool SetAdmin_Statu
        {
            get => _setAdmin_Statu;
            set => SetProperty(ref _setAdmin_Statu, value);
        }

        private GroupConfig _groupConfig;

        public GroupConfig GroupConfig
        {
            get => _groupConfig;
            set => SetProperty(ref _groupConfig, value);
        }

        private long _changeConfig_GroupQQ;

        public long ChangeConfig_GroupQQ
        {
            get => _changeConfig_GroupQQ;
            set=>SetProperty(ref _changeConfig_GroupQQ, value);
        }

        private GroupMemberCardInfo _groupMemberInfo;

        public GroupMemberCardInfo GroupMemberInfo
        {
            get => _groupMemberInfo;
            set => SetProperty(ref _groupMemberInfo, value);
        }

        private long _changeMemberCard_GroupQQ;

        public long ChangeMemberCard_GroupQQ
        {
            get => _changeMemberCard_GroupQQ;
            set => SetProperty(ref _changeMemberCard_GroupQQ, value);
        }

        private long _changeMemberCard_MemberQQ;

        public long ChangeMemberCard_MemberQQ
        {
            get => _changeMemberCard_MemberQQ;
            set => SetProperty(ref _changeMemberCard_MemberQQ, value);
        }

        private ObservableCollection<object> _dataCol;
        public ObservableCollection<object> DataCol
        {
            get => _dataCol;
            set => SetProperty(ref _dataCol, value);
        }

        #endregion

        public MainWindowViewModel(IDialogService service)
        {
            _dialogService = service;
            Common.CommonInit();
            InitBotConfig();
            LoginBot();
            InitCommand();
            GroupConfig = new GroupConfig
            {
                Name = null,
                Announcement = null,
                ConfessTalk = null,
                MemberInvite = null,
                AutoApprove = null,
                AnonymousChat = null
            };
            GroupMemberInfo = new GroupMemberCardInfo
            {
                Name = null,
                SpecialTitle = null
            };
        }


        #region CommandFunction
        private async void ChangeGroupMemberInfo()
        {
            if (ChangeMemberCard_GroupQQ == 0 || ChangeMemberCard_MemberQQ == 0)
            {
                return;
            }

            if (string.IsNullOrEmpty(GroupMemberInfo.Name) && string.IsNullOrEmpty(GroupMemberInfo.SpecialTitle))
            {
                return;
            }

            await botA.ChangeGroupMemberInfo(ChangeMemberCard_MemberQQ, ChangeMemberCard_GroupQQ, GroupMemberInfo);

            GroupMemberInfo.Name = null;
            GroupMemberInfo.SpecialTitle = null;
        }

        private async void ChangeGroupConfig()
        {
            if (string.IsNullOrEmpty(GroupConfig.Name) && string.IsNullOrEmpty(GroupConfig.Announcement) && GroupConfig.ConfessTalk == null && 
                GroupConfig.MemberInvite == null && GroupConfig.AnonymousChat == null && GroupConfig.AutoApprove == null)
            {
                return;
            }

            if (ChangeConfig_GroupQQ == 0)
            {
                return;
            }

            await botA.ChangeGroupConfig(ChangeConfig_GroupQQ, GroupConfig);
        }

        private async void SetGroupAdmin()
        {
            if (SetAdmin_GroupQQ == 0 || SetAdmin_MemberQQ == 0)
            {
                return;
            }

            await botA.SetGroupAdmin(SetAdmin_MemberQQ, SetAdmin_GroupQQ, SetAdmin_Statu);
        }

        private async void GetGroupMemberInfo()
        {
            if (Card_GroupQQ == 0 || Card_MemberQQ == 0)
            {
                return;
            }

            GroupMemberInfo cardInfo = await botA.GetGroupMemberInfo(Card_MemberQQ, Card_GroupQQ) as GroupMemberInfo;

            MessageBox.Show(JsonConvert.SerializeObject(cardInfo));
        }

        private async void GetGroupConfig()
        {
            if (Config_GroupQQ == 0)
            {
                return;
            }

            GroupConfig config = await botA.GetGroupConfig(Config_GroupQQ) as GroupConfig;

            MessageBox.Show(JsonConvert.SerializeObject(config));
        }

        private async void SetEssenceMessage()
        {
            if (EssenceMessageId == 0)
            {
                return;
            }

            await botA.SetEssenceMessage(EssenceMessageId);
        }

        private async void UnmuteAll()
        {
            if (MuteAll_GroupQQ == 0)
            {
                return;
            }

            await botA.UnmuteAll(MuteAll_GroupQQ);
        }

        private async void MuteAll()
        {
            if (MuteAll_GroupQQ == 0)
            {
                return;
            }

            await botA.MuteAll(MuteAll_GroupQQ);
        }

        private async void LeaveGroup()
        {
            if (Leave_GroupQQ == 0)
            {
                return;
            }

            await botA.LeaveGroup(Leave_GroupQQ);
        }

        private async void KickMember()
        {
            if (Kick_MemberQQ == 0 || Kick_GroupQQ == 0)
            {
                return;
            }

            await botA.KickMember(Kick_MemberQQ, Kick_GroupQQ);
        }

        private async void UnmuteMember()
        {
            if (Mute_GroupQQ == 0 || Mute_MemberQQ == 0)
            {
                return;
            }

            await botA.Unmute(Mute_MemberQQ, Mute_GroupQQ);
        }

        private async void MuteMember()
        {
            if (Mute_GroupQQ == 0 || Mute_MemberQQ == 0 || Mute_Time == 0)
            {
                return;
            }

            await botA.Mute(Mute_MemberQQ, Mute_GroupQQ, Mute_Time);
        }

        private async void DeleteFriend()
        {
            if (Delete_FriendQQ == 0)
            {
                return;
            }

            await botA.DeleteFriend(Delete_FriendQQ);
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
        #endregion

        #region Command
        public DelegateCommand GetFriendCommand { get; set; }
        public DelegateCommand GetGroupListCommand { get; set; }
        public DelegateCommand GetGroupMemberListCommand { get; set; }
        public DelegateCommand GetBotProfileCommand { get; set; }
        public DelegateCommand GetFriendPorifileCommand { get; set; }
        public DelegateCommand GetGroupMemberProfileCommand { get; set; }
        public DelegateCommand ShowSendMsgWindowCommand { get; set; }
        public DelegateCommand DeleteFriendCommand { get; set; }
        public DelegateCommand MuteMemberCommand { get; set; }
        public DelegateCommand UnmuteMemberCommand { get; set; }
        public DelegateCommand KickMemberCommand { get; set; }
        public DelegateCommand LeaveGroupCommand { get; set; }
        public DelegateCommand MuteAllCommand { get; set; }
        public DelegateCommand UnmuteAllCommand { get; set; }
        public DelegateCommand SetEssenceMessageCommand { get; set; }
        public DelegateCommand GetGroupConfigCommand { get; set; }
        public DelegateCommand GetGroupMemberInfoCommand { get; set; }
        public DelegateCommand SetGroupAdminCommand { get; set; }
        public DelegateCommand ChangeGroupConfigCommand { get; set; }
        public DelegateCommand ChangeGroupMemberInfoCommand { get; set; }
        #endregion

        #region OtherFunction
        public void InitCommand()
        {
            GetFriendCommand = new DelegateCommand(GetFriend);
            GetGroupListCommand = new DelegateCommand(GetGroupList);
            GetGroupMemberListCommand = new DelegateCommand(GetGroupMemberList);
            GetBotProfileCommand = new DelegateCommand(GetBotProfile);
            GetFriendPorifileCommand = new DelegateCommand(GetFriendPorifile);
            GetGroupMemberProfileCommand = new DelegateCommand(GetGroupMemberProfile);
            ShowSendMsgWindowCommand = new DelegateCommand(ShowSendMsgWindow);
            DeleteFriendCommand = new DelegateCommand(DeleteFriend);
            MuteMemberCommand = new DelegateCommand(MuteMember);
            UnmuteMemberCommand = new DelegateCommand(UnmuteMember);
            KickMemberCommand = new DelegateCommand(KickMember);
            LeaveGroupCommand = new DelegateCommand(LeaveGroup);
            MuteAllCommand = new DelegateCommand(MuteAll);
            UnmuteAllCommand = new DelegateCommand(UnmuteAll);
            SetEssenceMessageCommand = new DelegateCommand(SetEssenceMessage);
            GetGroupConfigCommand = new DelegateCommand(GetGroupConfig);
            ChangeGroupConfigCommand = new DelegateCommand(ChangeGroupConfig);
            GetGroupMemberInfoCommand = new DelegateCommand(GetGroupMemberInfo);
            ChangeGroupMemberInfoCommand = new DelegateCommand(ChangeGroupMemberInfo);
            SetGroupAdminCommand = new DelegateCommand(SetGroupAdmin);
            DataCol = new ObservableCollection<object>();
        }
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
        }
        #endregion
    }
}
