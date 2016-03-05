using iris_engine.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace iris_engine.Controls
{
    /// <summary>
    /// LogController.xaml の相互作用ロジック
    /// </summary>
    public partial class LogController : UserControl
    {
        public LogController()
        {
            InitializeComponent();
            this.ViewModel.PropertyChanged += LogBox_PropertyChanged;
            //this.LogBox.TextChanged += LogBox_TextChanged;

            ViewModel.RegexTextFormats.Add(@"(a.*b)", 
                new List<LogControllerViewModel.InternalFormat>()
                    { new LogControllerViewModel.InternalFormat(Run.ForegroundProperty, new SolidColorBrush(Color.FromRgb(255, 0, 0))) });


            this.ViewModel.Writer.AutoFlush = true;
            //Console.SetOut(TextWriter.Synchronized(this.ViewModel.Writer));
            //Console.WriteLine("test");
        }

        //private void LogBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (this.LogBox.Text != this.ViewModel.LogText)
        //    {
        //        this.ViewModel.LogText = this.LogBox.Text;
        //    }
        //}

        private void LogBox_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(this.ViewModel.Memory))
                Update();
        }

        private void Update()
        {
            var control = this.LogBox;
            if (control == null) return;


            var currentStart = control.Selection.Start;
            var currentEnd = control.Selection.End;
            control.SelectAll();
            var allRange = new TextRange(control.Selection.Start,control.Selection.End);
            var allText = control.Selection.Text;
            allRange.ClearAllProperties();

            foreach(var regexPair in ViewModel.RegexTextFormats)
            {
                var regex = new Regex(regexPair.Key);
                var resultList = regex.Matches(allText);

                foreach(Match result in resultList)
                {
                    var matchStartPoint = allRange.Start.GetPositionAtOffset(result.Index);
                    var matchEndPoint = matchStartPoint.GetPositionAtOffset(result.Length);
                    control.Selection.Select(matchStartPoint, matchEndPoint);
                    foreach (var props in regexPair.Value)
                    {
                        control.Selection.ApplyPropertyValue(props.textElementProperty, props.value);
                    }
                }
            }

            control.Selection.Select(currentStart, currentEnd);


        }

        public LogControllerViewModel ViewModel
        {
            get { return (LogControllerViewModel)DataContext; }
        }
        
    }
}
