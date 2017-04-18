using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SurvivalGameApp.Main
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var bootstrapper = new Bootstrapper();
            if (e.Args is string[] args && args.Count() > 0)
            {
                bootstrapper.Run(args[0]);
            }
            else
            {
                bootstrapper.Run();
            }
        }
    }
}
