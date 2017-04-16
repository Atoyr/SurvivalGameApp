using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SurvivalGameApp.Main.Controls
{
    public class GearIcon : Control
    {

        static GearIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GearIcon), new FrameworkPropertyMetadata(typeof(GearIcon)));
        }

        //public static DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(GearIcon), new PropertyMetadata(new DelegateCommand(new Action(() => { }))));
        //public ICommand Command { set => SetValue(CommandProperty, value); get => (ICommand)GetValue(CommandProperty); }
    }
}
