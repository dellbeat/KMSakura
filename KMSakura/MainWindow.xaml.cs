using KMSakuraLib;
using KMSakuraLib.Models;
using System.Windows;
using KMSakuraLib.Ability;

namespace KMSakura
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BotConnectConfig Aconfig = null;
        BotConnectConfig BConfig = null;
        Bot botA = null;
        Bot botB = null;

        public MainWindow()
        {
            InitializeComponent();
            Common.CommonInit();
            InitBotConfig();
            LoginBot();
            
            Common.RunLogger.Info("主程序加载完成");
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

            string BStatu = await botB.InitBot(BConfig);

            Common.RunLogger.Info(BStatu);

            MessageBox.Show(AStatu + "|" + BStatu);
        }

    }
}
