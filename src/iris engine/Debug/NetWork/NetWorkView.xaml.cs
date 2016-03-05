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
using iris_engine.NetWork;

namespace iris_engine.Debug {
    /// <summary>
    /// NetWork.xaml の相互作用ロジック
    /// </summary>
    public partial class NetWorkView : UserControl {
        public NetWorkView( ) {
            InitializeComponent();

        }

        
        

        private void SendCommandbutton_Click(object sender, RoutedEventArgs e) {
            NetWork.NetWork network = NetWork.NetWork.GetInstance();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(CommandBox.Text);
            network.Send(data);
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e) {
            NetWork.NetWork network = NetWork.NetWork.GetInstance();
            network.Init();
            network.Connect(ClientAddressBox.Text, ClientSendPortBox.Text,ServerPortBox.Text);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) {
            NetWork.NetWork network = NetWork.NetWork.GetInstance();
            network.Close();
        }
    }
}
