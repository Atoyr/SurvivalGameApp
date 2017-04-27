using Microsoft.Practices.Unity;
using SurvivalGameApp.Main.Abstract;
using SurvivalGameApp.Main.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurvivalGameApp.Main.ViewModels
{
    class ShellViewModel : AbstractViewModel
    {
        private ApplicationContext applicationContext;
        [Dependency]
        public ApplicationContext ApplicationContext { set => SetProperty(ref applicationContext, value); get => applicationContext; }

        public ShellViewModel()
        {
            ApplicationContext = ApplicationContext.RoadSetting(@"config/applicationConfing.json");
            if (ApplicationContext.ModuleList == null) ApplicationContext.ModuleList = new List<ModuleInfo>();
            ApplicationContext.ModuleList.Add(new ModuleInfo());
            ApplicationContext.SaveSetting(@"config/applicationConfing.json");
        }
    }
}
