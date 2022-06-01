using KMSakuraLib.Models;
using Mirai.CSharp.Models.EventArgs;
using Prism.Events;

namespace KMSakuraLib.Event
{
    /// <summary>
    /// Bot意外断连
    /// </summary>
    public class BotDroppedEvent : PubSubEvent<(long?, IBotDroppedEventArgs)>
    {
        
    }

    /// <summary>
    /// Bot群内权限被改变
    /// </summary>
    public class BotGroupPermissionChangedEvent : PubSubEvent<(long?, IBotGroupPermissionChangedEventArgs)>
    {

    }

    /// <summary>
    /// Bot被邀请入群
    /// </summary>
    public class BotInvitedJoinGroupEvent : PubSubEvent<(long?, IBotInvitedJoinGroupEventArgs)>
    {

    }

    /// <summary>
    /// Bot入群消息
    /// </summary>
    public class BotJoinedGroupEvent : PubSubEvent<(long?, IBotJoinedGroupEventArgs)>
    {

    }

    /// <summary>
    /// BOT被迫下线
    /// </summary>
    public class BotKickedOfflineEvent : PubSubEvent<(long?, IBotKickedOfflineEventArgs)>
    {

    }

    /// <summary>
    /// BOT被移出群聊
    /// </summary>
    public class BotKickedOutEvent : PubSubEvent<(long?, IBotKickedOutEventArgs)>
    {

    }

    /// <summary>
    /// Bot被禁言
    /// </summary>
    public class BotMutedEvent : PubSubEvent<(long?, IBotMutedEventArgs)>
    {

    }

    /// <summary>
    /// Bot登录成功
    /// </summary>
    public class BotOnlineEvent : PubSubEvent<(long?, IBotOnlineEventArgs)>
    {

    }

    /// <summary>
    /// Bot主动离开群聊
    /// </summary>
    [System.Obsolete("该事件目前无法被触发 等待进一步确认")]
    public class BotPositiveLeaveGroupEvent : PubSubEvent<(long?, IBotPositiveLeaveGroupEventArgs)>
    {

    }

    /// <summary>
    /// Bot主动离线(已经有支持主动离线的命令了，后续会支持)
    /// </summary>
    public class BotPositiveOfflineEvent : PubSubEvent<(long?, IBotPositiveOfflineEventArgs)>
    {

    }

    /// <summary>
    /// Bot重新登录
    /// </summary>
    public class BotReloginEvent : PubSubEvent<(long?, IBotReloginEventArgs)>
    {

    }

    /// <summary>
    /// Bot被解禁
    /// </summary>
    public class BotUnmutedEvent : PubSubEvent<(long?, IBotUnmutedEventArgs)>
    {

    }
}
