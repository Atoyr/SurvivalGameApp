using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Regions;
using SurvivalGameApp.Main.Interface;

namespace SurvivalGameApp.Main.Abstract
{
    public abstract class ViewModelBase : BindableBase, IViewModel
    {
        public IUnityContainer Container { get; set; }
        public IEventAggregator EventAggregator { get; set; }
 
        public virtual bool IsNavigationTarget(NavigationContext navigationContext) { return true; }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext) { }

        public virtual void OnNavigatedTo(NavigationContext navigationContext) { }
    }
}
