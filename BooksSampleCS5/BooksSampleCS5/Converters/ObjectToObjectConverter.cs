using System;
using Windows.UI.Xaml.Data;

namespace BooksSample.Converters
{
    public class ObjectToObjectConverter : IValueConverter
    {

        // TODO: 04 - expression bodied member
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
