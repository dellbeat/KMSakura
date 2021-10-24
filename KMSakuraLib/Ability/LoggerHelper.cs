using System;
using System.Collections.Generic;
using System.Text;

namespace KMSakuraLib.Ability
{
    /// <summary>
    /// 日志帮助类
    /// </summary>
    public static class LoggerHelper
    {
        /// <summary>
        /// 根据名称获取logger
        /// </summary>
        /// <param name="name">在配置文件中的名称</param>
        /// <returns></returns>
        public static NLog.Logger GetLogger(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return NLog.LogManager.GetCurrentClassLogger();
            }

            return NLog.LogManager.GetLogger(name);
        }

        /// <summary>
        /// 提示消息
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="propertyName">属性名</param>
        /// <param name="value">属性值</param>
        /// <param name="msg">需要记录的消息</param>
        public static void InfoMsg(this NLog.Logger logger,string propertyName,string value,string msg)
        {
            logger.WithProperty(propertyName,value).Info(msg);
        }

        /// <summary>
        /// 警告消息
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <param name="msg"></param>
        public static void WarnMsg(this NLog.Logger logger, string propertyName, string value, string msg)
        {
            logger.WithProperty(propertyName, value).Warn(msg);
        }

        /// <summary>
        /// 调试消息
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <param name="msg"></param>
        public static void DebugMsg(this NLog.Logger logger, string propertyName, string value, string msg)
        {
            logger.WithProperty(propertyName, value).Debug(msg);
        }

        /// <summary>
        /// 错误消息
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <param name="msg"></param>
        public static void ErrorMsg(this NLog.Logger logger, string propertyName, string value, string msg)
        {
            logger.WithProperty(propertyName, value).Error(msg);
        }
    }
}
