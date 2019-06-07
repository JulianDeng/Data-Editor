using EditingCollections.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;


namespace EditingCollections.Converter
{
    public class ValueTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is MyType format)
            {
                return GetString(format);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string s)
            {
                return System.Enum.Parse(typeof(MyType), s);
            }
            return null;
        }

        public string[] Strings => GetStrings();

        public static string GetString(MyType format)
        {
            return format.ToString() + GetDescription(format);
        }

        public static string GetDescription(MyType format)
        {
            return format.GetType().GetMember(format.ToString())[0].GetCustomAttribute<DescriptionAttribute>().Description;
        }

        public static string[] GetStrings()
        {
            List<string> list = new List<string>();
            foreach (MyType format in System.Enum.GetValues(typeof(MyType)))
            {
                list.Add(GetString(format));
            }

            return list.ToArray();
        }
    }
}
