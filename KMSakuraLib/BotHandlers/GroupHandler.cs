using Mirai.CSharp.Handlers;
using Mirai.CSharp.Models.EventArgs;
using Mirai.CSharp.Session;
using System;
using System.Threading.Tasks;

namespace KMSakuraLib.BotHandlers
{
    /// <summary>
    /// 匿名聊天设置被改变
    /// </summary>
    public class GroupAnonymousChatChangedHandlers : IMiraiMessageHandler<IMiraiSession, IGroupAnonymousChatChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupAnonymousChatChangedEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 坦白说设置被改变
    /// </summary>
    public class GroupConfessTalkChangedHandlers : IMiraiMessageHandler<IMiraiSession, IGroupConfessTalkChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupConfessTalkChangedEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 入群公告被改变
    /// </summary>
    public class GroupEntranceAnnouncementChangedHandlers : IMiraiMessageHandler<IMiraiSession, IGroupEntranceAnnouncementChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupEntranceAnnouncementChangedEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 成员群名片被修改
    /// </summary>
    public class GroupMemberCardChangedHandlers : IMiraiMessageHandler<IMiraiSession, IGroupMemberCardChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupMemberCardChangedEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 群成员邀请设置被更改
    /// </summary>
    public class GroupMemberInviteChangedHandlers : IMiraiMessageHandler<IMiraiSession, IGroupMemberInviteChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupMemberInviteChangedEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 新人入群消息
    /// </summary>
    public class GroupMemberJoinedHandlers : IMiraiMessageHandler<IMiraiSession, IGroupMemberJoinedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupMemberJoinedEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 成员被踢出群
    /// </summary>
    public class GroupMemberKickedHandlers : IMiraiMessageHandler<IMiraiSession, IGroupMemberKickedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupMemberKickedEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 群成员权限呗改变
    /// </summary>
    public class GroupMemberPermissionChangedHandlers : IMiraiMessageHandler<IMiraiSession, IGroupMemberPermissionChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupMemberPermissionChangedEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 群成员主动离群
    /// </summary>
    public class GroupMemberPositiveLeaveHandlers : IMiraiMessageHandler<IMiraiSession, IGroupMemberPositiveLeaveEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupMemberPositiveLeaveEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 群成员的专属头衔被改变
    /// </summary>
    public class GroupMemberSpecialTitleChangedHandlers : IMiraiMessageHandler<IMiraiSession, IGroupMemberSpecialTitleChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupMemberSpecialTitleChangedEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 群全员禁言设置被修改（理解为开启或关闭了全员禁言）
    /// </summary>
    public class GroupMuteAllChangedHandlers : IMiraiMessageHandler<IMiraiSession, IGroupMuteAllChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupMuteAllChangedEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 群员昵称被改动
    /// </summary>
    public class GroupNameChangedHandlers : IMiraiMessageHandler<IMiraiSession, IGroupNameChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupNameChangedEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 新群员入群事件
    /// </summary>
    public class GroupApplyHandlers : IMiraiMessageHandler<IMiraiSession, IGroupApplyEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupApplyEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 群成员的群荣誉被改变
    /// </summary>
    public class GroupMemberHonorHandlers : IMiraiMessageHandler<IMiraiSession, IGroupMemberHonorChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupMemberHonorChangedEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 群成员被禁言
    /// </summary>
    public class GroupMemberMutedHandlers : IMiraiMessageHandler<IMiraiSession, IGroupMemberMutedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupMemberMutedEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 群成员被解禁
    /// </summary>
    public class GroupMemberUnmutedHandlers : IMiraiMessageHandler<IMiraiSession, IGroupMemberUnmutedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupMemberUnmutedEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 群消息到达
    /// </summary>
    public class GroupMessageHandlers : IMiraiMessageHandler<IMiraiSession, IGroupMessageEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupMessageEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 群消息被撤回
    /// </summary>
    public class GroupMessageRevokedHandlers : IMiraiMessageHandler<IMiraiSession, IGroupMessageRevokedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IGroupMessageRevokedEventArgs message)
        {
            throw new NotImplementedException();
        }
    }
}
