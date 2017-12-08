using System;
using System.Globalization;
using System.Windows.Data;
using MahApps.Metro.IconPacks;

namespace IconPacksValueConverterSample
{
    public class BatteryQuarterValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // the value is in this case a double (comes from the Slider)
            var percentage = (value as double?).GetValueOrDefault(0);
            if (percentage < 25)
            {
                return PackIconFontAwesomeKind.BatteryEmpty;
            }
            else if (percentage < 50)
            {
                return PackIconFontAwesomeKind.BatteryQuarter;
            }
            else if (percentage < 75)
            {
                return PackIconFontAwesomeKind.BatteryHalf;
            }
            else if (percentage < 100)
            {
                return PackIconFontAwesomeKind.BatteryThreeQuarters;
            }
            return PackIconFontAwesomeKind.BatteryFull;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // nothing here
            throw new NotImplementedException();
        }
    }
}