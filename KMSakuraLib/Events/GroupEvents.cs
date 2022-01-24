using KMSakuraLib.Models;
using Mirai.CSharp.Models.EventArgs;
using Prism.Events;

namespace KMSakuraLib.Events
{
    /// <summary>
    /// 匿名聊天设置被改变
    /// </summary>
    public class GroupAnonymousChatChangedEvent : PubSubEvent<(long?, IGroupAnonymousChatChangedEventArgs)>
    {

    }

    /// <summary>
    /// 坦白说设置被改变
    /// </summary>
    public class GroupConfessTalkChangedEvent : PubSubEvent<(long?, IGroupConfessTalkChangedEventArgs)>
    {

    }

    /// <summary>
    /// 入群公告被改变
    /// </summary>
    public class GroupEntranceAnnouncementChangedEvent : PubSubEvent<(long?, IGroupEntranceAnnouncementChangedEventArgs)>
    {

    }

    /// <summary>
    /// 成员群名片被修改
    /// </summary>
    public class GroupMemberCardChangedEvent : PubSubEvent<(long?, IGroupMemberCardChangedEventArgs)>
    {

    }

    /// <summary>
    /// 群成员邀请设置被更改
    /// </summary>
    public class GroupMemberInviteChangedEvent : PubSubEvent<(long?, IGroupMemberInviteChangedEventArgs)>
    {

    }

    /// <summary>
    /// 新人入群消息
    /// </summary>
    public class GroupMemberJoinedEvent : PubSubEvent<(long?, IGroupMemberJoinedEventArgs)>
    {

    }

    /// <summary>
    /// 成员被踢出群
    /// </summary>
    public class GroupMemberKickedEvent : PubSubEvent<(long?, IGroupMemberKickedEventArgs)>
    {

    }

    /// <summary>
    /// 群成员权限被改变
    /// </summary>
    public class GroupMemberPermissionChangedEvent : PubSubEvent<(long?, IGroupMemberPermissionChangedEventArgs)>
    {

    }

    /// <summary>
    /// 群成员主动离群
    /// </summary>
    public class GroupMemberPositiveLeaveEvent : PubSubEvent<(long?, IGroupMemberPositiveLeaveEventArgs)>
    {

    }

    /// <summary>
    /// 群成员的专属头衔被改变
    /// </summary>
    public class GroupMemberSpecialTitleChangedEvent : PubSubEvent<(long?, IGroupMemberSpecialTitleChangedEventArgs)>
    {

    }

    /// <summary>
    /// 群全员禁言设置被修改（理解为开启或关闭了全员禁言）
    /// </summary>
    public class GroupMuteAllChangedEvent : PubSubEvent<(long?, IGroupMuteAllChangedEventArgs)>
    {

    }

    /// <summary>
    /// 群名被改动
    /// </summary>
    public class GroupNameChangedEvent : PubSubEvent<(long?, IGroupNameChangedEventArgs)>
    {

    }

    /// <summary>
    /// 新群员入群申请消息到达事件
    /// </summary>
    public class GroupApplyEvent : PubSubEvent<(long?, IGroupApplyEventArgs)>
    {

    }

    /// <summary>
    /// 群成员的群荣誉被改变
    /// </summary>
    public class GroupMemberHonorEvent : PubSubEvent<(long?, IGroupMemberHonorChangedEventArgs)>
    {

    }

    /// <summary>
    /// 群成员被禁言
    /// </summary>
    public class GroupMemberMutedEvent : PubSubEvent<(long?, IGroupMemberMutedEventArgs)>
    {

    }

    /// <summary>
    /// 群成员被解禁
    /// </summary>
    public class GroupMemberUnmutedEvent : PubSubEvent<(long?, IGroupMemberUnmutedEventArgs)>
    {

    }

    /// <summary>
    /// 群消息到达
    /// </summary>
    public class GroupMessageEvent : PubSubEvent<(long?, IGroupMessageEventArgs)>
    {

    }

    /// <summary>
    /// 群消息被撤回
    /// </summary>
    public class GroupMessageRevokedEvent : PubSubEvent<(long?, IGroupMessageRevokedEventArgs)>
    {

    }
}
