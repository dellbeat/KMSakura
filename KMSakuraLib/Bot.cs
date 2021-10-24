using KMSakuraLib.BotHandlers;
using KMSakuraLib.BotParser;
using KMSakuraLib.Models;
using KMSakuraLib.Session;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Mirai.CSharp.Builders;
using Mirai.CSharp.Handlers;
using Mirai.CSharp.HttpApi.Builder;
using Mirai.CSharp.HttpApi.Invoking;
using Mirai.CSharp.HttpApi.Options;
using Mirai.CSharp.HttpApi.Session;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KMSakuraLib.Ability;

namespace KMSakuraLib
{
    public class Bot
    {
        private static Dictionary<long, IServiceScope> _scopeDic;
        
        private static IServiceProvider _serviceProvider;

        /// <summary>
        /// 会话对象
        /// </summary>
        private MiraiScopedHttpSession _session;

        /// <summary>
        /// 创建一个机器人实例
        /// </summary>
        /// <param name="config">连接配置</param>
        public async Task<string> InitBot(BotConnectConfig config)
        {
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
                _session = session as MiraiScopedHttpSession;
                Common.RecordLogger.InfoMsg(Common.BotLogName, config.QQNumber.ToString(), $"BOT{config.QQNumber}登录初始化完成");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "连接成功";
        }

        /// <summary>
        /// 断连方法
        /// </summary>
        /// <param name="qqNumber">需要断连的BOT号码</param>
        /// <returns></returns>
        /// <exception cref="Exception">无此号码时或者断连中出现的异常</exception>
        public bool DisConnect(long qqNumber)
        {
            if (!_scopeDic.ContainsKey(qqNumber))
            {
                throw new Exception($"无号码为{qqNumber}的会话");
            }

            try
            {
                IServiceScope scope = _scopeDic[qqNumber];
                IMiraiHttpSession session = scope.ServiceProvider.GetRequiredService<IMiraiHttpSession>();//获取会话

                session.Dispose();//释放会话
                _scopeDic.Remove(qqNumber);//移除关联
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return true;
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
