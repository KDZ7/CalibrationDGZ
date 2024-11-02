using System.Globalization;
using System.Windows.Data;

namespace CalibrationDGZ.Common.Converters
{
    public class DecimalToHexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double doubleValue)
            {
                int intValue = (int)doubleValue;
                return $"0x{intValue:X2}";
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string hexValue && hexValue.StartsWith("0x"))
            {
                if (int.TryParse(hexValue.Substring(2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int intValue))
                {
                    return intValue;
                }
            }
            return value;
        }
    }
}
