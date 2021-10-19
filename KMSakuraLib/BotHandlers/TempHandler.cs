using Mirai.CSharp.Handlers;
using Mirai.CSharp.Models.EventArgs;
using Mirai.CSharp.Session;
using System;
using System.Threading.Tasks;

namespace KMSakuraLib.BotHandlers
{
    /// <summary>
    /// 其他客户端消息[理解为自己发送的消息同步?]
    /// </summary>
    public class OtherClientMessageHandlers : Handler, IMiraiMessageHandler<IMiraiSession, IOtherClientMessageEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IOtherClientMessageEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 陌生人消息
    /// </summary>
    public class StrangerMessageHandlers : Handler, IMiraiMessageHandler<IMiraiSession, IStrangerMessageEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, IStrangerMessageEventArgs message)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 临时会话消息
    /// </summary>
    public class TempMessageHandlers : Handler, IMiraiMessageHandler<IMiraiSession, ITempMessageEventArgs>
    {
        public Task HandleMessageAsync(IMiraiSession client, ITempMessageEventArgs message)
        {
            throw new NotImplementedException();
        }
    }
}
