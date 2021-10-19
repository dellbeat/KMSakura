using Mirai.CSharp.Handlers;
using Mirai.CSharp.Models.EventArgs;
using Mirai.CSharp.Session;
using System;
using System.Threading.Tasks;

namespace KMSakuraLib.BotHandlers
{
    /// <summary>
    /// 好友输入状态改变
    /// </summary>
    public class FriendInputStatusChangedHandlers : Handler, IMiraiMessageHandler<IMiraiSession, IFriendInputStatusChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IFriendInputStatusChangedEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 好友消息到达
    /// </summary>
    public class FriendMessageHandlers : Handler, IMiraiMessageHandler<IMiraiSession, IFriendMessageEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IFriendMessageEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 好友消息被撤回
    /// </summary>
    public class FriendMessageRevokedHandlers : Handler, IMiraiMessageHandler<IMiraiSession, IFriendMessageRevokedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IFriendMessageRevokedEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 好友昵称改变
    /// </summary>
    public class FriendNickChangedHandlers : Handler, IMiraiMessageHandler<IMiraiSession, IFriendNickChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IFriendNickChangedEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 新好友申请
    /// </summary>
    public class NewFriendApplyHandlers : Handler, IMiraiMessageHandler<IMiraiSession, INewFriendApplyEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, INewFriendApplyEventArgs message)
        {
            throw new NotImplementedException();
        }
    }
}
