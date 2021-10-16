using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Mirai.CSharp.HttpApi.Builder;
using Mirai.CSharp.HttpApi.Invoking;
using Mirai.CSharp.HttpApi.Options;
using Mirai.CSharp.HttpApi.Session;
using Mirai.CSharp.Builders;
using KMSakuraLib.BotHandlers;
using System.Linq;
using Mirai.CSharp.Handlers;
using KMSakuraLib.Session;
using KMSakuraLib.Models;

namespace KMSakuraLib
{
    public class Bot
    {
        private IServiceProvider _serviceProvider;

        private Dictionary<long, IServiceScope> _scopeDic;

        /// <summary>
        /// 创建一个机器人实例
        /// </summary>
        /// <param name="config"></param>
        public void InitBot(BotConnectConfig config)
        {
            if (_serviceProvider == null)//初始化
            {   
                IServiceCollection servicesCol = new ServiceCollection();//最初的framework
                IEnumerable<IMiraiMessageHandler> handlers = CreateAllInstancesOf<IMiraiMessageHandler>();

                var builder = servicesCol.AddMiraiBaseFramework();

                foreach (IMiraiMessageHandler typeInstance in handlers)//将所有handler通过Bulider接入framework
                {
                    builder.AddHandler(typeInstance);
                }

                _serviceProvider = builder.Services.AddDefaultMiraiHttpFramework().
                                            AddInvoker<MiraiHttpMessageHandlerInvoker>().
                                            AddClient<MiraiScopedHttpSession>().Services.
                                            AddLogging().BuildServiceProvider();

                _scopeDic = new Dictionary<long, IServiceScope>();
            }

            IServiceScope scope = _serviceProvider.CreateScope();//创建新的作用域
            /*如何添加配置*/
            IServiceProvider provider = scope.ServiceProvider;
            IMiraiHttpSession session = provider.GetRequiredService<MiraiScopedHttpSession>();//获取session
        }

        /// <summary>
        /// 获取所有继承接口的类
        /// </summary>
        /// <param name="parentType">接口类</param>
        /// <returns></returns>
        public static IEnumerable<T> CreateAllInstancesOf<T>()
        {
            return typeof(T).Assembly.GetTypes() //获取当前类库下所有类型
                .Where(t => typeof(T).IsAssignableFrom(t)) //获取间接或直接继承t的所有类型
                .Where(t => !t.IsAbstract && t.IsClass).Select(t => (T)Activator.CreateInstance(t)); //获取非抽象类 排除接口继承
        }
    }
}
