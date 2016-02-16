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
        
        private void MakeMenus()
        {

            //// Makes some dummy menus to test with.
            //Menus = new ObservableCollection<MenuItem>();
            //
            //var File = new MenuItem();
            //File.Header = "ファイル(_F)";
            //{ 
            //    var NewFile = new MenuItem();
            //    NewFile.Header = "新規作成";
            //    { 
            //        var new_file = new MenuItem();
            //        new_file.Header = "新規ファイル";
            //        new_file.InputGestureText = iris_engine.Shortcut.Default.New_File;
            //        new_file.CommandBindings.Add(new CommandBinding(ApplicationCommands.New));
            //
            //        var new_project = new MenuItem();
            //        new_project.Header = "新規プロジェクト";
            //        new_project.InputGestureText = iris_engine.Shortcut.Default.New_Project;
            //        new_project.CommandBindings.Add(new CommandBinding(ApplicationCommands.New));
            //
            //        NewFile.Items.Add(new_file);
            //        NewFile.Items.Add(new_project);
            //    }
            //
            //    var OpenFile = new MenuItem();
            //    OpenFile.Header = "開く";
            //    {
            //        var open_file = new MenuItem();
            //        open_file.Header = "ファイルを開く";
            //        open_file.InputGestureText = iris_engine.Shortcut.Default.Open_File;
            //        open_file.CommandBindings.Add(new CommandBinding(ApplicationCommands.Open));
            //
            //        var open_project = new MenuItem();
            //        open_project.Header = "プロジェクトを開く";
            //        open_project.InputGestureText = iris_engine.Shortcut.Default.Open_Project;
            //        open_project.CommandBindings.Add(new CommandBinding(ApplicationCommands.Open));
            //        
            //        OpenFile.Items.Add(open_file);
            //        OpenFile.Items.Add(open_project);
            //    }
            //    
            //    File.Items.Add(NewFile);
            //    File.Items.Add(OpenFile);
            //}
            //Menus.Add(File);
            //
            //
            //var Edit = new MenuItem();
            //Edit.Header = "編集(_E)";
            //{
            //
            //}
            //Menus.Add(Edit);
            //
            //
            //var View = new MenuItem();
            //View.Header = "表示(_V)";
            //{
            //    var open_project = new MenuItem();
            //    open_project.Header = "プロジェクトを開く";
            //    open_project.InputGestureText = iris_engine.Shortcut.Default.Open_Project;
            //    open_project.CommandBindings.Add(new CommandBinding(ApplicationCommands.Open));
            //
            //    OpenFile.Items.Add(open_file);
            //
            //}
            //Menus.Add(View);
            //
            //
            //var Project = new MenuItem();
            //Project.Header = "プロジェクト(_P)";
            //{
            //    //プロジェクトの設定等のウィンドウを出す
            //}
            //Menus.Add(Project);
            //
            //var Build = new MenuItem();
            //Build.Header = "ビルド(_B)";
            //{
            //
            //}
            //Menus.Add(Build);
            //
            //var Debug = new MenuItem();
            //Debug.Header = "デバッグ(_D)";
            //{
            //
            //}
            //Menus.Add(Debug);
            //
            ////外部ツール等に繋げるかもしれないのでとりあえず
            ///*
            //var Tool = new MenuItem();
            //Tool.Header = "ツール(_T)";
            //{
            //
            //}
            //Menus.Add(Tool);
            //*/
            //
            //var NetWork = new MenuItem();
            //NetWork.Header = "ネットワーク(_N)";
            //{
            //    //接続先一覧
            //    //
            //    //
            //    //
            //    //
            //    //
            //}
            //Menus.Add(NetWork);


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
