using KMSakuraLib.Models;
using Mirai.CSharp.Models.EventArgs;
using Prism.Events;

namespace KMSakuraLib.Event
{
    /// <summary>
    /// Bot意外断连
    /// </summary>
    public class BotDroppedEvent : PubSubEvent<IKMSakuraMessage<IBotDroppedEventArgs>>
    {

    }

    /// <summary>
    /// Bot群内权限被改变
    /// </summary>
    public class BotGroupPermissionChangedEvent : PubSubEvent<IKMSakuraMessage<IBotGroupPermissionChangedEventArgs>>
    {

    }

    /// <summary>
    /// Bot被邀请入群
    /// </summary>
    public class BotInvitedJoinGroupEvent : PubSubEvent<IKMSakuraMessage<IBotInvitedJoinGroupEventArgs>>
    {

    }

    /// <summary>
    /// Bot入群消息
    /// </summary>
    public class BotJoinedGroupEvent : PubSubEvent<IKMSakuraMessage<IBotJoinedGroupEventArgs>>
    {

    }

    /// <summary>
    /// BOT被迫掉线
    /// </summary>
    public class BotKickedOfflineEvent : PubSubEvent<IKMSakuraMessage<IBotKickedOfflineEventArgs>>
    {

    }

    /// <summary>
    /// BOT被移出群聊
    /// </summary>
    public class BotKickedOutEvent : PubSubEvent<IKMSakuraMessage<IBotKickedOutEventArgs>>
    {

    }

    /// <summary>
    /// Bot被禁言
    /// </summary>
    public class BotMutedEvent : PubSubEvent<IKMSakuraMessage<IBotMutedEventArgs>>
    {

    }

    /// <summary>
    /// Bot登录成功
    /// </summary>
    public class BotOnlineEvent : PubSubEvent<IKMSakuraMessage<IBotOnlineEventArgs>>
    {

    }

    /// <summary>
    /// Bot主动离开群聊
    /// </summary>
    [System.Obsolete("该事件目前无法被触发 等待进一步确认")]
    public class BotPositiveLeaveGroupEvent : PubSubEvent<IKMSakuraMessage<IBotPositiveLeaveGroupEventArgs>>
    {

    }

    /// <summary>
    /// Bot主动离线(有这个功能吗?)
    /// </summary>
    public class BotPositiveOfflineEvent : PubSubEvent<IKMSakuraMessage<IBotPositiveOfflineEventArgs>>
    {

    }

    /// <summary>
    /// Bot重新登录
    /// </summary>
    public class BotReloginEvent : PubSubEvent<IKMSakuraMessage<IBotReloginEventArgs>>
    {

    }

    /// <summary>
    /// Bot被解禁
    /// </summary>
    public class BotUnmutedEvent : PubSubEvent<IKMSakuraMessage<IBotUnmutedEventArgs>>
    {

    }
}
