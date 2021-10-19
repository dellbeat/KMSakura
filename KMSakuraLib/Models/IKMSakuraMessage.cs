using Mirai.CSharp.Models.EventArgs;
using System;
using System.Collections.Generic;
using System.Text;

namespace KMSakuraLib.Models
{
    /// <summary>
    /// 包裹消息接口
    /// </summary>
    /// <typeparam name="TMessage"></typeparam>
    public interface IKMSakuraMessage<TMessage> where TMessage : IMiraiMessage
    {
        long BotQQNumber { get; }

        TMessage Message { get; }
    }
}
