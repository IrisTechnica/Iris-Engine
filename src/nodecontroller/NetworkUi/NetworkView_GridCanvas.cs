using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace NetworkUI
{
    public partial class NetworkView
    {
        #region internal private data members

        private FrameworkElement gridCanvas = null;

        private const int gridSize = 5;
        private ScaleTransform scaleTransform = new ScaleTransform();

        private Object canvasLocker = new object();

        private const Decimal buildThreadNum = 0;

        #endregion

        public void BuildGrid(object sender, RoutedEventArgs e)
        {
            Canvas canvas = gridCanvas as Canvas;
            if (canvas == null) return;

            canvas.Children.Clear();

            GeometryGroup row = new GeometryGroup();
            GeometryGroup column = new GeometryGroup();

            // Row
            for(int i = 0; i < canvas.ActualHeight; i += gridSize * 2)
            {
                var start = i + gridSize; // 幅を2倍でとっているのでその中心に来るようにする
                row.Children.Add(new RectangleGeometry(new Rect(0, start, canvas.ActualWidth, gridSize)));
            }

            // Column
            for (int i = 0; i < canvas.ActualWidth; i += gridSize * 2)
            {
                var start = i + gridSize; // 幅を2倍でとっているのでその中心に来るようにする
                var end = start + gridSize;
                column.Children.Add(new RectangleGeometry(new Rect(start, 0, gridSize, canvas.ActualHeight)));
            }

            CombinedGeometry combind = new CombinedGeometry(GeometryCombineMode.Xor, row, column);

            Path path = new Path()
            {
                Stroke = Brushes.Transparent,
                StrokeThickness = 0,
                Fill = this.FindResource("gridFrontBrushKey") as Brush
            };

            path.Data = combind.GetOutlinedPathGeometry();

            canvas.Background = this.FindResource("gridBackBrushKey") as Brush;
            canvas.Children.Add(path);

            //for (int ix = 0; ix < canvas.ActualWidth; ix += gridSize)
            //{
            //    var actual_ix = ix / gridSize;
            //    for (int iy = 0; iy < canvas.ActualHeight; iy += gridSize)
            //    {
            //        var actual_iy = iy / gridSize;

            //        var isBackColor = (actual_ix % 2 == 0 && actual_iy % 2 == 0) || (actual_ix % 2 == 1 && actual_iy % 2 == 1);

            //        Path path = new Path()
            //        {
            //            Data = new RectangleGeometry(new Rect(new Point(ix, iy), new Size(gridSize, gridSize))),
            //            Stroke = Brushes.Transparent,
            //            StrokeThickness = 0,
            //            Fill = (isBackColor ? this.FindResource("gridBackBrushKey") : this.FindResource("gridFrontBrushKey")) as Brush
            //        };

            //        path.Data.Transform = scaleTransform;

            //        canvas.Children.Add(path);
            //    }
            //}

        }
    }
}
