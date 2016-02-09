using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.AvalonDock.Themes;

namespace AvalonDock.Themes
{
    public class DarkTheme : Theme
    {
        public override Uri GetResourceUri()
        {
            return new Uri(
                "/AvalonDock.Themes.IrisIDE;component/DarkTheme.xaml",
                UriKind.Relative);
        }
    }
}
