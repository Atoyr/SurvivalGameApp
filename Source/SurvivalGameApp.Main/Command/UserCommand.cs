using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SurvivalGameApp.Main.Command
{
    public static class UserCommand
    {
        public static ICommand BackOrCloseWindow { private set; get; } = new BackOrCloseWindowCommand();
    }
}
