using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Trello.ValueConverter
{
    [AddINotifyPropertyChangedInterface]
    class ForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = DateTime.Parse(value.ToString());
            if (date > DateTime.Now)
            {
                return System.Windows.Media.Brushes.Green;
            }
            else
            {
                return System.Windows.Media.Brushes.Red;
            }            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
