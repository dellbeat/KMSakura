using KMSakuraLib.Bot.Interface;
using KMSakuraLib.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSakuraLib.Bot
{
    public class Bot : IBot
    {
        public EngineType BotType { get; private set; }
        private dynamic? _engineInstance;

        public void Connect(params object[] loginParams)
        {
            throw new NotImplementedException();
        }

        public void DisConnect(params object[] disConnectParams)
        {
            throw new NotImplementedException();
        }
    }
}
