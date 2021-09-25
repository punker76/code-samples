using System;
using System.Globalization;
using System.Windows.Data;
using MahApps.Metro.IconPacks;

namespace IconPacksValueConverterSample
{
    [ValueConversion(typeof(double?), typeof(PackIconFontAwesomeKind))]
    public sealed class BatteryQuarterValueConverter : IValueConverter
    {
        /// <summary> Gets the default instance </summary>
        public static readonly BatteryQuarterValueConverter Default = new();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // the value is in this case a double (comes from the Slider)
            var percentage = (value as double?).GetValueOrDefault(0);
            return percentage switch
            {
                < 25 => PackIconFontAwesomeKind.BatteryEmptySolid,
                < 50 => PackIconFontAwesomeKind.BatteryQuarterSolid,
                < 75 => PackIconFontAwesomeKind.BatteryHalfSolid,
                < 100 => PackIconFontAwesomeKind.BatteryThreeQuartersSolid,
                _ => PackIconFontAwesomeKind.BatteryFullSolid
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // nothing here
            throw new NotImplementedException();
        }
    }
}