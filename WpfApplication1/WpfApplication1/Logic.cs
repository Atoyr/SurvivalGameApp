using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Logic
    {
        public int[] passwords;


        public Logic()
        {
            passwords = new int[12];
            this.initPasswords();
        }

        public void initPasswords()
        {
            for (int i = 0; i < passwords.Length; i++)
            {
                    passwords[i] = -1;
            }
        }

        public async void TimeCount()
        {
            await Task.Run(() =>
           {
               Thread.Sleep(5000);
           });
        }
    }
}
