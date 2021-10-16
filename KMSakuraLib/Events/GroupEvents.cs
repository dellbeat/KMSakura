using Mirai.CSharp.Models.EventArgs;
using Prism.Events;

namespace KMSakuraLib.Events
{
    /// <summary>
    /// 匿名聊天设置被改变
    /// </summary>
    public class GroupAnonymousChatChangedEvent:PubSubEvent<IGroupAnonymousChatChangedEventArgs>
    {
        
    }

    /// <summary>
    /// 坦白说设置被改变
    /// </summary>
    public class GroupConfessTalkChangedEvent:PubSubEvent<IGroupConfessTalkChangedEventArgs>
    {
        
    }

    /// <summary>
    /// 入群公告被改变
    /// </summary>
    public class GroupEntranceAnnouncementChangedEvent:PubSubEvent<IGroupEntranceAnnouncementChangedEventArgs>
    {
        
    }

    /// <summary>
    /// 成员群名片被修改
    /// </summary>
    public class GroupMemberCardChangedEvent:PubSubEvent<IGroupMemberCardChangedEventArgs>
    {
        
    }

    /// <summary>
    /// 群成员邀请设置被更改
    /// </summary>
    public class GroupMemberInviteChangedEvent:PubSubEvent<IGroupMemberInviteChangedEventArgs>
    {
        
    }

    /// <summary>
    /// 新人入群消息
    /// </summary>
    public class GroupMemberJoinedEvent:PubSubEvent<IGroupMemberJoinedEventArgs>
    {
        
    }

    /// <summary>
    /// 成员被踢出群
    /// </summary>
    public class GroupMemberKickedEvent:PubSubEvent<IGroupMemberKickedEventArgs>
    {
        
    }

    /// <summary>
    /// 群成员权限呗改变
    /// </summary>
    public class GroupMemberPermissionChangedEvent:PubSubEvent<IGroupMemberPermissionChangedEventArgs>
    {
        
    }

    /// <summary>
    /// 群成员主动离群
    /// </summary>
    public class GroupMemberPositiveLeaveEvent:PubSubEvent<IGroupMemberPositiveLeaveEventArgs>
    {
        
    }

    /// <summary>
    /// 群成员的专属头衔被改变
    /// </summary>
    public class GroupMemberSpecialTitleChangedEvent:PubSubEvent<IGroupMemberSpecialTitleChangedEventArgs>
    {
        
    }

    /// <summary>
    /// 群全员禁言设置被修改（理解为开启或关闭了全员禁言）
    /// </summary>
    public class GroupMuteAllChangedEvent:PubSubEvent<IGroupMuteAllChangedEventArgs>
    {
        
    }

    /// <summary>
    /// 群员昵称被改动
    /// </summary>
    public class GroupNameChangedEvent:PubSubEvent<IGroupNameChangedEventArgs>
    {
        
    }

    /// <summary>
    /// 新群员入群事件
    /// </summary>
    public class GroupApplyEvent:PubSubEvent<IGroupApplyEventArgs>
    {
        
    }

    /// <summary>
    /// 群成员的群荣誉被改变
    /// </summary>
    public class GroupMemberHonorEvent:PubSubEvent<IGroupMemberHonorChangedEventArgs>
    {
        
    }

    /// <summary>
    /// 群成员被禁言
    /// </summary>
    public class GroupMemberMutedEvent:PubSubEvent<IGroupMemberMutedEventArgs>
    {
        
    }

    /// <summary>
    /// 群成员被解禁
    /// </summary>
    public class GroupMemberUnmutedEvent:PubSubEvent<IGroupMemberUnmutedEventArgs>
    {
        
    }

    /// <summary>
    /// 群消息到达
    /// </summary>
    public class GroupMessageEvent:PubSubEvent<IGroupMessageEventArgs>
    {
        
    }

    /// <summary>
    /// 群消息被撤回
    /// </summary>
    public class GroupMessageRevokedEvent:PubSubEvent<IGroupMessageRevokedEventArgs>
    {
        
    }
}
