using Mirai.CSharp.Models.EventArgs;
using Prism.Events;

namespace KMSakuraLib.Events
{
    /// <summary>
    /// 其他客户端消息事件订阅
    /// </summary>
    public class OtherClientMessageEvent : PubSubEvent<IOtherClientMessageEventArgs>
    {

    }

    /// <summary>
    /// 陌生人消息事件订阅
    /// </summary>
    public class StrangerMessageEvent : PubSubEvent<IStrangerMessageEventArgs>
    {

    }

    /// <summary>
    /// 临时会话消息事件订阅
    /// </summary>
    public class TempMessageEvent : PubSubEvent<ITempMessageEventArgs>
    {

    }
}
