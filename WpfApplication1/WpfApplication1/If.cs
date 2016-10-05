using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;

namespace WpfApplication1
{
    public class If : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void SetProperty<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            field = value;
            var h = this.PropertyChanged;
            if (h != null) { h(this, new PropertyChangedEventArgs(propertyName)); }
        }

        private string name = "hogehoge";

        public string Name
        {
            get { return this.name; }
            set { this.SetProperty(ref this.name, value); }
        }

        private BitmapImage imgTimeKoron ;

        public BitmapImage ImgTimeKoron
        {
            get { return this.imgTimeKoron; }
            set { this.SetProperty(ref this.imgTimeKoron, value); }
        }
    }
}
