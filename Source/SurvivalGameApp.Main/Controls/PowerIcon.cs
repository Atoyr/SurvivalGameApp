using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SurvivalGameApp.Main.Controls
{
    public class PowerIcon : Control
    {
        static PowerIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PowerIcon), new FrameworkPropertyMetadata(typeof(PowerIcon)));
        }
    }
}
