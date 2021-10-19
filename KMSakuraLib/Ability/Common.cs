using log4net;
using log4net.Config;
using log4net.Repository;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace KMSakuraLib
{
    /// <summary>
    /// 全局组件定义
    /// </summary>
    public class Common
    {
        private static ILoggerRepository repository;
        /// <summary>
        /// 全局运行日志
        /// </summary>
        public static ILog RunLogger;
        /// <summary>
        /// 全局聊天记录日志
        /// </summary>
        public static ILog RecordLogger;
        /// <summary>
        /// 全局事件订阅器
        /// </summary>
        public static IEventAggregator ea;

        /// <summary>
        /// 全局组件统一初始化入口
        /// </summary>
        public static void CommonInit()
        {
            InitLogger();
        }

        /// <summary>
        /// 初始化日志
        /// </summary>
        private static void InitLogger()
        {
            /*
             日志方面后续考虑一BOT一专用日志[目前不清楚如何动态设置logger写入路径]
             */
            repository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
            BasicConfigurator.Configure(repository);
            RunLogger = LogManager.GetLogger(repository.Name, "RunLogger");
            RecordLogger = LogManager.GetLogger(repository.Name, "RecordLogger");
            ea = new EventAggregator();
        }
    }
}
