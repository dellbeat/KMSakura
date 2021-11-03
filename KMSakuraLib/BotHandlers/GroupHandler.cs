using KMSakuraLib.Ability;
using KMSakuraLib.Events;
using KMSakuraLib.Models;
using KMSakuraLib.Session;
using Mirai.CSharp.Handlers;
using Mirai.CSharp.Models.ChatMessages;
using Mirai.CSharp.Models.EventArgs;
using Mirai.CSharp.Session;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KMSakuraLib.BotHandlers
{
    /// <summary>
    /// 匿名聊天设置被改变
    /// </summary>
    public class GroupAnonymousChatChangedHandler : Handler, IMiraiMessageHandler<IMiraiSession, IGroupAnonymousChatChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupAnonymousChatChangedEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.ea.GetEvent<GroupAnonymousChatChangedEvent>().Publish(new KMSakuraMessage<IGroupAnonymousChatChangedEventArgs>(session.QQNumber, message));
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"群{message.Group.Name}({message.Group.Id})" +
                $"群匿名聊天设置被{message.Operator.Name}({message.Operator.Id})更改为{(message.Current ? "开启" : "关闭")}群匿名聊天");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// 坦白说设置被改变
    /// </summary>
    public class GroupConfessTalkChangedHandler : Handler, IMiraiMessageHandler<IMiraiSession, IGroupConfessTalkChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupConfessTalkChangedEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.ea.GetEvent<GroupConfessTalkChangedEvent>().Publish(new KMSakuraMessage<IGroupConfessTalkChangedEventArgs>(session.QQNumber, message));
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"群{message.Group.Name}({message.Group.Id})" +
                $"群坦白说设置被{(message.Operator!=null?(message.Operator.Id.ToString()+$"({message.Operator.Name})") :"")}更改为{(message.Current ? "开启" : "关闭")}群坦白说");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// 入群公告被改变
    /// </summary>
    public class GroupEntranceAnnouncementChangedHandler : Handler, IMiraiMessageHandler<IMiraiSession, IGroupEntranceAnnouncementChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupEntranceAnnouncementChangedEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.ea.GetEvent<GroupEntranceAnnouncementChangedEvent>().Publish(new KMSakuraMessage<IGroupEntranceAnnouncementChangedEventArgs>(session.QQNumber, message));
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"群{message.Group.Name}({message.Group.Id})的入群公告被改变");
            //出于部分原因考虑，不记录具体的入群公告，可以在参数传递到订阅事件后自行处理
            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// 成员群名片被修改
    /// </summary>
    public class GroupMemberCardChangedHandler : Handler, IMiraiMessageHandler<IMiraiSession, IGroupMemberCardChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupMemberCardChangedEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.ea.GetEvent<GroupMemberCardChangedEvent>().Publish(new KMSakuraMessage<IGroupMemberCardChangedEventArgs>(session.QQNumber, message));
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"群{message.Member.Group.Name}({message.Member.Group.Id})" +
                $"成员{message.Member.Name}({message.Member.Id})群昵称由{message.Origin}修改为{message.Current}");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// 群成员邀请设置被更改
    /// </summary>
    public class GroupMemberInviteChangedHandler : Handler, IMiraiMessageHandler<IMiraiSession, IGroupMemberInviteChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupMemberInviteChangedEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.ea.GetEvent<GroupMemberInviteChangedEvent>().Publish(new KMSakuraMessage<IGroupMemberInviteChangedEventArgs>(session.QQNumber, message));
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"群{message.Group.Name}({message.Group.Id})" +
                $"群成员邀请设置被{message.Operator.Name}({message.Operator.Id})更改为{(message.Current ? "允许" : "不允许")}群成员邀请好友加入群聊");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// 新人入群消息
    /// </summary>
    public class GroupMemberJoinedHandler : Handler, IMiraiMessageHandler<IMiraiSession, IGroupMemberJoinedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupMemberJoinedEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.ea.GetEvent<GroupMemberJoinedEvent>().Publish(new KMSakuraMessage<IGroupMemberJoinedEventArgs>(session.QQNumber, message));
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"新成员{message.Member.Name}({message.Member.Id})" +
                $"加入群{message.Member.Group.Name}({message.Member.Group.Id}){(message.Inviter == null ? "" : $",邀请者为{message.Inviter.Name}({message.Inviter.Id})")}");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// 成员被踢出群
    /// </summary>
    public class GroupMemberKickedHandler : Handler, IMiraiMessageHandler<IMiraiSession, IGroupMemberKickedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupMemberKickedEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.ea.GetEvent<GroupMemberKickedEvent>().Publish(new KMSakuraMessage<IGroupMemberKickedEventArgs>(session.QQNumber, message));
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"成员{message.Member.Name}({message.Member.Id})" +
                $"被{message.Operator.Name}({message.Operator.Id})移出群{message.Member.Group.Name}({message.Member.Group.Id})");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// 群成员权限被改变
    /// </summary>
    public class GroupMemberPermissionChangedHandler : Handler, IMiraiMessageHandler<IMiraiSession, IGroupMemberPermissionChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupMemberPermissionChangedEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.ea.GetEvent<GroupMemberPermissionChangedEvent>().Publish(new KMSakuraMessage<IGroupMemberPermissionChangedEventArgs>(session.QQNumber, message));
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"群{message.Member.Group.Name}({message.Member.Group.Id})" +
                $"内成员{message.Member.Name}({message.Member.Id})权限由{message.Origin}更改为{message.Current}");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// 群成员主动离群
    /// </summary>
    public class GroupMemberPositiveLeaveHandler : Handler, IMiraiMessageHandler<IMiraiSession, IGroupMemberPositiveLeaveEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupMemberPositiveLeaveEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.ea.GetEvent<GroupMemberPositiveLeaveEvent>().Publish(new KMSakuraMessage<IGroupMemberPositiveLeaveEventArgs>(session.QQNumber, message));
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"{message.Member.Name}({message.Member.Id})" +
                $"主动退出群{message.Member.Group.Name}({message.Member.Group.Id})");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// 群成员的专属头衔被改变
    /// </summary>
    public class GroupMemberSpecialTitleChangedHandler : Handler, IMiraiMessageHandler<IMiraiSession, IGroupMemberSpecialTitleChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupMemberSpecialTitleChangedEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.ea.GetEvent<GroupMemberSpecialTitleChangedEvent>().Publish(new KMSakuraMessage<IGroupMemberSpecialTitleChangedEventArgs>(session.QQNumber, message));
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"群{message.Member.Group.Name}({message.Member.Group.Id})" +
                $"内成员{message.Member.Name}({message.Member.Id})的专属头衔由{message.Origin}修改为{message.Current}");

            return Task.FromResult(false); 
        }
    }

    /// <summary>
    /// 群全员禁言设置被修改（理解为开启或关闭了全员禁言）
    /// </summary>
    public class GroupMuteAllChangedHandler : Handler, IMiraiMessageHandler<IMiraiSession, IGroupMuteAllChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupMuteAllChangedEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.ea.GetEvent<GroupMuteAllChangedEvent>().Publish(new KMSakuraMessage<IGroupMuteAllChangedEventArgs>(session.QQNumber, message));
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"群{message.Group.Name}({message.Group.Id}){message.Operator.Permission}" +
                $"{message.Operator.Name}({message.Operator.Id})" + $"{(message.Current ? "开启" : "关闭")}了全体禁言");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// 群名称被改动
    /// </summary>
    public class GroupNameChangedHandler : Handler, IMiraiMessageHandler<IMiraiSession, IGroupNameChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupNameChangedEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.ea.GetEvent<GroupNameChangedEvent>().Publish(new KMSakuraMessage<IGroupNameChangedEventArgs>(session.QQNumber, message));
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"群{message.Group.Name}({message.Group.Id})" +
                $"成员{message.Operator.Name}({message.Operator.Id})将群名称由{message.Origin}修改为{message.Current}");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// 新群员入群事件
    /// </summary>
    public class GroupApplyHandler : Handler, IMiraiMessageHandler<IMiraiSession, IGroupApplyEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupApplyEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.ea.GetEvent<GroupApplyEvent>().Publish(new KMSakuraMessage<IGroupApplyEventArgs>(session.QQNumber, message));
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"事件ID{message.EventId}/{message.NickName}({message.FromQQ})" +
                $"申请加入群{message.FromGroupName}({message.FromGroup})" + $"入群消息为{message.Message}");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// 群成员的群荣誉被改变
    /// </summary>
    public class GroupMemberHonorHandler : Handler, IMiraiMessageHandler<IMiraiSession, IGroupMemberHonorChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupMemberHonorChangedEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.ea.GetEvent<GroupMemberHonorEvent>().Publish(new KMSakuraMessage<IGroupMemberHonorChangedEventArgs>(session.QQNumber, message));
            Common.RunLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"群{message.Member.Group.Name}({message.Member.Group.Id})-" +
                $"成员{message.Member.Name}({message.Member.Id}){(message.State == Mirai.CSharp.Models.GroupHonorState.Achieve ? "获得" : "失去")}荣誉{message.Honor}");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// 群成员被禁言
    /// </summary>
    public class GroupMemberMutedHandler : Handler, IMiraiMessageHandler<IMiraiSession, IGroupMemberMutedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupMemberMutedEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.ea.GetEvent<GroupMemberMutedEvent>().Publish(new KMSakuraMessage<IGroupMemberMutedEventArgs>(session.QQNumber, message));
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"群{message.Member.Group.Name}({message.Member.Group.Id})" +
                $"成员{message.Member.Name}({message.Member.Id})被{message.Operator.Permission}{message.Operator.Name}({message.Operator.Id})" +
                $"禁言{message.Duration.TotalMinutes}分钟");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// 群成员被解禁
    /// </summary>
    public class GroupMemberUnmutedHandler : Handler, IMiraiMessageHandler<IMiraiSession, IGroupMemberUnmutedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupMemberUnmutedEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.ea.GetEvent<GroupMemberUnmutedEvent>().Publish(new KMSakuraMessage<IGroupMemberUnmutedEventArgs>(session.QQNumber, message));
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"群{message.Member.Group.Name}({message.Member.Group.Id})" +
                $"成员{message.Member.Name}({message.Member.Id})被{message.Operator.Permission}{message.Operator.Name}({message.Operator.Id})解除禁言");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// 群消息到达
    /// </summary>
    public class GroupMessageHandler : Handler, IMiraiMessageHandler<IMiraiSession, IGroupMessageEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupMessageEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.ea.GetEvent<GroupMessageEvent>().Publish(new KMSakuraMessage<IGroupMessageEventArgs>(session.QQNumber, message));
            ISourceMessage source = message.Chain[0] as ISourceMessage;
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"群消息到达：消息ID:({source.Id}) 时间戳:({source.Time}) [{message.Sender.Group.Name}({message.Sender.Group.Id})]" +
                $"-{message.Sender.Name}({message.Sender.Id}) -> {string.Join("", (IEnumerable<IChatMessage>)message.Chain)}");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// 群消息被撤回
    /// </summary>
    public class GroupMessageRevokedHandler : Handler, IMiraiMessageHandler<IMiraiSession, IGroupMessageRevokedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupMessageRevokedEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.ea.GetEvent<GroupMessageRevokedEvent>().Publish(new KMSakuraMessage<IGroupMessageRevokedEventArgs>(session.QQNumber, message));
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"群消息被撤回：消息ID:{message.MessageId} 群{message.Group.Name}({message.Group.Id})" +
                $"一条消息被{message.Operator.Name}({message.Operator.Id})撤回");

            return Task.FromResult(false);
        }
    }
}
