﻿using KMSakuraLib.Ability;
using KMSakuraLib.Events;
using KMSakuraLib.Models;
using KMSakuraLib.Session;
using Mirai.CSharp.Handlers;
using Mirai.CSharp.Models.ChatMessages;
using Mirai.CSharp.Models.EventArgs;
using Mirai.CSharp.Session;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KMSakuraLib.BotHandlers
{
    /// <summary>
    /// 其他设备消息
    /// </summary>
    public class OtherClientMessageHandler : Handler, IMiraiMessageHandler<IMiraiSession, IOtherClientMessageEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IOtherClientMessageEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.ea.GetEvent<OtherClientMessageEvent>().Publish(new KMSakuraMessage<IOtherClientMessageEventArgs>(session.QQNumber, message));
            ISourceMessage source = message.Chain[0] as ISourceMessage;
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"其他客户端消息：消息ID:({source.Id}) 时间戳:({source.Time})" +
                $"{message.Sender.Name}(设备类型:{message.Sender.Platform})" +
                $"-{message.Sender.Name}({message.Sender.Id}) -> {string.Join("", (IEnumerable<IChatMessage>)message.Chain)}");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// 陌生人消息
    /// </summary>
    public class StrangerMessageHandler : Handler, IMiraiMessageHandler<IMiraiSession, IStrangerMessageEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IStrangerMessageEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.ea.GetEvent<StrangerMessageEvent>().Publish(new KMSakuraMessage<IStrangerMessageEventArgs>(session.QQNumber, message));
            ISourceMessage source = message.Chain[0] as ISourceMessage;
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"陌生人消息：消息ID:({source.Id}) 时间戳:({source.Time})" +
                $"-{message.Sender.Name}({message.Sender.Id}) -> {string.Join("", (IEnumerable<IChatMessage>)message.Chain)}");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// 临时会话消息
    /// </summary>
    public class TempMessageHandler : Handler, IMiraiMessageHandler<IMiraiSession, ITempMessageEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, ITempMessageEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.ea.GetEvent<TempMessageEvent>().Publish(new KMSakuraMessage<ITempMessageEventArgs>(session.QQNumber, message));
            ISourceMessage source = message.Chain[0] as ISourceMessage;
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"临时会话消息：消息ID:({source.Id}) 时间戳:({source.Time})" +
                $"-{message.Sender.Name}({message.Sender.Id}) -> {string.Join("", (IEnumerable<IChatMessage>)message.Chain)}");

            return Task.FromResult(false);
        }
    }
}
