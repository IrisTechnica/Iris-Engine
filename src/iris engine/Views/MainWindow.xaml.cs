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
using System.Windows.Shapes;
using MetroRadiance.Chrome;
using MetroRadiance.Interop.Win32;
using MetroRadiance.Platform;
using MetroRadiance.UI;
using iris_engine.NetWork;
namespace iris_engine.Views
{
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
    }
}
