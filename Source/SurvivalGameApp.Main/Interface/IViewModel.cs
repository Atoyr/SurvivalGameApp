using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalGameApp.Main.Interface
{
    interface IViewModel : INavigationAware
    {
        [Dependency]
        IUnityContainer Container { get; set; }

        [Dependency]
        IEventAggregator EventAggregator { get; set; }

    }
}
