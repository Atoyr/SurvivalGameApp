using Microsoft.Practices.ServiceLocation;
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
        public static void GoBack(Regions region)
        {
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();

            // enumで制限しているためRegionは必ず存在する前提
            var journal = regionManager.Regions[region.Name()].NavigationService.Journal;
            if (journal.CanGoBack)
            {
                journal.GoBack();
            }
        }

        public static void GoForward(Regions region)
        {
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();

            // enumで制限しているためRegionは必ず存在する前提
            var journal = regionManager.Regions[region.Name()].NavigationService.Journal;
            if (journal.CanGoForward)
            {
                journal.GoForward();
            }
        }
    }
}
