using Microsoft.Practices.ServiceLocation;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace SurvivalGameApp.Main.Common
{
    public enum Regions
    {
        MainRegion
    } 

    public static class RegionsExtensions
    {
        public static string Name(this Regions e)
        {
            return e.ToString();
        }
    }

    public static class NavigationHelper
    {
        public static void LoadModule(string ModuleName)
        {
            var moduleManager = ServiceLocator.Current.GetInstance<IModuleManager>();
            moduleManager.LoadModule(ModuleName);
        }

        public static void GoNavigate(string source)
        {
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            regionManager.RequestNavigate(Regions.MainRegion.Name() , source);
        }

        public static void GoNavigate(string moduleName, string source)
        {
            LoadModule(moduleName);
            GoNavigate(source);
        }

        public static bool GoBack(Regions region)
        {
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();

            // enumで制限しているためRegionは必ず存在する前提
            var journal = regionManager.Regions[region.Name()].NavigationService.Journal;
            if (journal.CanGoBack)
            {
                journal.GoBack();
                return true;
            }
            return false;
        }

        public static bool GoForward(Regions region)
        {
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();

            // enumで制限しているためRegionは必ず存在する前提
            var journal = regionManager.Regions[region.Name()].NavigationService.Journal;
            if (journal.CanGoForward)
            {
                journal.GoForward();
                return true;
            }
            return false;
        }
    }
}
