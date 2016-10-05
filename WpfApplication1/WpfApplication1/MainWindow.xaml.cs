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

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private If wpfIf;
        private Logic wpfLogic;

        public MainWindow()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            wpfIf = new If();
            wpfLogic = new Logic();

            this.gird1.DataContext = wpfIf;
        }

        private void updatePasswordArea()
        {
            for(int i = 0; i < wpfLogic.passwords.Length; i++)
            {
                switch (wpfLogic.passwords[i])
                {
                    case 0:
                        wpfIf.ImgPasswords[i] = wpfIf.Segs[0];
                        break;
                    case 1:
                        wpfIf.ImgPasswords[i] = wpfIf.Segs[1];
                        break;
                    case 2:
                        wpfIf.ImgPasswords[i] = wpfIf.Segs[2];
                        break;
                    case 3:
                        wpfIf.ImgPasswords[i] = wpfIf.Segs[3];
                        break;
                    case 4:
                        wpfIf.ImgPasswords[i] = wpfIf.Segs[4];
                        break;
                    case 5:
                        wpfIf.ImgPasswords[i] = wpfIf.Segs[5];
                        break;
                    case 6:
                        wpfIf.ImgPasswords[i] = wpfIf.Segs[6];
                        break;
                    case 7:
                        wpfIf.ImgPasswords[i] = wpfIf.Segs[7];
                        break;
                    case 8:
                        wpfIf.ImgPasswords[i] = wpfIf.Segs[8];
                        break;
                    case 9:
                        wpfIf.ImgPasswords[i] = wpfIf.Segs[9];
                        break;
                    default:
                        wpfIf.ImgPasswords[i] = wpfIf.blank;
                        break;
                }
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            wpfLogic.passwords[0] = 1;
            this.updatePasswordArea();
        }
    }
}
