using KMSakuraLib.BotParser;
using Mirai.CSharp.HttpApi.Handlers;
using Mirai.CSharp.HttpApi.Models.EventArgs;
using Mirai.CSharp.HttpApi.Parsers;
using Mirai.CSharp.HttpApi.Parsers.Attributes;
using Mirai.CSharp.HttpApi.Session;
using System.Threading.Tasks;

namespace KMSakuraLib.Parsers
{
    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IFriendInputStatusChangedEventArgs, FriendInputStatusChangedEventArgs>))]
    public class FriendInputStatusChangedParser : Parser, IMiraiHttpMessageHandler<IFriendInputStatusChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IFriendInputStatusChangedEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IFriendMessageEventArgs, FriendMessageEventArgs>))]
    public class FriendMessageParser : Parser, IMiraiHttpMessageHandler<IFriendMessageEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IFriendMessageEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IFriendMessageRevokedEventArgs, FriendMessageRevokedEventArgs>))]
    public class FriendMessageRevokedParser : Parser, IMiraiHttpMessageHandler<IFriendMessageRevokedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IFriendMessageRevokedEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IFriendNickChangedEventArgs, FriendNickChangedEventArgs>))]
    public class FriendNickChangedParser : Parser, IMiraiHttpMessageHandler<IFriendNickChangedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IFriendNickChangedEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<INewFriendApplyEventArgs, NewFriendApplyEventArgs>))]
    public class NewFriendApplyParser : Parser, IMiraiHttpMessageHandler<INewFriendApplyEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, INewFriendApplyEventArgs message)
        {
            return Task.FromResult(false);
        }
    }
}
