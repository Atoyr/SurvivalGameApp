using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.ServiceLocation;
using Prism.Unity;
using SurvivalGameApp.Main.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SurvivalGameApp.Main
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<Shell>();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            var catalog = (ModuleCatalog)this.ModuleCatalog;
            catalog.AddModule(typeof(MainModule));
        }

        protected override void InitializeShell()
        {
            // Shellを表示する
            ((Window)this.Shell).Show();
        }
    }
}
