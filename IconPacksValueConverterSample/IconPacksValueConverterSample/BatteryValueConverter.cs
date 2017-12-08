using System;
using System.Globalization;
using System.Windows.Data;
using MahApps.Metro.IconPacks;

namespace IconPacksValueConverterSample
{
    public class BatteryValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // the value is in this case a double (comes from the Slider)
            var percentage = (value as double?).GetValueOrDefault(0);
            if (percentage < 10)
            {
                return PackIconMaterialKind.BatteryOutline;
            }
            else if (percentage < 20)
            {
                return PackIconMaterialKind.Battery10;
            }
            else if (percentage < 30)
            {
                return PackIconMaterialKind.Battery20;
            }
            else if (percentage < 40)
            {
                return PackIconMaterialKind.Battery30;
            }
            else if (percentage < 50)
            {
                return PackIconMaterialKind.Battery40;
            }
            else if (percentage < 60)
            {
                return PackIconMaterialKind.Battery50;
            }
            else if (percentage < 70)
            {
                return PackIconMaterialKind.Battery60;
            }
            else if (percentage < 80)
            {
                return PackIconMaterialKind.Battery70;
            }
            else if (percentage < 90)
            {
                return PackIconMaterialKind.Battery80;
            }
            else if (percentage < 100)
            {
                return PackIconMaterialKind.Battery90;
            }
            return PackIconMaterialKind.Battery;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // nothing here
            throw new NotImplementedException();
        }
    }
}