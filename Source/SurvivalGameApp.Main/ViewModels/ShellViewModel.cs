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
        //private ApplicationContext applicationContext;
        //[Dependency]
        //public ApplicationContext ApplicationContext  { set => SetProperty(ref applicationContext, value); get => applicationContext; }
        
        public ShellViewModel()
        {
            //ApplicationContext = ApplicationContext.RoadSetting(@"config/applicationConfing.json");
        }
    }
}
