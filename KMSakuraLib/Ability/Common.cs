using Prism.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using KMSakuraLib.Ability;
using NLog;
using System.Collections.Concurrent;

namespace KMSakuraLib
{
    /// <summary>
    /// 全局组件定义
    /// </summary>
    public class Common
    {
        /// <summary>
        /// 全局运行日志
        /// </summary>
        public static Logger RunLogger;
        /// <summary>
        /// 全局消息日志记录
        /// </summary>
        public static Logger RecordLogger;
        /// <summary>
        /// 全局事件订阅器
        /// </summary>
        public static IEventAggregator ea;

        /// <summary>
        /// 全局获取BOT对象字典
        /// </summary>
        public static ConcurrentDictionary<long, Bot> BotDic = new ConcurrentDictionary<long, Bot>();

        public static bool InitStatu { get; private set; }

        /// <summary>
        /// 全局组件统一初始化入口
        /// </summary>
        public static void CommonInit()
        {
            InitLogger();
            InitParam();
            InitStatu = true;
        }

        /// <summary>
        /// 需要写入BOT消息日志的属性名称
        /// </summary>
        public const string BotLogName = "number";

        /// <summary>
        /// 初始化日志
        /// </summary>
        private static void InitLogger()
        {
            RunLogger = LogManager.GetLogger("run_log");//获取全局运行日志记录器
            RecordLogger = LoggerHelper.GetLogger("record_log");//获取全局消息日志记录器
            RunLogger.Info("初始化日志完成");
        }

        private static void InitParam()
        {
            ea = new EventAggregator();
        }
    }
}
