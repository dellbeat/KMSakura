using Mirai.CSharp.Models.EventArgs;
using System;

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

        public KMSakuraMessage(long? botQQNumber, TMessage message)
        {
            if (botQQNumber == null)
            {
                BotQQNumber = -1;
            }
            else
            {
                BotQQNumber = Convert.ToInt64(botQQNumber);
            }
            Message = message;
        }
    }
}
