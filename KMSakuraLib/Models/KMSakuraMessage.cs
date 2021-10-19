using Mirai.CSharp.Models.EventArgs;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMSakuraLib.Models
{
    /// <summary>
    /// 包裹消息类
    /// </summary>
    /// <typeparam name="TMessage"></typeparam>
    public class KMSakuraMessage<TMessage> : IKMSakuraMessage<TMessage> where TMessage : IMiraiMessage
    {
        public long BotQQNumber { get; }

        public TMessage Message { get; }

        public KMSakuraMessage(long botQQNumber, TMessage message)
        {
            BotQQNumber = botQQNumber;
            Message = message;
        }
    }
}
