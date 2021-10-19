using Mirai.CSharp.HttpApi.Handlers;
using Mirai.CSharp.HttpApi.Models.EventArgs;
using Mirai.CSharp.HttpApi.Parsers;
using Mirai.CSharp.HttpApi.Parsers.Attributes;
using Mirai.CSharp.HttpApi.Session;
using Mirai.CSharp.Models.ChatMessages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KMSakuraLib.BotParser
{
    public abstract class Parser
    {

    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IGroupMessageRevokedEventArgs, GroupMessageRevokedEventArgs>))]
    public class GroupMessageRevokedParser : Parser, IMiraiHttpMessageHandler<IGroupMessageRevokedEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IGroupMessageRevokedEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IGroupMessageEventArgs, GroupMessageEventArgs>))]
    public class GroupMessageParser : Parser, IMiraiHttpMessageHandler<IGroupMessageEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, Mirai.CSharp.HttpApi.Models.EventArgs.IGroupMessageEventArgs message)
        {
            return Task.FromResult(false);
        }
    }
}
