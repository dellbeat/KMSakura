using KMSakuraLib.Bot.Engine.Mirai;
using KMSakuraLib.Bot.Engine.Mirai.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Mirai.CSharp.Builders;
using Mirai.CSharp.HttpApi.Builder;
using Mirai.CSharp.HttpApi.Invoking;
using Mirai.CSharp.HttpApi.Options;
using Mirai.CSharp.HttpApi.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSakuraLib.Bot.Engine
{
    internal class Mirai_CSharp
    {
        private static Dictionary<long, IServiceScope> _scopeDic;

        private static IServiceProvider? _serviceProvider;

        private static Dictionary<long, Mirai_CSharp> BotsDic;

        private BotConnectConfig _config;

        /// <summary>
        /// 当前BOT绑定的QQ号
        /// </summary>
        public long QQNumber
        {
            get => _config.QQNumber;
        }

        /// <summary>
        /// 会话对象
        /// </summary>
        private MiraiScopedHttpSession? _session;

        /// <summary>
        /// 创建一个机器人实例
        /// </summary>
        /// <param name="config">连接配置</param>
        public static async Task<Mirai_CSharp> InitBot(BotConnectConfig config)
        {
            if (_serviceProvider == null)//初始化
            {
                IServiceCollection servicesCol = new ServiceCollection();//最初的framework

                var builder = servicesCol.AddMiraiBaseFramework();

                var httpBuilder = new MiraiHttpFrameworkBuilder(servicesCol).Services.AddDefaultMiraiHttpFramework();

                _serviceProvider = httpBuilder.
                                    AddInvoker<MiraiHttpMessageHandlerInvoker>().
                                    AddClient<MiraiScopedHttpSession>().Services.
                                    AddLogging().
                                    BuildServiceProvider();

                _scopeDic = new Dictionary<long, IServiceScope>();
            }

            if (_scopeDic.ContainsKey(config.QQNumber))
            {
                return BotsDic[config.QQNumber];
            }

            Mirai_CSharp botInstance = new Mirai_CSharp();

            IServiceScope scope = _serviceProvider.CreateScope();//创建新的作用域
            IServiceProvider provider = scope.ServiceProvider;
            MiraiHttpSessionOptions options = provider.GetRequiredService<IOptionsSnapshot<MiraiHttpSessionOptions>>().Value;//配置当前作用域的连接配置
            options.AuthKey = config.AuthKey;
            options.Host = config.IPAddress;
            options.Port = config.Port;
            IMiraiHttpSession session = provider.GetRequiredService<IMiraiHttpSession>();//获取session

            await session.ConnectAsync(config.QQNumber);
            _scopeDic.Add(config.QQNumber, scope);
            botInstance._session = session as MiraiScopedHttpSession;

            return botInstance;
        }
    }
}
