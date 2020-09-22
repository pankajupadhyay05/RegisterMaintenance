using System;
using System.Windows.Data;

namespace RegisterMaintenance.DAL
{
    public class DecimalNullFromStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is decimal || value is decimal?) return value;
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;

            var strValue = value as string;
            if (strValue == null || strValue.Trim().Length == 0)
                return null; //allow empty strings and whitespaces

            decimal decimalValue = 0;
            if (decimal.TryParse(strValue, out decimalValue))
                return decimalValue;

            return value; //which will intenionally throw an error 
        }
    }
}
