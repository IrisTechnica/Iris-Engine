using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace iris_engine.Controls
{
    public class ExtendToolBar : ToolBar
    {
        public static readonly DependencyProperty OverflowButtonBackgroundProperty =
        DependencyProperty.Register("OverflowButtonBackground",
                                    typeof(Brush),
                                    typeof(ExtendToolBar),
                                    new PropertyMetadata(ColorUpdate));

        public static readonly DependencyProperty OverflowButtonVisibilityProperty =
            DependencyProperty.Register("OverflowButtonVisibility",
                                    typeof(Visibility),
                                    typeof(ExtendToolBar),
                                    new PropertyMetadata(Visibility.Visible));

        public Brush overflowPanelBackground = OverflowButtonBackgroundProperty.DefaultMetadata.DefaultValue as Brush;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var overflowGrid = base.Template.FindName("OverflowGrid", this) as Grid;
            if (overflowGrid != null)
            {
                overflowGrid.Visibility = OverflowButtonVisibility;
            }

            var overflowButton = base.Template.FindName("OverflowButton", this) as ToggleButton;
            if (overflowButton != null)
            {
                overflowButton.Background = OverflowButtonBackground ?? Background;
            }

            var overflowPanel = base.GetTemplateChild("PART_ToolBarOverflowPanel") as ToolBarOverflowPanel;
            if (overflowPanel != null)
            {
                overflowPanel.Background = OverflowButtonBackground ?? Background;
                overflowPanel.Margin = new Thickness(0);
            }

        }

        private static void ColorUpdate(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var toolbar = d as ExtendToolBar;
            if (toolbar == null) return;

            toolbar.overflowPanelBackground = e.NewValue as Brush ?? toolbar.Background;

        }

        public Brush OverflowButtonBackground
        {
            get { return overflowPanelBackground; }
            set { SetValue(OverflowButtonBackgroundProperty, value); }
        }

        public Visibility OverflowButtonVisibility
        {
            get { return (Visibility)GetValue(OverflowButtonVisibilityProperty); }
            set { SetValue(OverflowButtonVisibilityProperty, value); }
        }


    }
}
