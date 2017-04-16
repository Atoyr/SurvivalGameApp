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

        public static readonly DependencyProperty NeedsToRunProperty = DependencyProperty.Register("NeedsToRun", typeof(bool), typeof(TimeLabel), new PropertyMetadata(false, ChangedNeedToRunProperty));
        public bool NeedsToRun { set => SetValue(NeedsToRunProperty, value); get => (bool)GetValue(NeedsToRunProperty); }
        private static void ChangedNeedToRunProperty(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is TimeLabel label && e.NewValue is bool needToRun)
            {
                if (needToRun)
                {
                    label.DispatcherTimer.Start();
                }
                else
                {
                    label.DispatcherTimer.Stop();
                }
            }
        }

        public static readonly DependencyProperty FontColorProperty = DependencyProperty.Register("FontColor", typeof(Brush), typeof(TimeLabel), new PropertyMetadata(Brushes.Black, ChangedFontColorProperty));
        public Brush FontColor { set => SetValue(FontColorProperty, value); get => (Brush)GetValue(FontColorProperty); }
        private static void ChangedFontColorProperty(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is TimeLabel label && e.NewValue is Brush fontColor)
            {
                label.Foreground = fontColor;
            }
        }

        public static readonly DependencyProperty IntervalProperty = DependencyProperty.Register("Interval", typeof(TimeSpan), typeof(TimeLabel), new PropertyMetadata(TimeSpan.FromMilliseconds(500)));
        public TimeSpan Interval { set => SetValue(IntervalProperty, value); get => (TimeSpan)GetValue(IntervalProperty); }
        private static void ChangedTimeSpanProperty(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TimeLabel label && e.NewValue is TimeSpan interval)
            {
                label.DispatcherTimer.Interval = interval;
            }
        }

        public static new readonly DependencyProperty FontSizeProperty = DependencyProperty.Register("FontSize", typeof(double), typeof(TimeLabel), new FrameworkPropertyMetadata(72d,FrameworkPropertyMetadataOptions.None));
        public new double FontSize { private set => SetValue(FontSizeProperty, value); get => (double)GetValue(FontSizeProperty); }

        private TextBlock PART_TextBlock;

        public TimeLabel()
        {
            DispatcherTimer = CreateTimer();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            PART_TextBlock = (TextBlock)this.GetTemplateChild("PART_TextBlock");
            PART_TextBlock.Foreground = FontColor;
            PART_TextBlock.FontSize = 72;

            // フォントの読み込み
            //foreach (FontFamily fontFamily in Fonts.GetFontFamilies(new Uri("pack://application:,,,/SurvivalGameApp.Main/"), "./Resources/"))
            //{
            //    // Perform action.
            //}

            DispatcherTimer.Tick += (sender, args) 
                => {
                    PART_TextBlock.Text = DateTime.Now.ToString("HH:mm");
                };
        }

        /// <summary>
        /// タイマー生成処理
        /// </summary>
        /// <returns>生成したタイマー</returns>
        private DispatcherTimer CreateTimer() => new DispatcherTimer(DispatcherPriority.SystemIdle) { Interval = this.Interval };
    }
}
