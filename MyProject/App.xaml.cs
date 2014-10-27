using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace MyProject
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            Application.Current.ShutdownMode = System.Windows.ShutdownMode.OnExplicitShutdown;
            Login myLogin = new Login();
            bool? b=myLogin.ShowDialog();
            if ((b.HasValue == true) && (b.Value == true))
            {
                Application.Current.ShutdownMode = System.Windows.ShutdownMode.OnMainWindowClose;
            }
            else
            {
                Application.Current.Shutdown();
            }
        }
    }
}
