using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SurvivalGameApp.Main.Controls
{
    public class CaptionBar : ContentControl
    {
        static CaptionBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CaptionBar), new FrameworkPropertyMetadata(typeof(CaptionBar)));
        }
    }
}
