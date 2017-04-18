using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SurvivalGameApp.Main.Controls
{
    class SystemButtons : Control
    {
        static SystemButtons()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SystemButtons), new FrameworkPropertyMetadata(typeof(SystemButtons)));
        }
    }
}
