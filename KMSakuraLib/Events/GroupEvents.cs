using KMSakuraLib.Models;
using Mirai.CSharp.Models.EventArgs;
using Prism.Events;

namespace KMSakuraLib.Events
{
    /// <summary>
    /// 匿名聊天设置被改变
    /// </summary>
    public class GroupAnonymousChatChangedEvent : PubSubEvent<IKMSakuraMessage<IGroupAnonymousChatChangedEventArgs>>
    {

    }

    /// <summary>
    /// 坦白说设置被改变
    /// </summary>
    public class GroupConfessTalkChangedEvent : PubSubEvent<IKMSakuraMessage<IGroupConfessTalkChangedEventArgs>>
    {

    }

    /// <summary>
    /// 入群公告被改变
    /// </summary>
    public class GroupEntranceAnnouncementChangedEvent : PubSubEvent<IKMSakuraMessage<IGroupEntranceAnnouncementChangedEventArgs>>
    {

    }

    /// <summary>
    /// 成员群名片被修改
    /// </summary>
    public class GroupMemberCardChangedEvent : PubSubEvent<IKMSakuraMessage<IGroupMemberCardChangedEventArgs>>
    {

    }

    /// <summary>
    /// 群成员邀请设置被更改
    /// </summary>
    public class GroupMemberInviteChangedEvent : PubSubEvent<IKMSakuraMessage<IGroupMemberInviteChangedEventArgs>>
    {

    }

    /// <summary>
    /// 新人入群消息
    /// </summary>
    public class GroupMemberJoinedEvent : PubSubEvent<IKMSakuraMessage<IGroupMemberJoinedEventArgs>>
    {

    }

    /// <summary>
    /// 成员被踢出群
    /// </summary>
    public class GroupMemberKickedEvent : PubSubEvent<IKMSakuraMessage<IGroupMemberKickedEventArgs>>
    {

    }

    /// <summary>
    /// 群成员权限呗改变
    /// </summary>
    public class GroupMemberPermissionChangedEvent : PubSubEvent<IKMSakuraMessage<IGroupMemberPermissionChangedEventArgs>>
    {

    }

    /// <summary>
    /// 群成员主动离群
    /// </summary>
    public class GroupMemberPositiveLeaveEvent : PubSubEvent<IKMSakuraMessage<IGroupMemberPositiveLeaveEventArgs>>
    {

    }

    /// <summary>
    /// 群成员的专属头衔被改变
    /// </summary>
    public class GroupMemberSpecialTitleChangedEvent : PubSubEvent<IKMSakuraMessage<IGroupMemberSpecialTitleChangedEventArgs>>
    {

    }

    /// <summary>
    /// 群全员禁言设置被修改（理解为开启或关闭了全员禁言）
    /// </summary>
    public class GroupMuteAllChangedEvent : PubSubEvent<IKMSakuraMessage<IGroupMuteAllChangedEventArgs>>
    {

    }

    /// <summary>
    /// 群员昵称被改动
    /// </summary>
    public class GroupNameChangedEvent : PubSubEvent<IKMSakuraMessage<IGroupNameChangedEventArgs>>
    {

    }

    /// <summary>
    /// 新群员入群事件
    /// </summary>
    public class GroupApplyEvent : PubSubEvent<IKMSakuraMessage<IGroupApplyEventArgs>>
    {

    }

    /// <summary>
    /// 群成员的群荣誉被改变
    /// </summary>
    public class GroupMemberHonorEvent : PubSubEvent<IKMSakuraMessage<IGroupMemberHonorChangedEventArgs>>
    {

    }

    /// <summary>
    /// 群成员被禁言
    /// </summary>
    public class GroupMemberMutedEvent : PubSubEvent<IKMSakuraMessage<IGroupMemberMutedEventArgs>>
    {

    }

    /// <summary>
    /// 群成员被解禁
    /// </summary>
    public class GroupMemberUnmutedEvent : PubSubEvent<IKMSakuraMessage<IGroupMemberUnmutedEventArgs>>
    {

    }

    /// <summary>
    /// 群消息到达
    /// </summary>
    public class GroupMessageEvent : PubSubEvent<IKMSakuraMessage<IGroupMessageEventArgs>>
    {

    }

    /// <summary>
    /// 群消息被撤回
    /// </summary>
    public class GroupMessageRevokedEvent : PubSubEvent<IKMSakuraMessage<IGroupMessageRevokedEventArgs>>
    {

    }
}
