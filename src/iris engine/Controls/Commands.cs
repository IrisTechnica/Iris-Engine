using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace iris_engine.Commands {
    class Commands {
        public static RoutedUICommand New_File = new RoutedUICommand("ファイルの新規作成", "New_File", typeof(Commands));
        public static RoutedUICommand New_Project = new RoutedUICommand("プロジェクトの新規作成", "New_Project", typeof(Commands));

        public static RoutedUICommand View_NetWork = new RoutedUICommand("ネットワークウィンドウの表示","View_NetWork",typeof(Commands));

        public static void AddCommand(CommandBindingCollection CommandBindings) {

            CommandBindings.Add(new CommandBinding(Commands.New_File, delegate { MessageBox.Show("新規ファイルの作成"); }));
            CommandBindings.Add(new CommandBinding(Commands.New_Project, delegate { MessageBox.Show("新規プロジェクトの作成"); }));

            CommandBindings.Add(new CommandBinding(Commands.View_NetWork, delegate {

            }));

        }
    }
}
