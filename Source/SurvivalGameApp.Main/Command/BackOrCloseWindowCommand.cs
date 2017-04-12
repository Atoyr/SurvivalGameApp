using Microsoft.Practices.ServiceLocation;
using SurvivalGameApp.Main.Common;
using System;
using System.Windows;
using System.Windows.Input;

namespace SurvivalGameApp.Main.Command
{
    class BackOrCloseWindowCommand : ICommand
    {
        Regions region = Regions.MainRegion;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (!NavigationHelper.GoBack(region))
            {
                ServiceLocator.Current.GetInstance<Window>().Close();
            }
        }
    }
}