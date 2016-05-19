using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iris_engine.Controls
{
    public class FantScalingImage : System.Windows.Controls.Image
    {
        protected override void OnRender(System.Windows.Media.DrawingContext dc)
        {
            this.VisualBitmapScalingMode = System.Windows.Media.BitmapScalingMode.Fant;
            base.OnRender(dc);
        }
    }
}
