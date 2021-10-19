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
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using log4net.Repository;
using log4net;
using log4net.Config;
using System.Reflection;
using System.IO;
using KMSakuraLib.BotParser;
using Mirai.CSharp.HttpApi.Handlers;

namespace KMSakuraLib
{
    public class Bot
    {
        private IServiceProvider _serviceProvider;

        private Dictionary<long, IServiceScope> _scopeDic;

        private static ILoggerRepository repository;

        public static ILog RunLogger;

        public static void InitLogger()
        {
            repository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
            BasicConfigurator.Configure(repository);
            RunLogger = LogManager.GetLogger(repository.Name, "RunLogger");
        }

        /// <summary>
        /// 创建一个机器人实例
        /// </summary>
        /// <param name="config"></param>
        public async Task<string> InitBot(BotConnectConfig config)
        {
            if (RunLogger == null)
            {
                InitLogger();
                RunLogger.Info("初始化完成");
            }

            if (_serviceProvider == null)//初始化
            {
                IServiceCollection servicesCol = new ServiceCollection();//最初的framework
                Handler[] handlers = CreateAllInstancesOf<Handler>();

                var builder = servicesCol.AddMiraiBaseFramework();

                foreach (IMiraiMessageHandler typeInstance in handlers)//将所有handler通过Bulider接入framework
                {
                    builder.AddHandler(typeInstance);
                }

                Type[] parserArray = GetAllClass<Parser>();

                var httpBuilder = builder.Services.AddDefaultMiraiHttpFramework();

                foreach (Type handler in parserArray)
                {
                    httpBuilder.ResolveParser(handler, null);
                }

                _serviceProvider = httpBuilder.
                                    AddInvoker<MiraiHttpMessageHandlerInvoker>().
                                    AddClient<MiraiScopedHttpSession>().Services.
                                    AddLogging().
                                    BuildServiceProvider();

                _scopeDic = new Dictionary<long, IServiceScope>();
            }

            if (_scopeDic.ContainsKey(config.QQNumber))
            {
                return "已有连接实例";
            }

            IServiceScope scope = _serviceProvider.CreateScope();//创建新的作用域
            IServiceProvider provider = scope.ServiceProvider;
            MiraiHttpSessionOptions options = provider.GetRequiredService<IOptionsSnapshot<MiraiHttpSessionOptions>>().Value;//配置当前作用域的连接配置
            options.AuthKey = config.AuthKey;
            options.Host = config.IPAddress;
            options.Port = config.Port;
            IMiraiHttpSession session = provider.GetRequiredService<IMiraiHttpSession>();//获取session

            try
            {
                await session.ConnectAsync(config.QQNumber);
                _scopeDic.Add(config.QQNumber, scope);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "连接成功";
        }

        /// <summary>
        /// 获取所有继承接口的类的实例
        /// </summary>
        /// <param name="parentType">接口类</param>
        /// <returns></returns>
        public static T[] CreateAllInstancesOf<T>()
        {
            return typeof(T).Assembly.GetTypes() //获取当前类库下所有类型
                .Where(t => typeof(T).IsAssignableFrom(t)) //获取间接或直接继承t的所有类型
                .Where(t => !t.IsAbstract && t.IsClass).Select(t => (T)Activator.CreateInstance(t)).ToArray(); //获取非抽象类 排除接口继承
        }

        /// <summary>
        /// 获取所有继承接口的类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Type[] GetAllClass<T>()
        {
            return typeof(T).Assembly.GetTypes() //获取当前类库下所有类型
                    .Where(t => typeof(T).IsAssignableFrom(t)) //获取间接或直接继承t的所有类型
                    .Where(t => !t.IsAbstract && t.IsClass).ToArray(); //获取非抽象类 排除接口继承
        }
    }
}
