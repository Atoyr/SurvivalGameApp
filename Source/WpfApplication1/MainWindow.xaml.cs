using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private If wpfIf;
        private Logic wpfLogic;

        private int mode = 0;
        private int viewMode = 0;
        private int cursor = 0;
        private int openSettingButtonPushCount = 0;
        private int timeCounter;
        private int soundBeepBase = SOUND_SPEED_NOMAL;// timeCounter%soundBeepBaseが0のときビープ音を鳴らす

        // 起動モード遷移
        private const int MODE_WAIT = 0;
        private const int MODE_EXECUTE = 1;
        private const int MODE_END = 2;

        // 画面モード遷移
        private const int VIEWMODE_NOMAL = 0;
        private const int VIEWMODE_SETTING = 1;

        // cursor遷移
        private const int CURSOR_PASSWORD = 0;
        private const int CURSOR_TIMER = 1;

        // 音関連
        private const int SOUND_SPEED_NOMAL = 10;
        private const int SOUND_SPEED_FAST = 5;
        private const int SOUND_SPEED_VERYFAST = 2;
        public string BeepSoundPath = @"\beep.mp3";
        public string BombSoundPath = @"\bomb.mp3";
        public string KeyDownSoundPath = @"\key.mp3";
        public string ErrorSoundPath = @"\Error.mp3";

        private bool isButtonEnable = true;

        // 画面モード遷移 格納
        // 値格納時に表示切替を行う
        public int ViewMode
        {
            set
            {
                switch (value)
                {
                    case VIEWMODE_NOMAL:
                    case VIEWMODE_SETTING:
                        viewMode = value;
                        this.ChangeViewMode();
                        break;
                    default:
                        break;
                }
            }
            get { return viewMode; }
        }


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
            viewMode = VIEWMODE_NOMAL;
            mode = MODE_WAIT;
            openSettingButtonPushCount = 0;

            // 音楽を流せるようにする
            Microsoft.SmallBasic.Library.Sound.PlayChimes();

            // 音楽ファイルのパスを取得
            Assembly myAssembly = Assembly.GetEntryAssembly();
            string path = System.IO.Path.GetDirectoryName(myAssembly.Location);

            BeepSoundPath = path + BeepSoundPath;
            BombSoundPath = path + BombSoundPath;
            KeyDownSoundPath = path + KeyDownSoundPath;
            ErrorSoundPath = path + ErrorSoundPath;
        }

        // 表示更新関連
        private void updatePasswordArea()
        {
            if (viewMode == VIEWMODE_SETTING)
            {
                for (int i = 0; i < wpfLogic.inputPasswords.Length; i++)
                {
                    wpfIf.SetPasswordSeg(i, wpfLogic.inputPasswords[i]);
                }
            }
            else if (viewMode == VIEWMODE_NOMAL)
            {
                for (int i = 0; i < wpfLogic.inputPasswords.Length; i++)
                {
                    // 値が-1の場合はブランク、それ以外は*で表示
                    wpfIf.SetPasswordSeg(i, wpfLogic.inputPasswords[i] != -1);
                }
            }
        }

        private void updateTimerArea()
        {
            if (viewMode == VIEWMODE_SETTING)
            {
                for (int i = 0; i < wpfLogic.dispTimes.Length; i++)
                {
                    wpfIf.SetTimerSeg(i, wpfLogic.dispTimes[i]);
                }
            }
        }

        #region テンキーボタン関連操作
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.SmallBasic.Library.Sound.Stop(KeyDownSoundPath);
            Microsoft.SmallBasic.Library.Sound.Play(KeyDownSoundPath);
            Button b = (Button)sender;
            switch (b.Name)
            {
                case "Button0":
                    this.PushDigitKey(0);
                    break;
                case "Button1":
                    this.PushDigitKey(1);
                    break;
                case "Button2":
                    this.PushDigitKey(2);
                    break;
                case "Button3":
                    this.PushDigitKey(3);
                    break;
                case "Button4":
                    this.PushDigitKey(4);
                    break;
                case "Button5":
                    this.PushDigitKey(5);
                    break;
                case "Button6":
                    this.PushDigitKey(6);
                    break;
                case "Button7":
                    this.PushDigitKey(7);
                    break;
                case "Button8":
                    this.PushDigitKey(8);
                    break;
                case "Button9":
                    this.PushDigitKey(9);
                    break;
            }
        }

        private void ButtonC_Click(object sender, RoutedEventArgs e)
        {
            wpfLogic.removeAllPassword();
            this.updatePasswordArea();
        }

        private void ButtonEnt_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.SmallBasic.Library.Sound.Stop(KeyDownSoundPath);
            Microsoft.SmallBasic.Library.Sound.Play(KeyDownSoundPath);
            this.ExecEnterKey();
        }


        #region ボタン表示関連
        private void ButtonDisable()
        {
            Button0.IsEnabled = false;
            Button1.IsEnabled = false;
            Button2.IsEnabled = false;
            Button3.IsEnabled = false;
            Button4.IsEnabled = false;
            Button5.IsEnabled = false;
            Button6.IsEnabled = false;
            Button7.IsEnabled = false;
            Button8.IsEnabled = false;
            Button9.IsEnabled = false;
            ButtonC.IsEnabled = false;
            ButtonEnt.IsEnabled = false;
            isButtonEnable = false;
        }

        private void ButtonEnable()
        {
            Button0.IsEnabled = true;
            Button1.IsEnabled = true;
            Button2.IsEnabled = true;
            Button3.IsEnabled = true;
            Button4.IsEnabled = true;
            Button5.IsEnabled = true;
            Button6.IsEnabled = true;
            Button7.IsEnabled = true;
            Button8.IsEnabled = true;
            Button9.IsEnabled = true;
            ButtonC.IsEnabled = true;
            ButtonEnt.IsEnabled = true;
            isButtonEnable = true;
        }
        #endregion
        #endregion

        private void ChangeViewMode()
        {
            switch (viewMode)
            {
                case VIEWMODE_NOMAL:
                    this.TimeArea.Visibility = Visibility.Hidden;
                    this.SettingArea.Visibility = Visibility.Hidden;
                    this.ButtonEnable();
                    break;
                case VIEWMODE_SETTING:
                    wpfLogic.GetNowSettingTimer();
                    this.updateTimerArea();
                    this.TimeArea.Visibility = Visibility.Visible;
                    this.SettingArea.Visibility = Visibility.Visible;
                    this.ButtonEnable();
                    break;
            }

        }


        // キーボード操作
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (isButtonEnable)
            {
                Microsoft.SmallBasic.Library.Sound.Stop(KeyDownSoundPath);
                Microsoft.SmallBasic.Library.Sound.Play(KeyDownSoundPath);
                switch (e.Key)
                {
                    //矢印キーが押されたことを表示する
                    case Key.D0:
                        this.PushDigitKey(0);
                        break;
                    case Key.D1:
                        this.PushDigitKey(1);
                        break;
                    case Key.D2:
                        this.PushDigitKey(2);
                        break;
                    case Key.D3:
                        this.PushDigitKey(3);
                        break;
                    case Key.D4:
                        this.PushDigitKey(4);
                        break;
                    case Key.D5:
                        this.PushDigitKey(5);
                        break;
                    case Key.D6:
                        this.PushDigitKey(6);
                        break;
                    case Key.D7:
                        this.PushDigitKey(7);
                        break;
                    case Key.D8:
                        this.PushDigitKey(8);
                        break;
                    case Key.D9:
                        this.PushDigitKey(9);
                        break;
                    case Key.Back:
                        wpfLogic.removePassword();
                        break;
                    case Key.Delete:
                        wpfLogic.removeAllPassword();
                        break;
                    case Key.Enter:
                        this.ExecEnterKey();
                        break;
                    default:
                        break;
                }
            }
        }

        // Enterキー押下時操作
        private void ExecEnterKey()
        {
            switch (ViewMode)
            {
                case VIEWMODE_NOMAL:
                    if (mode == MODE_WAIT)
                    {
                        // 待機時
                        this.ExecTimer();
                        // 実行中にする
                        mode = MODE_EXECUTE;
                    }
                    else if (mode == MODE_EXECUTE)
                    {
                        // 爆弾実行時
                        if (wpfLogic.IsExistsPassword())
                        {
                            // パスクリア処理
                            this.ExecBombClear();
                            wpfIf.IsLightRed = false;
                            mode = MODE_END;
                        }else
                        {
                            // パスワード不一致
                            this.ExecBombError();
                        }
                    }
                    else if (mode == MODE_END)
                    {
                        // ゲーム終了後
                        wpfIf.IsLightRed = false;
                        wpfIf.IsLightBlue = false;
                        wpfLogic.GetNowSettingTimer();
                        mode = MODE_WAIT;
                    }
                    break;
                case VIEWMODE_SETTING:
                    if (cursor == CURSOR_PASSWORD)
                    {
                        //パスワードエリア選択時
                        wpfLogic.copyIntArray(wpfLogic.inputPasswords, wpfLogic.passwords);
                        wpfLogic.initInputPasswords();
                        this.updatePasswordArea();
                    }
                    else if (cursor == CURSOR_TIMER)
                    {
                        //時計エリア選択時
                        wpfLogic.UpdateTimer();
                        this.updateTimerArea();
                    }

                    // 設定後はパスワードにカーソルをあわせる
                    cursor = CURSOR_PASSWORD;
                    break;
                default:
                    break;
            }
        }

        // 数字入力時
        private void PushDigitKey(int digit)
        {
            switch (ViewMode)
            {
                case VIEWMODE_NOMAL:
                    wpfLogic.AddPassword(digit);
                    this.updatePasswordArea();
                    break;
                case VIEWMODE_SETTING:
                    // 実行中のときは触らせない！
                    if (mode != MODE_EXECUTE)
                    {
                        if (cursor == CURSOR_PASSWORD)
                        {
                            wpfLogic.AddPassword(digit);
                            this.updatePasswordArea();
                        }
                        else if (cursor == CURSOR_TIMER)
                        {
                            wpfLogic.AddTimer(digit);
                            this.updateTimerArea();
                        }
                    }
                    break;
                default:
                    break;
            }

            
        }


        // 設定画面関連
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewMode == VIEWMODE_SETTING)
            {
                cursor = CURSOR_TIMER;
            }
            else
            {
                cursor = CURSOR_PASSWORD;
            }
        }

        // エラー処理
        private void ExecBombError()
        {
            Microsoft.SmallBasic.Library.Sound.Stop(BeepSoundPath);
            Microsoft.SmallBasic.Library.Sound.Stop(BombSoundPath);
            Microsoft.SmallBasic.Library.Sound.Stop(KeyDownSoundPath);
            Microsoft.SmallBasic.Library.Sound.Stop(ErrorSoundPath);

            Microsoft.SmallBasic.Library.Sound.Play(ErrorSoundPath);
        }


        // クリア処理
        private void ExecBombClear()
        {
            TimerStop();
            TimerReset();
            Microsoft.SmallBasic.Library.Sound.Stop(BeepSoundPath);
            Microsoft.SmallBasic.Library.Sound.Stop(BombSoundPath);
            Microsoft.SmallBasic.Library.Sound.Stop(KeyDownSoundPath);
            Microsoft.SmallBasic.Library.Sound.Stop(ErrorSoundPath);

            wpfIf.IsLightBlue = true;
        }

        // 爆破処理
        private void ExecBomb()
        {
            this.ButtonDisable();
            Microsoft.SmallBasic.Library.Sound.Stop(BombSoundPath);
            Microsoft.SmallBasic.Library.Sound.Play(BombSoundPath);

            this.mode = MODE_END;
        }


        #region タイマー関連
        DispatcherTimer dispatcherTimer;    // タイマーオブジェクト
        int TimeLimit = 60;                 // 制限時間(デフォルト値)
        DateTime StartTime;                 // カウント開始時刻
        TimeSpan nowtimespan;               // Startボタンが押されてから現在までの経過時間
        TimeSpan oldtimespan;               // 一時停止ボタンが押されるまでに経過した時間の蓄積

        private void ExecTimer()
        {
            // タイマーのインスタンスを生成
            dispatcherTimer = new DispatcherTimer(DispatcherPriority.Normal);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100); // 100ミリ秒ごとにTickを実行
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);

            // タイマーの時間設定
            // 設定なしの場合は60秒
            TimeLimit = wpfLogic.GetSettingTimerSec() == 0 ? 60 : wpfLogic.GetSettingTimerSec();

            // タイマー開始
            TimerStart();
        }

        // タイマー Tick処理
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            nowtimespan = DateTime.Now.Subtract(StartTime);
            wpfIf.IsLightRed = !wpfIf.IsLightRed;

            // 時間表示
            wpfLogic.SetDispTimerSec(TimeLimit - (int)nowtimespan.TotalSeconds);
            this.updateTimerArea();

            if (timeCounter % soundBeepBase == 0)
            {
                // 止める処理を入れてから鳴らす
                Microsoft.SmallBasic.Library.Sound.Stop(BeepSoundPath);
                // ビープ音を鳴らす
                Microsoft.SmallBasic.Library.Sound.Play(BeepSoundPath);
            }
            if (TimeSpan.Compare(oldtimespan.Add(nowtimespan), new TimeSpan(0, 0, TimeLimit)) >= 0){
                wpfIf.IsLightRed = true;
                TimerStop();
                TimerReset();
                // 爆発処理=====================================================================
                this.ExecBomb();
            }
            else if (TimeSpan.Compare(oldtimespan.Add(nowtimespan), new TimeSpan(0, 0, TimeLimit - 10)) >= 0) // 10秒前からビープ音が早くなる
            {
                soundBeepBase = SOUND_SPEED_VERYFAST;
            }
            else if (TimeSpan.Compare(oldtimespan.Add(nowtimespan), new TimeSpan(0, 0, TimeLimit - 20)) >= 0) // 20秒前からすこしビープ音が早くなる
            {
                soundBeepBase = SOUND_SPEED_FAST;
            }
                timeCounter++;
        }

        // タイマー操作：開始
        private void TimerStart()
        {
            StartTime = DateTime.Now;
            dispatcherTimer.Start();
            timeCounter = 0;
            soundBeepBase = SOUND_SPEED_NOMAL;
        }
        // タイマー操作：停止
        private void TimerStop()
        {
            oldtimespan = oldtimespan.Add(nowtimespan);
            dispatcherTimer.Stop();
        }

        // タイマー操作：リセット
        private void TimerReset()
        {
            oldtimespan = new TimeSpan();
        }

        #endregion

        #region 設定画面開く用
        private void StackPanel_RightTop_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (openSettingButtonPushCount == 0)
            {
                openSettingButtonPushCount++;
            }
            else
            {
                openSettingButtonPushCount = 0;
            }
        }

        private void StackPanel_RightButtom_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (openSettingButtonPushCount == 1)
            {
                openSettingButtonPushCount++;
            }
            else
            {
                openSettingButtonPushCount = 0;
            }
        }

        private void StackPanel_LeftButtom_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (openSettingButtonPushCount == 2)
            {
                openSettingButtonPushCount++;
            }
            else
            {
                openSettingButtonPushCount = 0;
            }
        }

        private void StackPanel_LeftTop_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (openSettingButtonPushCount == 3)
            {
                if (ViewMode != VIEWMODE_SETTING)
                {
                    ViewMode = VIEWMODE_SETTING;
                }
            }
            openSettingButtonPushCount = 0;
        }
        #endregion

        // 設定保存
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (mode == MODE_END)
            {
                // ゲーム終了後
                wpfIf.IsLightRed = false;
                wpfIf.IsLightBlue = false;
                mode = MODE_WAIT;
            }

            wpfLogic.initInputPasswords();
            this.updatePasswordArea();
            ViewMode = VIEWMODE_NOMAL;
        }
    }
}
