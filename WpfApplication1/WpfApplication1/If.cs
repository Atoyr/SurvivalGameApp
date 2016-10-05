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
        // 必須項目
        public event PropertyChangedEventHandler PropertyChanged;

        private void SetProperty<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            field = value;
            var h = this.PropertyChanged;
            if (h != null) { h(this, new PropertyChangedEventArgs(propertyName)); }
        }

        // イメージ関連

        public BitmapImage segImg1;
        public BitmapImage segImg2;
        public BitmapImage segImg3;
        public BitmapImage segImg4;
        public BitmapImage segImg5;
        public BitmapImage segImg6;
        public BitmapImage segImg7;
        public BitmapImage segImg8;
        public BitmapImage segImg9;
        public BitmapImage segImg0;
        public BitmapImage segImgKoron;
        public BitmapImage segImgAsuta;
        public BitmapImage blank;

        public BitmapImage[] Segs;
        public BitmapImage[] ImgPasswords;

        public If()
        {
            segImg0 = new BitmapImage(new Uri("pack://application:,,,/resource/0.png"));
            segImg1 = new BitmapImage(new Uri("pack://application:,,,/resource/1.png"));
            segImg2 = new BitmapImage(new Uri("pack://application:,,,/resource/2.png"));
            segImg3 = new BitmapImage(new Uri("pack://application:,,,/resource/3.png"));
            segImg4 = new BitmapImage(new Uri("pack://application:,,,/resource/4.png"));
            segImg5 = new BitmapImage(new Uri("pack://application:,,,/resource/5.png"));
            segImg6 = new BitmapImage(new Uri("pack://application:,,,/resource/6.png"));
            segImg7 = new BitmapImage(new Uri("pack://application:,,,/resource/7.png"));
            segImg8 = new BitmapImage(new Uri("pack://application:,,,/resource/8.png"));
            segImg9 = new BitmapImage(new Uri("pack://application:,,,/resource/9.png"));
            segImgKoron = new BitmapImage(new Uri("pack://application:,,,/resource/koron.png"));
            segImgAsuta = new BitmapImage(new Uri("pack://application:,,,/resource/Asuta.png"));
            blank = new BitmapImage(new Uri("pack://application:,,,/resource/blank.png"));

            // パスワード関連
            ImgPassword0 = blank;
            ImgPassword1 = blank;
            ImgPassword2 = blank;
            ImgPassword3 = blank;
            ImgPassword4 = blank;
            ImgPassword5 = blank;
            ImgPassword6 = blank;
            ImgPassword7 = blank;
            ImgPassword8 = blank;
            ImgPassword9 = blank;

            // 時間関連初期値設定
            ImgTimeTenPosHour = segImg0;
            ImgTimeOnePosHour = segImg0;
            ImgTimeKoron = segImgKoron;
            ImgTimeTenPosMin = segImg0;
            ImgTimeOnePosMin = segImg0;

            // 数字関連は配列にする
            Segs = new BitmapImage[10];
            Segs[0] = segImg0;
            Segs[1] = segImg1;
            Segs[2] = segImg2;
            Segs[3] = segImg3;
            Segs[4] = segImg4;
            Segs[5] = segImg5;
            Segs[6] = segImg6;
            Segs[7] = segImg7;
            Segs[8] = segImg8;
            Segs[9] = segImg9;

            ImgPasswords = new BitmapImage[12];
            ImgPasswords[0] = ImgPassword0;
            ImgPasswords[1] = ImgPassword1;
            ImgPasswords[2] = ImgPassword2;
            ImgPasswords[3] = ImgPassword3;
            ImgPasswords[4] = ImgPassword4;
            ImgPasswords[5] = ImgPassword5;
            ImgPasswords[6] = ImgPassword6;
            ImgPasswords[7] = ImgPassword7;
            ImgPasswords[8] = ImgPassword8;
            ImgPasswords[9] = ImgPassword9;
            ImgPasswords[10] = ImgPassword10;
            ImgPasswords[11] = ImgPassword11;

        }

        // パスワードIF
        private BitmapImage imgPassword0;
        public BitmapImage ImgPassword0
        {
            get { return this.imgPassword0; }
            set { this.SetProperty(ref this.imgPassword0, value); }
        }
        private BitmapImage imgPassword1;
        public BitmapImage ImgPassword1
        {
            get { return this.imgPassword1; }
            set { this.SetProperty(ref this.imgPassword1, value); }
        }
        private BitmapImage imgPassword2;
        public BitmapImage ImgPassword2
        {
            get { return this.imgPassword2; }
            set { this.SetProperty(ref this.imgPassword2, value); }
        }
        private BitmapImage imgPassword3;
        public BitmapImage ImgPassword3
        {
            get { return this.imgPassword3; }
            set { this.SetProperty(ref this.imgPassword3, value); }
        }
        private BitmapImage imgPassword4;
        public BitmapImage ImgPassword4
        {
            get { return this.imgPassword4; }
            set { this.SetProperty(ref this.imgPassword4, value); }
        }
        private BitmapImage imgPassword5;
        public BitmapImage ImgPassword5
        {
            get { return this.imgPassword5; }
            set { this.SetProperty(ref this.imgPassword5, value); }
        }
        private BitmapImage imgPassword6;
        public BitmapImage ImgPassword6
        {
            get { return this.imgPassword6; }
            set { this.SetProperty(ref this.imgPassword6, value); }
        }
        private BitmapImage imgPassword7;
        public BitmapImage ImgPassword7
        {
            get { return this.imgPassword7; }
            set { this.SetProperty(ref this.imgPassword7, value); }
        }
        private BitmapImage imgPassword8;
        public BitmapImage ImgPassword8
        {
            get { return this.imgPassword8; }
            set { this.SetProperty(ref this.imgPassword8, value); }
        }
        private BitmapImage imgPassword9;
        public BitmapImage ImgPassword9
        {
            get { return this.imgPassword9; }
            set { this.SetProperty(ref this.imgPassword9, value); }
        }
        private BitmapImage imgPassword10;
        public BitmapImage ImgPassword10
        {
            get { return this.imgPassword10; }
            set { this.SetProperty(ref this.imgPassword10, value); }
        }
        private BitmapImage imgPassword11;
        public BitmapImage ImgPassword11
        {
            get { return this.imgPassword11; }
            set { this.SetProperty(ref this.imgPassword11, value); }
        }


        // 時間関連IF
        private BitmapImage imgTimeTenPosHour;
        public BitmapImage ImgTimeTenPosHour
        {
            get { return this.imgTimeTenPosHour; }
            set { this.SetProperty(ref this.imgTimeTenPosHour, value); }
        }

        private BitmapImage imgTimeOnePosHour;
        public BitmapImage ImgTimeOnePosHour
        {
            get { return this.imgTimeOnePosHour; }
            set { this.SetProperty(ref this.imgTimeOnePosHour, value); }
        }

        private BitmapImage imgTimeKoron ;
        public BitmapImage ImgTimeKoron
        {
            get { return this.imgTimeKoron; }
            set { this.SetProperty(ref this.imgTimeKoron, value); }
        }

        private BitmapImage imgTimeTenPosMin;
        public BitmapImage ImgTimeTenPosMin
        {
            get { return this.imgTimeTenPosMin; }
            set { this.SetProperty(ref this.imgTimeTenPosMin, value); }
        }
        private BitmapImage imgTimeOnePosMin;
        public BitmapImage ImgTimeOnePosMin
        {
            get { return this.imgTimeOnePosMin; }
            set { this.SetProperty(ref this.imgTimeOnePosMin, value); }
        }
    }
}
