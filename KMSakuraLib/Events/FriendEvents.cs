using KMSakuraLib.Models;
using Mirai.CSharp.Models.EventArgs;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMSakuraLib.Events
{
    /// <summary>
    /// 好友输入状态改变
    /// </summary>
    public class FriendInputStatusChangedEvent : PubSubEvent<IKMSakuraMessage<IFriendInputStatusChangedEventArgs>>
    {

    }

    /// <summary>
    /// 好友消息到达
    /// </summary>
    public class FriendMessageEvent : PubSubEvent<IKMSakuraMessage<IFriendMessageEventArgs>>
    {

    }

    /// <summary>
    /// 好友消息被撤回
    /// </summary>
    public class FriendMessageRevokedEvent : PubSubEvent<IKMSakuraMessage<IFriendMessageRevokedEventArgs>>
    {

    }

    /// <summary>
    /// 好友昵称改变
    /// </summary>
    public class FriendNickChangedEvent : PubSubEvent<IKMSakuraMessage<IFriendNickChangedEventArgs>>
    {

    }

    /// <summary>
    /// 新好友申请
    /// </summary>
    public class NewFriendApplyEvent : PubSubEvent<IKMSakuraMessage<INewFriendApplyEventArgs>>
    {

    }
}
