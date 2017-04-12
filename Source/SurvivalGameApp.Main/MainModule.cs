using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using SurvivalGameApp.Main.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalGameApp.Main
{
    public class MainModule : IModule
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        [Dependency]
        public IRegionManager RegionManager { get; set; }

        public void Initialize()
        {
            this.Container.RegisterType<object, MenuView>(nameof(MenuView));
        }
    }
}
