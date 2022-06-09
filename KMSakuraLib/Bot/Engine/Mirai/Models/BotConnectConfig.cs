using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSakuraLib.Bot.Engine.Mirai.Models
{
    internal class BotConnectConfig
    {
        /// <summary>
        /// 设置名称
        /// </summary>
        public string ConfigName { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IPAddress { get; set; }

        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 认证KEY
        /// </summary>
        public string AuthKey { get; set; }

        /// <summary>
        /// 绑定的QQ号码
        /// </summary>
        public long QQNumber { get; set; }
    }
}
