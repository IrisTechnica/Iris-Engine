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
        
        private void AddAddressButton_Click(object sender, RoutedEventArgs e) {
            foreach(var v in AddressCombo.Items ) {

                if(v.ToString() == (AddressBox.Text + ":" + PortBox.Text )) {
                    return;
                }
            }
            AddressCombo.Items.Add(AddressBox.Text+":"+ PortBox.Text);
        }

        private void AddressCombo_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            AddressCombo.SelectedIndex = 0;
        }

        private void AddressRemove_Button_Click(object sender, RoutedEventArgs e) {
            AddressCombo.Items.Remove(AddressCombo.SelectedValue);
        }

        private void button_Click(object sender, RoutedEventArgs e) {
        }

        private void SendCommandbutton_Click(object sender, RoutedEventArgs e) {
        }
    }
}
