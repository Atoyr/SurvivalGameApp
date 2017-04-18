using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace SurvivalGameApp.Main.Converters
{
    [ValueConversion(typeof(string), typeof(SolidColorBrush))]
    public class ColorCodeToSolidBrushConverter
    {

        /// <summary>
        /// 値を変換します。
        /// </summary>
        /// <param name="value">バインディング ソースによって生成された値。</param>
        /// <param name="targetType">バインディング ターゲット プロパティの型。</param>
        /// <param name="parameter">使用するコンバーター パラメーター</param>
        /// <param name="culture">コンバーターで使用するカルチャ。</param>
        /// <returns>変換された値</returns>
        public object Convert(object value, Type targetType,
                        object parameter, System.Globalization.CultureInfo culture)
        {

            if (value is string str && str[0] == '#' && (str.Length == 7 || str.Length == 9))
            {
                if(str.Length == 7)
                {
                    //int red = 
                }
                else
                {

                }
            }
            else
            {
                return new SolidColorBrush(Colors.Transparent);
            }
            return new SolidColorBrush(Colors.Transparent);
        }
    }
}
