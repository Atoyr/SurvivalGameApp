using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WpfApplication1
{
    partial class Logic
    {
        public int[] times;     // 爆発までの時間を格納する
        public int[] dispTimes; // 画面表示用時間オブジェクト

        private int timerPos = 0;

        public void initTimes()
        {
            times = new int[4];
            dispTimes = new int[4];

            for(int i = 0;i < times.Length; i++)
            {
                times[i] = 0;
            }
            timerPos = 0;

            this.copyIntArray(times, dispTimes);
        }

        public void AddTimer(int digit)
        {
            if(timerPos >= dispTimes.Length)
            {
                timerPos = 0;
            }
            if (digit < 0 || 9 < digit)
            {
                return;
            }
            if(timerPos == 2 && (digit < 0 || 6 < digit))
            {
                // 60秒以上は入れさせないための処理
                return;
            }
            dispTimes[timerPos] = digit;
            timerPos++;
        }

        public void GetNowSettingTimer()
        {
            this.copyIntArray(times,dispTimes);
        }


        public void UpdateTimer()
        {
            this.copyIntArray(dispTimes, times);
        }

        public int GetSettingTimerSec()
        {
            int retInt = 0;
            retInt += times[0] * 10 * 60;
            retInt += times[1] * 60;
            retInt += times[2] * 10;
            retInt += times[3];

            return retInt;
        }

        public void SetDispTimerSec(int sec)
        {
            int tempMin = sec / 60;
            int tempSec = sec % 60;

            dispTimes[0] = tempMin / 10;
            dispTimes[1] = tempMin % 10;
            dispTimes[2] = tempSec / 10;
            dispTimes[3] = tempSec % 10;
        }

    }
}
