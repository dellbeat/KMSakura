using KMSakuraLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KMSakuraLib;

namespace KMSakura
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BotConnectConfig Aconfig = null;
        BotConnectConfig BConfig = null;
        Bot bot = null;


        public MainWindow()
        {
            InitializeComponent();

            bot = new Bot();
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

            LoginBot();

        }

        private async void LoginBot()
        {
            string AStatu = await bot.InitBot(Aconfig);

            Bot.RunLogger.Info("A登录状态:" + AStatu);

            //string BStatu = await bot.InitBot(BConfig);

            //Bot.RunLogger.Info("B登录状态:" + BStatu);

            MessageBox.Show(AStatu);
        }

    }
}
