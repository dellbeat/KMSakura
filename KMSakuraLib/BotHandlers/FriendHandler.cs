using KMSakuraLib.Ability;
using KMSakuraLib.Session;
using Mirai.CSharp.Handlers;
using Mirai.CSharp.Models.ChatMessages;
using Mirai.CSharp.Models.EventArgs;
using Mirai.CSharp.Session;
using System;
using System.Collections.Generic;
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
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            //有必要在输入结束的时候添加日志吗
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"好友{message.Friend.Name}({message.Friend.Id}){(message.Inputting ? "正在输入" : "输入结束")}");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// 好友消息到达
    /// </summary>
    public class FriendMessageHandlers : Handler, IMiraiMessageHandler<IMiraiSession, IFriendMessageEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IFriendMessageEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            ISourceMessage source = message.Chain[0] as ISourceMessage;
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"消息ID:({source.Id}) 时间戳:({source.Time}) " +
                $"{message.Sender.Name}({message.Sender.Id})-{string.Join("", (IEnumerable<IChatMessage>)message.Chain)}");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// 好友消息被撤回
    /// </summary>
    public class FriendMessageRevokedHandlers : Handler, IMiraiMessageHandler<IMiraiSession, IFriendMessageRevokedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IFriendMessageRevokedEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"好友{message.SenderId}撤回了一条发送于{message.SentTime}ID为{message.MessageId}的消息");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// 好友昵称改变
    /// </summary>
    public class FriendNickChangedHandlers : Handler, IMiraiMessageHandler<IMiraiSession, IFriendNickChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IFriendNickChangedEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"好友{message.Friend.Name}({message.Friend.Id})昵称从{message.Origin}更改为{message.Current}");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// 新好友申请
    /// </summary>
    public class NewFriendApplyHandlers : Handler, IMiraiMessageHandler<IMiraiSession, INewFriendApplyEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, INewFriendApplyEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"事件ID{message.EventId}/{message.NickName}({message.FromQQ})" +
                $"申请添加好友" + $"验证消息为{message.Message}");

            return Task.FromResult(false);
        }
    }
}
