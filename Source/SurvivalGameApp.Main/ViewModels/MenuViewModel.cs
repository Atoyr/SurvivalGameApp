using SurvivalGameApp.Main.Abstract;
using SurvivalGameApp.Main.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Regions;

namespace SurvivalGameApp.Main.ViewModels
{
    public class MenuViewModel : AbstractViewModel
    {
        private ICommand command;
        public ICommand Command { set => SetProperty(ref command, value); get => command; }

        public MenuViewModel()
        {
            Command = UserCommand.BackOrCloseWindow;
        }

    }
}
