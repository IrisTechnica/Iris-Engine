using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MetroRadiance.UI;

namespace iris_engine
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App
    {
        private SplashScreen splash = null;

        public App() : base()
        {
            splash = new SplashScreen("resources/splash.png");
            splash.Show(false);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ThemeService.Current.Register(this, Theme.Light, Accent.Blue);
        }

        #region 二重起動チェック

        private static System.Threading.Mutex mutex;

        public SplashScreen Splash
        {
            get
            {
                return splash;
            }

            set
            {
                splash = value;
            }
        }

        private void AppStartup(object sender, StartupEventArgs e)
        {
            /* 名前を指定してMutexを生成 */
            mutex = new System.Threading.Mutex(false, "iris_engine_mutex");

            /* 二重起動をチェック */
            if (!mutex.WaitOne(0, false))
            {
                /* 二重起動の場合はエラーを表示して終了 */
                MessageBox.Show("すでに起動されています");

                /* Mutexを破棄 */
                mutex.Close();
                mutex = null;

                /* 起動を中止してプログラムを終了 */
                this.Shutdown();
            }
        }

        private void AppExit(object sender, ExitEventArgs e)
        {
            if (mutex != null)
            {
                /* Mutexを解放 */
                mutex.ReleaseMutex();

                /* Mutexを破棄 */
                mutex.Close();
            }
        }

        #endregion
    }
}
