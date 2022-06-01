using Mirai.CSharp.Models.EventArgs;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMSakuraLib.Components.Enum
{
    /// <summary>
    /// 事件类型枚举
    /// </summary>
    public enum MessageTypeEnum
    {
        /// <summary>
        /// Bot意外断连
        /// </summary>
        BotDropped,
        /// <summary>
        /// Bot群内权限被改变
        /// </summary>
        BotGroupPermissionChanged,
        /// <summary>
        /// Bot被邀请入群
        /// </summary>
        BotInvitedJoinGroup,
        /// <summary>
        /// Bot入群消息
        /// </summary>
        BotJoinedGroup,
        /// <summary>
        /// BOT被迫下线
        /// </summary>
        BotKickedOffline,
        /// <summary>
        /// BOT被移出群聊
        /// </summary>
        BotKickedOut,
        /// <summary>
        /// Bot被禁言
        /// </summary>
        BotMuted,
        /// <summary>
        /// Bot登录成功
        /// </summary>
        BotOnline,
        /// <summary>
        /// Bot主动离开群聊
        /// </summary>
        BotPositiveLeave,
        /// <summary>
        /// Bot主动离线
        /// </summary>
        BotPositiveOffline,
        /// <summary>
        /// Bot重新登录
        /// </summary>
        BotRelogin,
        /// <summary>
        /// Bot被解禁
        /// </summary>
        BotUnmuted,
        /// <summary>
        /// 好友输入状态改变
        /// </summary>
        FriendInputStatusChanged,
        /// <summary>
        /// 好友消息到达
        /// </summary>
        FriendMessage,
        /// <summary>
        /// 好友消息被撤回
        /// </summary>
        FriendMessageRevoked,
        /// <summary>
        /// 好友昵称改变
        /// </summary>
        FriendNickChanged,
        /// <summary>
        /// 新好友申请
        /// </summary>
        NewFriendApply,
        /// <summary>
        /// 匿名聊天设置被改变
        /// </summary>
        GroupAnonymousChatChanged,
        /// <summary>
        /// 坦白说设置被改变
        /// </summary>
        GroupConfessTalkChanged,
        /// <summary>
        /// 入群公告被改变
        /// </summary>
        GroupEntranceAnnouncementChanged,
        /// <summary>
        /// 成员群名片被修改
        /// </summary>
        GroupMemberCardChanged,
        /// <summary>
        /// 群成员邀请设置被更改
        /// </summary>
        GroupMemberInviteChanged,
        /// <summary>
        /// 新人入群消息
        /// </summary>
        GroupMemberJoined,
        /// <summary>
        /// 成员被踢出群
        /// </summary>
        GroupMemberKicked,
        /// <summary>
        /// 群成员权限被改变
        /// </summary>
        GroupMemberPermissionChanged,
        /// <summary>
        /// 群成员主动离群
        /// </summary>
        GroupMemberPositiveLeave,
        /// <summary>
        /// 群成员的专属头衔被改变
        /// </summary>
        GroupMemberSpecialTitleChanged,
        /// <summary>
        /// 群全员禁言设置被修改（理解为开启或关闭了全员禁言）
        /// </summary>
        GroupMuteAllChanged,
        /// <summary>
        /// 群名被改动
        /// </summary>
        GroupNameChanged,
        /// <summary>
        /// 新群员入群申请消息到达事件
        /// </summary>
        GroupApply,
        /// <summary>
        /// 群成员的群荣誉被改变
        /// </summary>
        GroupMemberHonor,
        /// <summary>
        /// 群成员被禁言
        /// </summary>
        GroupMemberMuted,
        /// <summary>
        /// 群成员被解禁
        /// </summary>
        GroupMemberUnmuted,
        /// <summary>
        /// 群消息到达
        /// </summary>
        GroupMessage,
        /// <summary>
        /// 群消息被撤回
        /// </summary>
        GroupMessageRevoked,
        /// <summary>
        /// 其他客户端消息事件订阅
        /// </summary>
        OtherClientMessage,
        /// <summary>
        /// 陌生人消息事件订阅
        /// </summary>
        StrangerMessage,
        /// <summary>
        /// 临时会话消息事件订阅
        /// </summary>
        TempMessage
    }

    /// <summary>
    /// 消息参数类型
    /// </summary>
    public static class MessageArgs
    {
        public static Type[] ArgsArray = { typeof(IBotDroppedEventArgs),typeof(IBotGroupPermissionChangedEventArgs),typeof(IBotInvitedJoinGroupEventArgs),typeof(IBotJoinedGroupEventArgs),typeof(IBotKickedOfflineEventArgs),
            typeof(IBotKickedOutEventArgs),typeof(IBotMutedEventArgs),typeof(IBotOnlineEventArgs),typeof(IBotPositiveLeaveGroupEventArgs),typeof(IBotPositiveOfflineEventArgs),
            typeof(IBotReloginEventArgs),typeof(IBotUnmutedEventArgs),typeof(IFriendInputStatusChangedEventArgs),typeof(IFriendMessageEventArgs),typeof(IFriendMessageRevokedEventArgs),
            typeof(IFriendNickChangedEventArgs),typeof(INewFriendApplyEventArgs),typeof(IGroupAnonymousChatChangedEventArgs),typeof(IGroupConfessTalkChangedEventArgs),typeof(IGroupEntranceAnnouncementChangedEventArgs),
            typeof(IGroupMemberCardChangedEventArgs),typeof(IGroupMemberInviteChangedEventArgs),typeof(IGroupMemberJoinedEventArgs),typeof(IGroupMemberKickedEventArgs),typeof(IGroupMemberPermissionChangedEventArgs),
            typeof(IGroupMemberPositiveLeaveEventArgs),typeof(IGroupMemberSpecialTitleChangedEventArgs),typeof(IGroupMuteAllChangedEventArgs),typeof(IGroupNameChangedEventArgs),typeof(IGroupApplyEventArgs),
            typeof(IGroupMemberHonorChangedEventArgs),typeof(IGroupMemberMutedEventArgs),typeof(IGroupMemberUnmutedEventArgs),typeof(IGroupMessageEventArgs),typeof(IGroupMessageRevokedEventArgs),
            typeof(IOtherClientMessageEventArgs),typeof(IStrangerMessageEventArgs),typeof(ITempMessageEventArgs)};
    }
}
