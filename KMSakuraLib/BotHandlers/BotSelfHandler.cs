using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KMSakuraLib.Session;
using Mirai.CSharp.Handlers;
using Mirai.CSharp.Models.EventArgs;
using Mirai.CSharp.Session;
using KMSakuraLib.Ability;

namespace KMSakuraLib.BotHandlers
{
    public abstract class Handler
    {

    }

    /// <summary>
    /// Bot意外断连
    /// </summary>
    public class BotDroppedHandler : Handler, IMiraiMessageHandler<IMiraiSession, IBotDroppedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IBotDroppedEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"Bot{message.QQNumber}意外断连");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// Bot群内权限被改变
    /// </summary>
    public class BotGroupPermissionChangedHandler : Handler, IMiraiMessageHandler<IMiraiSession, IBotGroupPermissionChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IBotGroupPermissionChangedEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"BOT在{message.Group.Name}({message.Group.Id})的权限由{message.Origin}更改为{message.Current}");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// Bot被邀请入群
    /// </summary>
    public class BotInvitedJoinGroupHandler : Handler, IMiraiMessageHandler<IMiraiSession, IBotInvitedJoinGroupEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IBotInvitedJoinGroupEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"BOT被{message.NickName}({message.FromQQ})邀请至群{message.FromGroupName}({message.FromGroup})");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// Bot入群消息
    /// </summary>
    public class BotJoinedGroupHandler : Handler, IMiraiMessageHandler<IMiraiSession, IBotJoinedGroupEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IBotJoinedGroupEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"BOT加入了群{message.Group.Name}({message.Group.Id})" +
                $"{(message.Inviter == null ? "" : $",邀请者为{message.Inviter.Name}({message.Inviter.Id})")}");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// BOT被迫掉线
    /// </summary>
    public class BotKickedOfflineHandler : Handler, IMiraiMessageHandler<IMiraiSession, IBotKickedOfflineEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IBotKickedOfflineEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"BOT{message.QQNumber}被迫掉线");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// BOT被移出群聊
    /// </summary>
    public class BotKickedOutHandler : Handler, IMiraiMessageHandler<IMiraiSession, IBotKickedOutEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IBotKickedOutEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"BOT被{message.Operator.Name}({message.Operator.Id})" +
                $"移出群{message.Group.Name}({message.Group.Id})");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// Bot被禁言
    /// </summary>
    public class BotMutedHandler : Handler, IMiraiMessageHandler<IMiraiSession, IBotMutedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IBotMutedEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"BOT在群{message.Operator.Group.Name}({message.Operator.Group.Id})" +
                $"被{message.Operator.Name}({message.Operator.Id})禁言{message.Duration.TotalMinutes}分钟");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// Bot登录成功
    /// </summary>
    public class BotOnlineHandler : Handler, IMiraiMessageHandler<IMiraiSession, IBotOnlineEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IBotOnlineEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"BOT{message.QQNumber}登录成功");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// Bot主动离开群聊
    /// </summary>
    public class BotPositiveLeaveGroupHandler : Handler, IMiraiMessageHandler<IMiraiSession, IBotPositiveLeaveGroupEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IBotPositiveLeaveGroupEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"BOT主动退出群{message.Group.Name}({message.Group.Id})");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// Bot主动离线(有这个功能吗?)
    /// </summary>
    public class BotPositiveOfflineHandler : Handler, IMiraiMessageHandler<IMiraiSession, IBotPositiveOfflineEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IBotPositiveOfflineEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"BOT{message.QQNumber}主动离线");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// Bot重新登录
    /// </summary>
    public class BotReloginHandler : Handler, IMiraiMessageHandler<IMiraiSession, IBotReloginEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IBotReloginEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"BOT{message.QQNumber}重新登录");

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// Bot被解禁
    /// </summary>
    public class BotUnmutedHandler : Handler, IMiraiMessageHandler<IMiraiSession, IBotUnmutedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IBotUnmutedEventArgs message)
        {
            MiraiScopedHttpSession session = client as MiraiScopedHttpSession;
            Common.RecordLogger.InfoMsg(Common.BotLogName, session.QQNumber.ToString(), $"BOT在群{message.Operator.Group.Name}({message.Operator.Group.Id})" +
                $"被{message.Operator.Name}({message.Operator.Id})解除禁言");

            return Task.FromResult(false);
        }
    }
}
