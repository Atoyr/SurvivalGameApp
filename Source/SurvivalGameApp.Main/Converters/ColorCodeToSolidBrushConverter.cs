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
    public class ColorCodeToSolidBrushConverter : IValueConverter
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
            Brush brush = new SolidColorBrush(Colors.Transparent);
            if (value is string str && (str.Length == 7 || str.Length == 9) && str[0] == '#')
            {
                var color = ColorConverter.ConvertFromString(str);
                brush = new SolidColorBrush((Color)color );
            }
            return brush;
        }

        /// <summary>
        /// 値を変換します。(未実装)
        /// </summary>
        /// <param name="value">バインディング ターゲットによって生成される値。</param>
        /// <param name="targetType">変換後の型。</param>
        /// <param name="parameter">使用するコンバーター パラメーター</param>
        /// <param name="culture">コンバーターで使用するカルチャ。</param>
        /// <returns>変換された値</returns>
        public object ConvertBack(object value, Type targetType,
                        object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is SolidColorBrush brush)
            {
                return brush.Color;
            }
            return Colors.Transparent;
        }
    }
}
