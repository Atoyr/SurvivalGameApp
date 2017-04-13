using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace SurvivalGameApp.Main.Controls
{
    class TimeTextBlock : Control
    {
        static TimeTextBlock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimeTextBlock), new FrameworkPropertyMetadata(typeof(TimeTextBlock)));
        }


        private DispatcherTimer DispatcherTimer { set; get; }

        public static readonly DependencyProperty NeedsToRunProperty = DependencyProperty.Register("NeedsToRun", typeof(bool), typeof(TimeTextBlock), new PropertyMetadata(false));
        public bool NeedsToRun { set => SetValue(NeedsToRunProperty, value); get => (bool)GetValue(NeedsToRunProperty); }

        public static readonly DependencyProperty TimeSpanProperty = DependencyProperty.Register("TimeSpan", typeof(TimeSpan), typeof(TimeTextBlock), new PropertyMetadata(TimeSpan.FromMilliseconds(500)));
        public TimeSpan TimeSpan { set => SetValue(TimeSpanProperty, value); get => (TimeSpan)GetValue(TimeSpanProperty); }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.FontSize = 72;

            if (NeedsToRun)
            {
                DispatcherTimer = CreateTimer();
                DispatcherTimer.Tick += (sender, args)
                    => {
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
