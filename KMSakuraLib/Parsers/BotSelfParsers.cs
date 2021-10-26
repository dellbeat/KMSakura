using KMSakuraLib.BotParser;
using Mirai.CSharp.HttpApi.Handlers;
using Mirai.CSharp.HttpApi.Models.EventArgs;
using Mirai.CSharp.HttpApi.Parsers;
using Mirai.CSharp.HttpApi.Parsers.Attributes;
using Mirai.CSharp.HttpApi.Session;
using System.Threading.Tasks;

namespace KMSakuraLib.Parsers
{
    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IBotDroppedEventArgs, BotDroppedEventArgs>))]
    public class BotDroppedParser : Parser, IMiraiHttpMessageHandler<IBotDroppedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IBotDroppedEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IBotGroupPermissionChangedEventArgs, BotGroupPermissionChangedEventArgs>))]
    public class BotGroupPermissionChangedParser : Parser, IMiraiHttpMessageHandler<IBotGroupPermissionChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IBotGroupPermissionChangedEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IBotInvitedJoinGroupEventArgs, BotInvitedJoinGroupEventArgs>))]
    public class BotInvitedJoinGroupParser : Parser, IMiraiHttpMessageHandler<IBotInvitedJoinGroupEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IBotInvitedJoinGroupEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IBotJoinedGroupEventArgs, BotJoinedGroupEventArgs>))]
    public class BotJoinedGroupParser : Parser, IMiraiHttpMessageHandler<IBotJoinedGroupEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IBotJoinedGroupEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IBotKickedOfflineEventArgs, BotKickedOfflineEventArgs>))]
    public class BotKickedOfflineParser : Parser, IMiraiHttpMessageHandler<IBotKickedOfflineEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IBotKickedOfflineEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IBotKickedOutEventArgs, BotKickedOutEventArgs>))]
    public class BotKickedOutParser : Parser, IMiraiHttpMessageHandler<IBotKickedOutEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IBotKickedOutEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IBotMutedEventArgs, BotMutedEventArgs>))]
    public class BotMutedParser : Parser, IMiraiHttpMessageHandler<IBotMutedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IBotMutedEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IBotOnlineEventArgs, BotOnlineEventArgs>))]
    public class BotOnlineParser : Parser, IMiraiHttpMessageHandler<IBotOnlineEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IBotOnlineEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IBotPositiveLeaveGroupEventArgs, BotPositiveLeaveGroupEventArgs>))]
    public class BotPositiveLeaveGroupParser : Parser, IMiraiHttpMessageHandler<IBotPositiveLeaveGroupEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IBotPositiveLeaveGroupEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    //IBotPositiveOfflineEventArgs暂无继承类，不予编写
    //[RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IBotPositiveOfflineEventArgs, BotPositiveOfflineEventArgs>))]
    //public class BotPositiveOfflineParser : Parser, IMiraiHttpMessageHandler<IBotPositiveOfflineEventArgs>
    //{
    //    public Task HandleMessageAsync(IMiraiHttpSession client, IBotPositiveOfflineEventArgs message)
    //    {
    //        return Task.FromResult(false);
    //    }
    //}

    //[RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IBotOnlineEventArgs, BotReloginEventArgs>))]
    public class BotReloginParser : Parser, IMiraiHttpMessageHandler<IBotReloginEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IBotReloginEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IBotUnmutedEventArgs, BotUnmutedEventArgs>))]
    public class BotUnmutedParser : Parser, IMiraiHttpMessageHandler<IBotUnmutedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IBotUnmutedEventArgs message)
        {
            return Task.FromResult(false);
        }
    }
}
