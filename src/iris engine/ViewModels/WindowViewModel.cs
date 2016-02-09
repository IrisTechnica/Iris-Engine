using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Livet;
using MetroRadiance.UI;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace iris_engine.ViewModels
{
    internal class WindowViewModel : ViewModel
    {
        #region Title 変更通知プロパティ

        private string _Title;

        public string Title
        {
            get { return this._Title; }
            set
            {
                if (this._Title != value)
                {
                    this._Title = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        #endregion

        #region WindowState 変更通知プロパティ

        private WindowState _WindowState;

        public WindowState WindowState
        {
            get { return this._WindowState; }
            set
            {
                if (this._WindowState != value)
                {
                    this._WindowState = value;
                    this.IsMaximized = value == WindowState.Maximized;
                    this.CanNormalize = value == WindowState.Maximized;
                    this.CanMaximize = value == WindowState.Normal;
                    this.RaisePropertyChanged();
                }
            }
        }

        #endregion

        #region IsMaximized 変更通知プロパティ

        private bool _IsMaximized;

        public bool IsMaximized
        {
            get { return this._IsMaximized; }
            set
            {
                if (this._IsMaximized != value)
                {
                    this._IsMaximized = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        #endregion

        #region CanMaximize 変更通知プロパティ

        private bool _CanMaximize = true;

        public bool CanMaximize
        {
            get { return this._CanMaximize; }
            set
            {
                if (this._CanMaximize != value)
                {
                    this._CanMaximize = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        #endregion

        #region CanMinimize 変更通知プロパティ

        private bool _CanMinimize = true;

        public bool CanMinimize
        {
            get { return this._CanMinimize; }
            set
            {
                if (this._CanMinimize != value)
                {
                    this._CanMinimize = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        #endregion

        #region CanNormalize 変更通知プロパティ

        private bool _CanNormalize = false;

        public bool CanNormalize
        {
            get { return this._CanNormalize; }
            set
            {
                if (this._CanNormalize != value)
                {
                    this._CanNormalize = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        #endregion

        #region SampleNum 変更通知プロパティ

        private int _SampleNum;

        public int SampleNum
        {
            get { return this._SampleNum; }
            set
            {
                if (this._SampleNum != value)
                {
                    this._SampleNum = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        #endregion

        #region Menu 作成

        public ObservableCollection<MenuItem> Menus { get; private set; }
        private void MakeMenus()
        {
            // Makes some dummy menus to test with.
            Menus = new ObservableCollection<MenuItem>();

            var top = new MenuItem();
            top.Header = "ファイル(_F)";

            var new_project = new MenuItem();
            new_project.Header = "新規プロジェクト";
            new_project.InputGestureText = "Ctrl+N";
            new_project.CommandBindings.Add(new CommandBinding(ApplicationCommands.New));
            top.Items.Add(new_project);

            Menus.Add(top);

        }

        #endregion

        public WindowViewModel()
        {
            this.Title = "Iris Engine";

            ThemeService.Current.ChangeTheme(Theme.Light);
            ThemeService.Current.ChangeAccent(Accent.FromColor(Color.FromRgb(120, 220, 225)));

            MakeMenus();
            
        }

    }
}
