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
        /// <summary>
        /// Region名に変換
        /// これいる？
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string Name(this Regions e)
        {
            return e.ToString();
        }
    }

    /// <summary>
    /// RegionのNavigationヘルパー
    /// </summary>
    public static class NavigationHelper
    {
        public static void LoadModule(string ModuleName)
        {
            var moduleManager = ServiceLocator.Current.GetInstance<IModuleManager>();
            moduleManager?.LoadModule(ModuleName);
        }

        public static void GoNavigate(Regions region, string source)
        {
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            regionManager?.RequestNavigate(region.Name(), source);
        }

        public static void GoNavigate(Regions region, string source, NavigationParameters param)
        {
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            regionManager?.RequestNavigate(region.Name(), source, param);
        }

        public static void GoNavigate(Regions region, string source, Action<NavigationResult> navigationCallback)
        {
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            regionManager?.RequestNavigate(region.Name(), source, navigationCallback);
        }

        public static void GoNavigate(Regions region, string source, Action<NavigationResult> navigationCallback, NavigationParameters param)
        {
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            regionManager?.RequestNavigate(region.Name(), source, navigationCallback, param);
        }

        public static void GoNavigate(string source) => GoNavigate(Regions.MainRegion, source);

        public static void GoNavigate(string source, NavigationParameters param) => GoNavigate(Regions.MainRegion, source, param);

        public static void GoNavigate(string source, Action<NavigationResult> navigationCallback) => GoNavigate(Regions.MainRegion, source, navigationCallback);

        public static void GoNavigate(string source, Action<NavigationResult> navigationCallback, NavigationParameters param) => GoNavigate(Regions.MainRegion, source, navigationCallback, param);

        public static void GoNavigate(Regions region, string module ,string source)
        {
            LoadModule(module);
            GoNavigate(region, source);
        }

        public static void GoNavigate(Regions region, string module, string source, NavigationParameters param)
        {
            LoadModule(module);
            GoNavigate(region, source, param);
        }

        public static void GoNavigate(Regions region, string module, string source, Action<NavigationResult> navigationCallback)
        {
            LoadModule(module);
            GoNavigate(region, source, navigationCallback);
        }

        public static void GoNavigate(Regions region, string module, string source, Action<NavigationResult> navigationCallback, NavigationParameters param)
        {
            LoadModule(module);
            GoNavigate(region, source, navigationCallback, param);
        }

        public static bool GoBack(Regions region)
        {
            var regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();

            // enumで制限しているためRegionは必ず存在する前提
            var journal = regionManager?.Regions[region.Name()].NavigationService.Journal;
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
            var journal = regionManager?.Regions[region.Name()].NavigationService.Journal;
            if (journal.CanGoForward)
            {
                journal.GoForward();
                return true;
            }
            return false;
        }
    }
}
