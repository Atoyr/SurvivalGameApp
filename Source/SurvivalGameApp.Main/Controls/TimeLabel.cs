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
using System.Windows.Threading;

namespace SurvivalGameApp.Main.Controls
{
    public class TimeLabel : Control
    {
        static TimeLabel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimeLabel), new FrameworkPropertyMetadata(typeof(TimeLabel)));
        }

        private DispatcherTimer DispatcherTimer { set; get; }

        public static readonly DependencyProperty NeedsToRunProperty = DependencyProperty.Register("NeedsToRun", typeof(bool), typeof(TimeLabel), new PropertyMetadata(false));
        public bool NeedsToRun { set => SetValue(NeedsToRunProperty, value); get => (bool)GetValue(NeedsToRunProperty); }

        public static readonly DependencyProperty TimeSpanProperty = DependencyProperty.Register("TimeSpan", typeof(TimeSpan), typeof(TimeLabel), new PropertyMetadata(TimeSpan.FromMilliseconds(500)));
        public TimeSpan TimeSpan { set => SetValue(TimeSpanProperty, value); get => (TimeSpan)GetValue(TimeSpanProperty); }

        //public static readonly DependencyProperty HourProperty = DependencyProperty.Register("Hour", typeof(string), typeof(TimeLabel), new PropertyMetadata(string.Empty));
        ////public string Hour { set => SetValue(HourProperty, value); get => (string)GetValue(HourProperty); }
        //public int Hour { set => SetValue(HourProperty, value.ToString()); get => int.Parse((string)GetValue(HourProperty)); }

        //public static readonly DependencyProperty MinuteStrProperty = DependencyProperty.Register("MinuteStr", typeof(string), typeof(TimeLabel), new PropertyMetadata(string.Empty));
        ////public string MinuteStr { set => SetValue(MinuteStrProperty, value); get => (string)GetValue(MinuteStrProperty); }
        //public int Minute { set => SetValue(MinuteStrProperty, value.ToString()); get => int.Parse((string)GetValue(MinuteStrProperty)); }
        //public static readonly DependencyProperty SecondProperty = DependencyProperty.Register("Second", typeof(string), typeof(TimeLabel), new PropertyMetadata(string.Empty));
        //public int Second { set => SetValue(SecondProperty, value.ToString()); get => int.Parse((string)GetValue(SecondProperty)); }

        private TextBlock PART_Hour;
        private TextBlock PART_HourCoron;
        private TextBlock PART_Minute;
        private TextBlock PART_MinuteCoron;
        private TextBlock PART_Second;
        private string coron;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            PART_Hour = (TextBlock)this.GetTemplateChild("PART_Hour");
            PART_HourCoron = (TextBlock)this.GetTemplateChild("PART_HourCoron");
            PART_Minute = (TextBlock)this.GetTemplateChild("PART_Minute");
            PART_MinuteCoron = (TextBlock)this.GetTemplateChild("PART_MinuteCoron");
            PART_Second = (TextBlock)this.GetTemplateChild("PART_Second");

            if (NeedsToRun)
            {
                DispatcherTimer = CreateTimer();
                DispatcherTimer.Tick += (sender, args) 
                    => {
                        var now = DateTime.Now;
                        this.PART_Hour.Text = now.Hour.ToString("D");
                        this.PART_HourCoron.Text = ":";
                        this.PART_Minute.Text = now.Minute.ToString("D2");
                        this.PART_MinuteCoron.Text = ":";
                        this.PART_Second.Text = now.Second.ToString("D2");
                    };
                DispatcherTimer.Start();
            }
        }

        /// <summary>
        /// タイマー生成処理
        /// </summary>
        /// <returns>生成したタイマー</returns>
        private DispatcherTimer CreateTimer() => new DispatcherTimer(DispatcherPriority.SystemIdle) { Interval = TimeSpan };
    }
}
