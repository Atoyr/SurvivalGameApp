using System.Windows;

namespace SurvivalGameApp.Main.Controls
{
    public class GearIcon : Icon
    {

        static GearIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GearIcon), new FrameworkPropertyMetadata(typeof(GearIcon)));
        }
    }
}
