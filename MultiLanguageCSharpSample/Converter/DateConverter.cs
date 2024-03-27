using MultiLanguageCSharpSample.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MultiLanguageCSharpSample.Converter;

[ValueConversion(typeof(DateOnly), typeof(string))]
public class DateConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (value as DateOnly?)?.ToString(Resources.DateFormat) ?? throw new NotSupportedException();

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
}
