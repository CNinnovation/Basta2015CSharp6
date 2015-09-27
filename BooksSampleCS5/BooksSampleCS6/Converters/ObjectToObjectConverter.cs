using System;
using Windows.UI.Xaml.Data;

namespace BooksSample.Converters
{
    public class ObjectToObjectConverter : IValueConverter
    {

        // DONE: expression bodied member
        public object Convert(object value, Type targetType, object parameter, string language) => value;

        public object ConvertBack(object value, Type targetType, object parameter, string language) => value;

    }
}
