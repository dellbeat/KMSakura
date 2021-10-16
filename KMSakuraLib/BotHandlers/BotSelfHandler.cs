﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mirai.CSharp.Handlers;
using Mirai.CSharp.Models.EventArgs;
using Mirai.CSharp.Session;

namespace KMSakuraLib.BotHandlers
{
    /// <summary>
    /// Bot意外断连
    /// </summary>
    public class BotDroppedHandlers : IMiraiMessageHandler<IMiraiSession, IBotDroppedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IBotDroppedEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Bot群内权限呗改变
    /// </summary>
    public class BotGroupPermissionChangedHandlers : IMiraiMessageHandler<IMiraiSession, IBotGroupPermissionChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IBotGroupPermissionChangedEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Bot被邀请入群
    /// </summary>
    public class BotInvitedJoinGroupHandlers : IMiraiMessageHandler<IMiraiSession, IBotInvitedJoinGroupEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IBotInvitedJoinGroupEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Bot入群消息
    /// </summary>
    public class BotJoinedGroupHandlers : IMiraiMessageHandler<IMiraiSession, IBotJoinedGroupEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IBotJoinedGroupEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// BOT被迫掉线
    /// </summary>
    public class BotKickedOfflineHandlers : IMiraiMessageHandler<IMiraiSession, IBotKickedOfflineEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IBotKickedOfflineEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// BOT被移出群聊
    /// </summary>
    public class BotKickedOutHandlers : IMiraiMessageHandler<IMiraiSession, IBotKickedOutEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IBotKickedOutEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Bot被禁言
    /// </summary>
    public class BotMutedHandlers : IMiraiMessageHandler<IMiraiSession, IBotMutedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IBotMutedEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Bot登录成功
    /// </summary>
    public class BotOnlineHandlers : IMiraiMessageHandler<IMiraiSession, IBotOnlineEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IBotOnlineEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Bot主动离开群聊
    /// </summary>
    public class BotPositiveLeaveGroupHandlers : IMiraiMessageHandler<IMiraiSession, IBotPositiveLeaveGroupEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IBotPositiveLeaveGroupEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Bot主动离线(有这个功能吗?)
    /// </summary>
    public class BotPositiveOfflineHandlers : IMiraiMessageHandler<IMiraiSession, IBotPositiveOfflineEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IBotPositiveOfflineEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Bot重新登录
    /// </summary>
    public class BotReloginHandlers : IMiraiMessageHandler<IMiraiSession, IBotReloginEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IBotReloginEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Bot被解禁
    /// </summary>
    public class BotUnmutedHandlers : IMiraiMessageHandler<IMiraiSession, IBotUnmutedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IBotUnmutedEventArgs message)
        {
            throw new NotImplementedException();
        }
    }
}
