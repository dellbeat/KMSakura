using KMSakuraLib.BotParser;
using Mirai.CSharp.HttpApi.Handlers;
using Mirai.CSharp.HttpApi.Models.EventArgs;
using Mirai.CSharp.HttpApi.Models.EventArgs.OtherClient;
using Mirai.CSharp.HttpApi.Models.EventArgs.Stranger;
using Mirai.CSharp.HttpApi.Parsers;
using Mirai.CSharp.HttpApi.Parsers.Attributes;
using Mirai.CSharp.HttpApi.Session;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KMSakuraLib.Parsers
{
    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IOtherClientMessageEventArgs, OtherClientMessageEventArgs>))]
    public class OtherClientMessageParser : Parser, IMiraiHttpMessageHandler<IOtherClientMessageEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IOtherClientMessageEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<IStrangerMessageEventArgs, StrangerMessageEventArgs>))]
    public class StrangerMessageParser : Parser, IMiraiHttpMessageHandler<IStrangerMessageEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, IStrangerMessageEventArgs message)
        {
            return Task.FromResult(false);
        }
    }

    [RegisterMiraiHttpParser(typeof(DefaultMappableMiraiHttpMessageParser<ITempMessageEventArgs, TempMessageEventArgs>))]
    public class TempMessageParser : Parser, IMiraiHttpMessageHandler<ITempMessageEventArgs>
    {
        public Task HandleMessageAsync(IMiraiHttpSession client, ITempMessageEventArgs message)
        {
            return Task.FromResult(false);
        }
    }
}
