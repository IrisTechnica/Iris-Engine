using System;
using System.Threading.Tasks;
using System.Windows;
namespace iris_engine.Views {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow {
        public NetWork.NetWork network;


        public MainWindow()
        {
            this.InitializeComponent();

            this.Loaded += MainWindow_Loaded;
            
            //Commandの追加
            Commands.Commands.AddCommand(this.CommandBindings);
            this.network = new NetWork.NetWork();
            this.network.Init();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var App = Application.Current as App;
            if (App == null || App.Splash == null) return;
            App.Splash.Close(new TimeSpan(0, 0, 1));
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            this.network.Close();
        }
    }
}
