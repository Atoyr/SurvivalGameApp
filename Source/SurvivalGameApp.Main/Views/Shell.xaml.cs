using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SurvivalGameApp.Main.Views
{
    /// <summary>
    /// Shell.xaml の相互作用ロジック
    /// </summary>
    public partial class Shell : Window
    {
        const int GWL_STYLE = -16;
        const int WS_SYSMENU = 0x00080000;


        public Shell()
        {
            InitializeComponent();
        }

        private void BindingSetting()
        {
            SetBinding(TitleProperty, "Title");
            SetBinding(WidthProperty, "Width");
            SetBinding(HeightProperty, "Height");
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            IntPtr handle = (new WindowInteropHelper(this)).Handle;
            var style = GetWindowLong(handle, GWL_STYLE);
            style &= (~WS_SYSMENU);
            SetWindowLong(handle, GWL_STYLE, style);
        }

        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
    }
}
