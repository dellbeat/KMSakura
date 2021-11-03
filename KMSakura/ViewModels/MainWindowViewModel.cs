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

namespace KMSakura.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        BotConnectConfig Aconfig = null;
        BotConnectConfig BConfig = null;
        Bot botA = null;
        Bot botB = null;

        private string _title = "测试";

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public MainWindowViewModel()
        {
            Common.CommonInit();
            GetEvent();
            InitBotConfig();
            LoginBot();
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

            //string BStatu = await botB.InitBot(BConfig);

            //Common.RunLogger.Info(BStatu);

            //MessageBox.Show(AStatu + "|" + BStatu);
        }

        #region 事件订阅测试代码
        [Conditional("EventTest")]
        private void GetEvent()
        {
            //Common.ea.GetEvent<BotGroupPermissionChangedEvent>().Subscribe(BotGroupPermissionChangedFC);
            //Common.ea.GetEvent<BotDroppedEvent>().Subscribe(BotDroppedFC);
            //Common.ea.GetEvent<BotInvitedJoinGroupEvent>().Subscribe(BotInvitedJoinGroupFC);
            //Common.ea.GetEvent<BotJoinedGroupEvent>().Subscribe(BotJoinedGroupFC);
            //Common.ea.GetEvent<BotKickedOfflineEvent>().Subscribe(BotKickedOfflineFC);
            //Common.ea.GetEvent<BotKickedOutEvent>().Subscribe(BotKickedOutFC);
            //Common.ea.GetEvent<BotMutedEvent>().Subscribe(BotMutedFC);
            //Common.ea.GetEvent<BotOnlineEvent>().Subscribe(BotOnlineFC);
            //Common.ea.GetEvent<BotPositiveLeaveGroupEvent>().Subscribe(BotPositiveLeaveGroupFC);
            //Common.ea.GetEvent<BotReloginEvent>().Subscribe(BotReloginFC);
            //Common.ea.GetEvent<BotUnmutedEvent>().Subscribe(BotUnmutedFC);

            //Common.ea.GetEvent<FriendInputStatusChangedEvent>().Subscribe(FriendInputStatusChangedFC);
            //Common.ea.GetEvent<FriendMessageEvent>().Subscribe(FriendMessageFC);
            //Common.ea.GetEvent<FriendMessageRevokedEvent>().Subscribe(FriendMessageRevokedFC);
            //Common.ea.GetEvent<FriendNickChangedEvent>().Subscribe(FriendNickChangedFC);
            //Common.ea.GetEvent<NewFriendApplyEvent>().Subscribe(NewFriendApplyFC);

            //Common.ea.GetEvent<OtherClientMessageEvent>().Subscribe(OtherClientMessageFC);
            //Common.ea.GetEvent<StrangerMessageEvent>().Subscribe(StrangerMessageFC);
            //Common.ea.GetEvent<TempMessageEvent>().Subscribe(TempMessageFC);

            //Common.ea.GetEvent<GroupAnonymousChatChangedEvent>().Subscribe(GroupAnonymousChatChangedFC);
            //Common.ea.GetEvent<GroupConfessTalkChangedEvent>().Subscribe(GroupConfessTalkChangedFC);
            //Common.ea.GetEvent<GroupEntranceAnnouncementChangedEvent>().Subscribe(GroupEntranceAnnouncementChangedFC);
            //Common.ea.GetEvent<GroupMemberCardChangedEvent>().Subscribe(GroupMemberCardChangedFC);
            //Common.ea.GetEvent<GroupMemberInviteChangedEvent>().Subscribe(GroupMemberInviteChangedFC);
            //Common.ea.GetEvent<GroupMemberJoinedEvent>().Subscribe(GroupMemberJoinedFC);
            //Common.ea.GetEvent<GroupMemberKickedEvent>().Subscribe(GroupMemberKickedFC);
            //Common.ea.GetEvent<GroupMemberPermissionChangedEvent>().Subscribe(GroupMemberPermissionChangedFC);
            //Common.ea.GetEvent<GroupMemberPositiveLeaveEvent>().Subscribe(GroupMemberPermissionChangedFC);
            //Common.ea.GetEvent<GroupMemberSpecialTitleChangedEvent>().Subscribe(GroupMemberSpecialTitleChangedFC);
            //Common.ea.GetEvent<GroupMuteAllChangedEvent>().Subscribe(GroupMuteAllChangedFC);
            //Common.ea.GetEvent<GroupNameChangedEvent>().Subscribe(GroupNameChangedFC);
            //Common.ea.GetEvent<GroupApplyEvent>().Subscribe(GroupApplyFC);
            //Common.ea.GetEvent<GroupMemberHonorEvent>().Subscribe(GroupMemberHonorFC);
            //Common.ea.GetEvent<GroupMemberMutedEvent>().Subscribe(GroupMemberMutedFC);
            //Common.ea.GetEvent<GroupMemberUnmutedEvent>().Subscribe(GroupMemberUnmutedFC);
            //Common.ea.GetEvent<GroupMessageEvent>().Subscribe(GroupMessageFC);
            //Common.ea.GetEvent<GroupMessageRevokedEvent>().Subscribe(GroupMessageRevokedFC);
        }

        private void GroupMessageRevokedFC(IKMSakuraMessage<IGroupMessageRevokedEventArgs> obj)
        {
            HttpApiModel.GroupMessageRevokedEventArgs message = obj.Message as HttpApiModel.GroupMessageRevokedEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"群消息被撤回：消息ID:{message.MessageId} 群{message.Group.Name}({message.Group.Id})" +
                $"一条消息被{message.Operator.Name}({message.Operator.Id})撤回");
            });
        }

        private void GroupMessageFC(IKMSakuraMessage<IGroupMessageEventArgs> obj)
        {
            HttpApiModel.GroupMessageEventArgs message = obj.Message as HttpApiModel.GroupMessageEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                ISourceMessage source = message.Chain[0] as ISourceMessage;
                System.Windows.MessageBox.Show($"群消息到达：消息ID:({source.Id}) 时间戳:({source.Time}) [{message.Sender.Group.Name}({message.Sender.Group.Id})]" +
                $"-{message.Sender.Name}({message.Sender.Id}) -> {string.Join("", (IEnumerable<IChatMessage>)message.Chain)}");
            });
        }

        private void GroupMemberUnmutedFC(IKMSakuraMessage<IGroupMemberUnmutedEventArgs> obj)
        {
            HttpApiModel.GroupMemberUnmutedEventArgs message = obj.Message as HttpApiModel.GroupMemberUnmutedEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"群{message.Member.Group.Name}({message.Member.Group.Id})" +
                $"成员{message.Member.Name}({message.Member.Id})被{message.Operator.Permission}{message.Operator.Name}({message.Operator.Id})解除禁言");
            });
        }

        private void GroupMemberMutedFC(IKMSakuraMessage<IGroupMemberMutedEventArgs> obj)
        {
            HttpApiModel.GroupMemberMutedEventArgs message = obj.Message as HttpApiModel.GroupMemberMutedEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"群{message.Member.Group.Name}({message.Member.Group.Id})" +
                $"成员{message.Member.Name}({message.Member.Id})被{message.Operator.Permission}{message.Operator.Name}({message.Operator.Id})" +
                $"禁言{message.Duration.TotalMinutes}分钟");
            });
        }

        private void GroupMemberHonorFC(IKMSakuraMessage<IGroupMemberHonorChangedEventArgs> obj)
        {
            HttpApiModel.GroupMemberHonorChangedEventArgs message = obj.Message as HttpApiModel.GroupMemberHonorChangedEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"群{message.Member.Group.Name}({message.Member.Group.Id})-" +
                $"成员{message.Member.Name}({message.Member.Id}){(message.State == Mirai.CSharp.Models.GroupHonorState.Achieve ? "获得" : "失去")}荣誉{message.Honor}");
            });
        }

        private void GroupApplyFC(IKMSakuraMessage<IGroupApplyEventArgs> obj)
        {
            HttpApiModel.GroupApplyEventArgs message = obj.Message as HttpApiModel.GroupApplyEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"事件ID{message.EventId}/{message.NickName}({message.FromQQ})" +
                $"申请加入群{message.FromGroupName}({message.FromGroup})" + $"入群消息为{message.Message}");
            });
        }

        private void GroupNameChangedFC(IKMSakuraMessage<IGroupNameChangedEventArgs> obj)
        {
            HttpApiModel.GroupNameChangedEventArgs message = obj.Message as HttpApiModel.GroupNameChangedEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"群{message.Group.Name}({message.Group.Id})" +
                $"成员{message.Operator.Name}({message.Operator.Id})将群名称由{message.Origin}修改为{message.Current}");
            });
        }

        private void GroupMuteAllChangedFC(IKMSakuraMessage<IGroupMuteAllChangedEventArgs> obj)
        {
            HttpApiModel.GroupMuteAllChangedEventArgs message = obj.Message as HttpApiModel.GroupMuteAllChangedEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"群{message.Group.Name}({message.Group.Id}){message.Operator.Permission}" +
                $"{message.Operator.Name}({message.Operator.Id})" + $"{(message.Current ? "开启" : "关闭")}了全体禁言");
            });
        }

        private void GroupMemberSpecialTitleChangedFC(IKMSakuraMessage<IGroupMemberSpecialTitleChangedEventArgs> obj)
        {
            HttpApiModel.GroupMemberSpecialTitleChangedEventArgs message = obj.Message as HttpApiModel.GroupMemberSpecialTitleChangedEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"群{message.Member.Group.Name}({message.Member.Group.Id})" +
                $"内成员{message.Member.Name}({message.Member.Id})的专属头衔由{message.Origin}修改为{message.Current}");
            });
        }

        private void GroupMemberPermissionChangedFC(IKMSakuraMessage<IGroupMemberPositiveLeaveEventArgs> obj)
        {
            HttpApiModel.GroupMemberPositiveLeaveEventArgs message = obj.Message as HttpApiModel.GroupMemberPositiveLeaveEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"{message.Member.Name}({message.Member.Id})" +
                $"主动退出群{message.Member.Group.Name}({message.Member.Group.Id})");
            });
        }

        private void GroupMemberPermissionChangedFC(IKMSakuraMessage<IGroupMemberPermissionChangedEventArgs> obj)
        {
            HttpApiModel.GroupMemberPermissionChangedEventArgs message = obj.Message as HttpApiModel.GroupMemberPermissionChangedEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"群{message.Member.Group.Name}({message.Member.Group.Id})" +
                $"内成员{message.Member.Name}({message.Member.Id})权限由{message.Origin}更改为{message.Current}");
            });
        }

        private void GroupMemberKickedFC(IKMSakuraMessage<IGroupMemberKickedEventArgs> obj)
        {
            HttpApiModel.GroupMemberKickedEventArgs message = obj.Message as HttpApiModel.GroupMemberKickedEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"成员{message.Member.Name}({message.Member.Id})" +
                $"被{message.Operator.Name}({message.Operator.Id})移出群{message.Member.Group.Name}({message.Member.Group.Id})");
            });
        }

        private void GroupMemberJoinedFC(IKMSakuraMessage<IGroupMemberJoinedEventArgs> obj)
        {
            HttpApiModel.GroupMemberJoinedEventArgs message = obj.Message as HttpApiModel.GroupMemberJoinedEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"新成员{message.Member.Name}({message.Member.Id})" +
                $"加入群{message.Member.Group.Name}({message.Member.Group.Id}){(message.Inviter == null ? "" : $",邀请者为{message.Inviter.Name}({message.Inviter.Id})")}");
            });
        }

        private void GroupMemberInviteChangedFC(IKMSakuraMessage<IGroupMemberInviteChangedEventArgs> obj)
        {
            HttpApiModel.GroupMemberInviteChangedEventArgs message = obj.Message as HttpApiModel.GroupMemberInviteChangedEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"群{message.Group.Name}({message.Group.Id})" +
                $"群成员邀请设置被{message.Operator.Name}({message.Operator.Id})更改为{(message.Current ? "允许" : "不允许")}群成员邀请好友加入群聊");
            });
        }

        private void GroupMemberCardChangedFC(IKMSakuraMessage<IGroupMemberCardChangedEventArgs> obj)
        {
            HttpApiModel.GroupMemberCardChangedEventArgs message = obj.Message as HttpApiModel.GroupMemberCardChangedEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"群{message.Member.Group.Name}({message.Member.Group.Id})" +
                $"成员{message.Member.Name}({message.Member.Id})群昵称由{message.Origin}修改为{message.Current}");
            });
        }

        private void GroupEntranceAnnouncementChangedFC(IKMSakuraMessage<IGroupEntranceAnnouncementChangedEventArgs> obj)
        {
            HttpApiModel.GroupEntranceAnnouncementChangedEventArgs message = obj.Message as HttpApiModel.GroupEntranceAnnouncementChangedEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"群{message.Group.Name}({message.Group.Id})的入群公告被改变");
            });
        }

        private void GroupConfessTalkChangedFC(IKMSakuraMessage<IGroupConfessTalkChangedEventArgs> obj)
        {
            HttpApiModel.GroupConfessTalkChangedEventArgs message = obj.Message as HttpApiModel.GroupConfessTalkChangedEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"群{message.Group.Name}({message.Group.Id})" +
                $"群坦白说设置被{(message.Operator != null ? (message.Operator.Id.ToString() + $"({message.Operator.Name})") : "")}更改为{(message.Current ? "开启" : "关闭")}群坦白说");
            });
        }

        private void GroupAnonymousChatChangedFC(IKMSakuraMessage<IGroupAnonymousChatChangedEventArgs> obj)
        {
            HttpApiModel.GroupAnonymousChatChangedEventArgs message = obj.Message as HttpApiModel.GroupAnonymousChatChangedEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"群{message.Group.Name}({message.Group.Id})" +
                $"群匿名聊天设置被{message.Operator.Name}({message.Operator.Id})更改为{(message.Current ? "开启" : "关闭")}群匿名聊天");
            });
        }

        private void TempMessageFC(IKMSakuraMessage<ITempMessageEventArgs> obj)
        {
            HttpApiModel.TempMessageEventArgs message = obj.Message as HttpApiModel.TempMessageEventArgs;
            
            Task.Run(async () =>
            {
                await Task.Delay(1);
                ISourceMessage source = message.Chain[0] as ISourceMessage;
                System.Windows.MessageBox.Show($"临时会话消息：消息ID:({source.Id}) 时间戳:({source.Time})" +
                $"-{message.Sender.Name}({message.Sender.Id}) -> {string.Join("", (IEnumerable<IChatMessage>)message.Chain)}");
            });
        }

        private void StrangerMessageFC(IKMSakuraMessage<IStrangerMessageEventArgs> obj)
        {
            HttpApiModel.Stranger.StrangerMessageEventArgs message = obj.Message as HttpApiModel.Stranger.StrangerMessageEventArgs;
            
            Task.Run(async () =>
            {
                await Task.Delay(1);
                ISourceMessage source = message.Chain[0] as ISourceMessage;
                System.Windows.MessageBox.Show($"陌生人消息：消息ID:({source.Id}) 时间戳:({source.Time})" +
                $"-{message.Sender.Name}({message.Sender.Id}) -> {string.Join("", (IEnumerable<IChatMessage>)message.Chain)}");
            });
        }

        private void OtherClientMessageFC(IKMSakuraMessage<IOtherClientMessageEventArgs> obj)
        {
            HttpApiModel.OtherClient.OtherClientMessageEventArgs message = obj.Message as HttpApiModel.OtherClient.OtherClientMessageEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                ISourceMessage source = message.Chain[0] as ISourceMessage;
                System.Windows.MessageBox.Show($"其他客户端消息：消息ID:({source.Id}) 时间戳:({source.Time})" +
                $"{message.Sender.Name}(设备类型:{message.Sender.Platform})" +
                $"-{message.Sender.Name}({message.Sender.Id}) -> {string.Join("", (IEnumerable<IChatMessage>)message.Chain)}");
            });
        }

        private void NewFriendApplyFC(IKMSakuraMessage<INewFriendApplyEventArgs> obj)
        {
            HttpApiModel.NewFriendApplyEventArgs message = obj.Message as HttpApiModel.NewFriendApplyEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"事件ID{message.EventId}/{message.NickName}({message.FromQQ})" +
                $"申请添加好友" + $"验证消息为{message.Message}");
            });
        }

        private void FriendNickChangedFC(IKMSakuraMessage<IFriendNickChangedEventArgs> obj)
        {
            HttpApiModel.FriendNickChangedEventArgs message = obj.Message as HttpApiModel.FriendNickChangedEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"好友{message.Friend.Name}({message.Friend.Id})昵称从{message.Origin}更改为{message.Current}");
            });
        }

        private void FriendMessageRevokedFC(IKMSakuraMessage<IFriendMessageRevokedEventArgs> obj)
        {
            HttpApiModel.FriendMessageRevokedEventArgs message = obj.Message as HttpApiModel.FriendMessageRevokedEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"好友{message.SenderId}撤回了一条发送于{message.SentTime}ID为{message.MessageId}的消息");
            });
        }

        private void FriendMessageFC(IKMSakuraMessage<IFriendMessageEventArgs> obj)
        {
            HttpApiModel.FriendMessageEventArgs message = obj.Message as HttpApiModel.FriendMessageEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                ISourceMessage source = message.Chain[0] as ISourceMessage;
                System.Windows.MessageBox.Show($"消息ID:({source.Id}) 时间戳:({source.Time}) " +
                $"{message.Sender.Name}({message.Sender.Id})-{string.Join("", (IEnumerable<IChatMessage>)message.Chain)}");
            });
        }

        private void FriendInputStatusChangedFC(IKMSakuraMessage<IFriendInputStatusChangedEventArgs> obj)
        {
            HttpApiModel.FriendInputStatusChangedEventArgs message = obj.Message as HttpApiModel.FriendInputStatusChangedEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"好友{message.Friend.Name}({message.Friend.Id}){(message.Inputting ? "正在输入" : "输入结束")}");
            });
        }

        private void BotUnmutedFC(IKMSakuraMessage<IBotUnmutedEventArgs> obj)
        {
            HttpApiModel.BotUnmutedEventArgs message = obj.Message as HttpApiModel.BotUnmutedEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"BOT在群{message.Operator.Group.Name}({message.Operator.Group.Id})" +
                $"被{message.Operator.Name}({message.Operator.Id})解除禁言");
            });
        }

        private void BotReloginFC(IKMSakuraMessage<IBotReloginEventArgs> obj)
        {
            HttpApiModel.BotReloginEventArgs message = obj.Message as HttpApiModel.BotReloginEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"BOT{message.QQNumber}重新登录");
            });
        }

        [Obsolete("该事件目前无法被触发 等待进一步确认")]
        private void BotPositiveLeaveGroupFC(IKMSakuraMessage<IBotPositiveLeaveGroupEventArgs> obj)
        {
            HttpApiModel.BotPositiveLeaveGroupEventArgs message = obj.Message as HttpApiModel.BotPositiveLeaveGroupEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"BOT主动退出群{message.Group.Name}({message.Group.Id})");
            });
        }

        private void BotOnlineFC(IKMSakuraMessage<IBotOnlineEventArgs> obj)
        {
            HttpApiModel.BotOnlineEventArgs message = obj.Message as HttpApiModel.BotOnlineEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"BOT{message.QQNumber}登录成功");
            });
        }

        private void BotMutedFC(IKMSakuraMessage<IBotMutedEventArgs> obj)
        {
            HttpApiModel.BotMutedEventArgs message = obj.Message as HttpApiModel.BotMutedEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"BOT在群{message.Operator.Group.Name}({message.Operator.Group.Id})" +
                $"被{message.Operator.Name}({message.Operator.Id})禁言{message.Duration.TotalMinutes}分钟");
            });
        }

        private void BotKickedOutFC(IKMSakuraMessage<IBotKickedOutEventArgs> obj)
        {
            HttpApiModel.BotKickedOutEventArgs message = obj.Message as HttpApiModel.BotKickedOutEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"BOT被{message.Operator.Name}({message.Operator.Id})" +
                $"移出群{message.Group.Name}({message.Group.Id})");
            });
        }

        private void BotKickedOfflineFC(IKMSakuraMessage<IBotKickedOfflineEventArgs> obj)
        {
            HttpApiModel.BotKickedOfflineEventArgs message = obj.Message as HttpApiModel.BotKickedOfflineEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"BOT{message.QQNumber}被迫掉线");
            });
        }

        private void BotJoinedGroupFC(IKMSakuraMessage<IBotJoinedGroupEventArgs> obj)
        {
            HttpApiModel.BotJoinedGroupEventArgs message = obj.Message as HttpApiModel.BotJoinedGroupEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"BOT加入了群{message.Group.Name}({message.Group.Id})" +
                $"{(message.Inviter == null ? "" : $",邀请者为{message.Inviter.Name}({message.Inviter.Id})")}");
            });
        }

        private void BotInvitedJoinGroupFC(IKMSakuraMessage<IBotInvitedJoinGroupEventArgs> obj)
        {
            HttpApiModel.BotInvitedJoinGroupEventArgs message = obj.Message as HttpApiModel.BotInvitedJoinGroupEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"BOT收到来自{message.NickName}({message.FromQQ})邀请至群{message.FromGroupName}({message.FromGroup})的消息");
            });
        }

        private void BotGroupPermissionChangedFC(IKMSakuraMessage<IBotGroupPermissionChangedEventArgs> obj)
        {
            HttpApiModel.BotGroupPermissionChangedEventArgs args = obj.Message as HttpApiModel.BotGroupPermissionChangedEventArgs;

            Task.Run(async ()=>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"Bot在群{args.Group.Name}({args.Group.Id})的权限从{args.Origin}被修改为{args.Current}");
            });
        }

        private void BotDroppedFC(IKMSakuraMessage<IBotDroppedEventArgs> obj)
        {
            HttpApiModel.BotDroppedEventArgs message = obj.Message as HttpApiModel.BotDroppedEventArgs;

            Task.Run(async () =>
            {
                await Task.Delay(1);
                System.Windows.MessageBox.Show($"Bot{message.QQNumber}意外断连");
            });
        }

        
        #endregion
    }
}
