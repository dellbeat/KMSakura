using KMSakuraLib.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSakuraLib.Bot.Interface
{
    public interface IBot
    {
        /// <summary>
        /// 机器人使用的引擎类型
        /// </summary>
        EngineType BotType { get;}

        void Connect(params object[] loginParams);

        void DisConnect(params object[] disConnectParams);
    }
}