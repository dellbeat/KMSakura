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

namespace KMSakura.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        BotConnectConfig Aconfig = null;
        BotConnectConfig BConfig = null;
        Bot botA = null;
        Bot botB = null;

        private string _title = "测试";

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public MainWindowViewModel()
        {
            Common.CommonInit();
            InitBotConfig();
            LoginBot();
        }

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

            //string BStatu = await botB.InitBot(BConfig);

            //Common.RunLogger.Info(BStatu);

            //MessageBox.Show(AStatu + "|" + BStatu);
        }
    }
}
