using Mirai.CSharp.Models.EventArgs;
using Prism.Events;

namespace KMSakuraLib.Event
{
    /// <summary>
    /// Bot意外断连
    /// </summary>
    public class BotDroppedEvent : PubSubEvent<IBotDroppedEventArgs>
    {
        
    }

    /// <summary>
    /// Bot群内权限呗改变
    /// </summary>
    public class BotGroupPermissionChangedEvent : PubSubEvent<IBotGroupPermissionChangedEventArgs>
    {
        
    }

    /// <summary>
    /// Bot被邀请入群
    /// </summary>
    public class BotInvitedJoinGroupEvent : PubSubEvent<IBotInvitedJoinGroupEventArgs>
    {
        
    }

    /// <summary>
    /// Bot入群消息
    /// </summary>
    public class BotJoinedGroupEvent : PubSubEvent<IBotJoinedGroupEventArgs>
    {
        
    }

    /// <summary>
    /// BOT被迫掉线
    /// </summary>
    public class BotKickedOfflineEvent : PubSubEvent<IBotKickedOfflineEventArgs>
    {
        
    }

    /// <summary>
    /// BOT被移出群聊
    /// </summary>
    public class BotKickedOutEvent : PubSubEvent<IBotKickedOutEventArgs>
    {
        
    }

    /// <summary>
    /// Bot被禁言
    /// </summary>
    public class BotMutedEvent : PubSubEvent<IBotMutedEventArgs>
    {
        
    }

    /// <summary>
    /// Bot登录成功
    /// </summary>
    public class BotOnlineEvent : PubSubEvent<IBotOnlineEventArgs>
    {
        
    }

    /// <summary>
    /// Bot主动离开群聊
    /// </summary>
    public class BotPositiveLeaveGroupEvent : PubSubEvent<IBotPositiveLeaveGroupEventArgs>
    {
        
    }

    /// <summary>
    /// Bot主动离线(有这个功能吗?)
    /// </summary>
    public class BotPositiveOfflineEvent : PubSubEvent<IBotPositiveOfflineEventArgs>
    {
        
    }

    /// <summary>
    /// Bot重新登录
    /// </summary>
    public class BotReloginEvent : PubSubEvent<IBotReloginEventArgs>
    {
        
    }

    /// <summary>
    /// Bot被解禁
    /// </summary>
    public class BotUnmutedEvent : PubSubEvent<IBotUnmutedEventArgs>
    {
        
    }
}
