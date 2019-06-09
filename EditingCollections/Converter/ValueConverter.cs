using EditingCollections.Enum;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EditingCollections.Converter
{
    public class ValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string strRaw = (string)values[0];
            MyType valueType = (MyType)values[1];

            switch (valueType)
            {
                case MyType.Currency:
                    decimal curValue;
                    if (Decimal.TryParse(strRaw, out curValue))
                    {
                        return String.Format("{0:C2}", curValue);
                    }
                    else return null;
                case MyType.Percentage:
                    decimal decValue = 0;
                    if (Decimal.TryParse(strRaw, out decValue))
                    {
                        return decValue.ToString("P", CultureInfo.InvariantCulture);
                    }
                    else return null;
                case MyType.String:
                    return strRaw;
                case MyType.None:
                    return null;
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
