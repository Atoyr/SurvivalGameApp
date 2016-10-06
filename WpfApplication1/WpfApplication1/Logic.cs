using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApplication1
{
    partial class Logic
    {
        public int[] passwords; // 設定パスワード
        public int[] inputPasswords; // 入力パスワード(解除時入力)
        private int inputPasswordPos = 0; // 入力パス現在位置

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Logic()
        {
            passwords = new int[12];
            inputPasswords = new int[12];
            initPasswords();
            initInputPasswords();
        }

        /// <summary>
        /// 設定パスワード初期化
        /// </summary>
        public void initPasswords()
        {
            this.initIntArray(passwords);
        }

        /// <summary>
        /// 入力パスワード初期化
        /// </summary>
        public void initInputPasswords()
        {
            this.initIntArray(inputPasswords);
            inputPasswordPos = 0;
        }

        /// <summary>
        /// 配列初期化処理(-1埋め)
        /// </summary>
        /// <param name="intArgs"></param>
        public void initIntArray(int[] intArgs)
        {
            for (int i = 0; i < intArgs.Length; i++)
            {
                intArgs[i] = -1;
            }
        }

        /// <summary>
        /// 配列コピー
        /// </summary>
        /// <param name="intArgs"></param>
        public void copyIntArray(int[] fromIntArgs,int[] toIntArgs)
        {
            for (int i = 0; i < fromIntArgs.Length; i++)
            {
                if (i < toIntArgs.Length )
                {
                    toIntArgs[i] = fromIntArgs[i];
                }
            }
        }

        /// <summary>
        /// パスワードが一致しているか確認
        /// </summary>
        /// <returns></returns>
        public bool IsExistsPassword()
        {
            bool isExists = true;

            for (int i = 0; i < passwords.Length; i++)
            {
                isExists = isExists && (passwords[i] == -1 || passwords[i] == inputPasswords[i]);
            }

            return isExists;
        }

        public void AddPassword(int digit)
        {
            if(digit < 0 || 9 < digit)
            {
                return;
            }
            if(inputPasswords.Length <= inputPasswordPos)
            {
                return;
            }
            inputPasswords[inputPasswordPos] = digit;
            inputPasswordPos++;
        }

        public void removePassword()
        {
            if(inputPasswordPos <= 0)
            {
                return;
            }
            inputPasswordPos--;
            inputPasswords[inputPasswordPos] = -1;
        }

        public void removeAllPassword()
        {
            this.initInputPasswords();
        }
    }
}
