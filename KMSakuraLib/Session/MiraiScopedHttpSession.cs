using Microsoft.Extensions.Options;
using Mirai.CSharp.HttpApi.Invoking;
using Mirai.CSharp.HttpApi.Options;
using Mirai.CSharp.HttpApi.Session;
using Mirai.CSharp.HttpApi.Utility;
using Mirai.CSharp.HttpApi.Utility.JsonConverters;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace KMSakuraLib.Session
{
    /// <summary>
    /// 用于一作用域一配置的HttpSession
    /// </summary>
    public class MiraiScopedHttpSession : MiraiHttpSession
    {
        public MiraiScopedHttpSession(IServiceProvider services, IOptionsSnapshot<MiraiHttpSessionOptions> options, IMiraiHttpMessageHandlerInvoker invoker, ChatMessageJsonConverter jsonConverter, HttpClient? client = null, ISilkLameCoder? coder = null) : base(services, options, invoker, jsonConverter, client, coder)
        {

        }
    }
}
