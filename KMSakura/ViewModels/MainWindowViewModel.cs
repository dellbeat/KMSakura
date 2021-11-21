using KMSakuraLib;
using KMSakuraLib.Models;
using Mirai.CSharp.HttpApi.Models.ChatMessages;
using Mirai.CSharp.Models.EventArgs;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using HttpApiModel = Mirai.CSharp.HttpApi.Models.EventArgs;
using Prism.Commands;
using System.Collections.ObjectModel;
using Mirai.CSharp.HttpApi.Models;
using System.Windows;
using Newtonsoft.Json;
using Prism.Services.Dialogs;

namespace KMSakura.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        BotConnectConfig Aconfig = null;
        BotConnectConfig BConfig = null;
        Bot botA = null;
        Bot botB = null;

        private void InitBotConfig()
        {
            botA = new Bot();
            botB = new Bot();
            Aconfig = new BotConnectConfig
            {
                AuthKey = "8299b471ca7d1a63",
                IPAddress = "127.0.0.1",
                Port = 2333,
                QQNumber = 0,
                ConfigName = "AConfig"
            };

            BConfig = new BotConnectConfig
            {
                AuthKey = "8299b471ca7d1a63",
                IPAddress = "127.0.0.1",
                Port = 2333,
                QQNumber = 0,
                ConfigName = "BConfig"
            };
        }

        private async void LoginBot()
        {
            string AStatu = await botA.InitBot(Aconfig);

            Common.RunLogger.Info(AStatu);
        }
    }
}
