using iris_engine.ViewModels;
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

namespace iris_engine.Controls
{
    /// <summary>
    /// RadicalProgressBar.xaml の相互作用ロジック
    /// </summary>
    public partial class RadicalProgressBar : UserControl
    {

        public RadicalProgressBar()
        {
            InitializeComponent();
            ArcUpdate();
        }

        RadicalSliderViewModel ViewModel
        {
            get
            {
                return (RadicalSliderViewModel)DataContext;
            }
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            if(e.ChangedButton == MouseButton.Left)
            {
                ArcUpdate();
            }
        }


        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);

            this.CaptureMouse();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (this.IsMouseCaptured && !ContainsMouseCursor())
            {
                this.ReleaseMouseCapture();
            }
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);

            if(e.Delta != 0)
            {
                this.ViewModel.Value += e.Delta > 0 ? 1 : -1;
                ArcUpdate();
            }
        }

        /// <summary>
        ///     指定した精度の数値に切り捨てします。</summary>
        /// <param name="dValue">
        ///     丸め対象の倍精度浮動小数点数。</param>
        /// <param name="iDigits">
        ///     戻り値の有効桁数の精度。</param>
        /// <returns>
        ///     iDigits に等しい精度の数値に切り捨てられた数値。</returns>
        /// ------------------------------------------------------------------------
        public double ToRoundDown(double dValue, int iDigits)
        {
            double dCoef = System.Math.Pow(10, iDigits);

            return dValue > 0 ? System.Math.Floor(dValue * dCoef) / dCoef :
                                System.Math.Ceiling(dValue * dCoef) / dCoef;
        }

        /// <summary>
        /// コントロール上にマウスカーソルが含まれるかどうかを判断する。
        /// </summary>
        /// <param name="control">コントロール。</param>
        /// <returns>コントロール上にマウスカーソルが含まれるかどうか。</returns>
        public bool ContainsMouseCursor()
        {
            var pos = Mouse.GetPosition(this);
            var result = VisualTreeHelper.HitTest(this, pos);

            return result != null;
        }


        #region Public Methods

        public void ArcUpdate()
        {
            // 線の太さ
            double thick = this.ViewModel.StrokeThickness;

            // 入力値切捨て
            double inputValue = Math.Floor(this.ViewModel.Percentage * 100.0);

            // 角度の計算
            double angle = (inputValue * 3.6);

            
            if(angle < 0)
            {
                angle += 360;
            }
            if(angle > 360)
            {
                angle %= 360.0;
            }
            // 0-360を許容
            if (0 < angle && angle < 360)
            {
                // 角度によってフラグを変える
                this.ViewModel.IsLargeArcFlg = false;
                if (angle >= 180)
                {
                    // 180°を超える(180を含む)場合はフラグをtrue
                    this.ViewModel.IsLargeArcFlg = true;
                }
            }



            // 角度と半径から座標を計算
            double radius = (this.pathArc.Width / 2) - thick;

            pathArc.StrokeThickness = thick;
            pathCircleBackground.StrokeThickness = thick;

            if (angle != 0 && angle != 360)
            {

                angle -= 90;

                double radian = Math.PI * angle / 180.0;
                double x = radius * Math.Cos(radian);
                double y = radius * Math.Sin(radian);
                x = ToRoundDown(x, 3);
                y = ToRoundDown(y, 3);

                // 終点計算
                double endPointX = radius + x + thick;
                double endPointY = radius + y + thick;

                // 図形生成
                PathFigure pfArc = new PathFigure();
                pfArc.StartPoint = new Point(100, thick); // 開始点

                // セグメント生成
                ArcSegment arc = new ArcSegment();
                arc.Point = new Point(endPointX, endPointY); // 終点(計算値)
                arc.Size = new Size(radius, radius); // 半径
                arc.IsLargeArc = this.ViewModel.IsLargeArcFlg;
                arc.SweepDirection = SweepDirection.Clockwise;
                //arc.RotationAngle = Math.PI * -90.0 / 180.0;


                // 図形入れ替え
                pfArc.Segments.Clear();
                pfArc.Segments.Add(arc);

                this.pathGeometryArc.Figures.Clear();
                this.pathGeometryArc.Figures.Add(pfArc);

                // 図形生成（背景）
                PathFigure pfCircle = new PathFigure();
                pfCircle.StartPoint = new Point(100, thick); // 開始点

                // セグメント生成
                ArcSegment circle = new ArcSegment();
                circle.Point = new Point(endPointX, endPointY); // 終点(計算値)
                circle.Size = new Size(radius, radius); // 半径
                circle.IsLargeArc = !this.ViewModel.IsLargeArcFlg;
                circle.SweepDirection = SweepDirection.Counterclockwise;

                // 図形入れ替え
                pfCircle.Segments.Clear();
                pfCircle.Segments.Add(circle);

                this.pathGeometryCircle.Figures.Clear();
                this.pathGeometryCircle.Figures.Add(pfCircle);
            }
            else
            {
                var center = new Point(this.pathArc.Width / 2, this.pathArc.Height / 2);
                var circle = new EllipseGeometry(center, radius, radius);
                var pathgeo = circle.GetOutlinedPathGeometry();


                this.pathGeometryArc.Clear();
                this.pathGeometryCircle.Clear();
                if (angle == 0)
                    this.pathGeometryCircle.Figures = pathgeo.Figures;
                else
                    this.pathGeometryArc.Figures = pathgeo.Figures;
            }
        }


        #endregion

    }
}
