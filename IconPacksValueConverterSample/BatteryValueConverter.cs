using System;
using System.Globalization;
using System.Windows.Data;
using MahApps.Metro.IconPacks;

namespace IconPacksValueConverterSample
{
    public sealed class BatteryValueConverter : IMultiValueConverter
    {
        /// <summary> Gets the default instance </summary>
        public static readonly BatteryValueConverter Default = new();

        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            var percentage = (value[0] as double?).GetValueOrDefault(0);
            var isCharging = (value[1] as bool?).GetValueOrDefault(false);

            return percentage switch
            {
                < 5 => PackIconMaterialKind.BatteryAlert,
                < 10 when isCharging => PackIconMaterialKind.BatteryChargingOutline,
                < 10 => PackIconMaterialKind.BatteryOutline,
                < 20 when isCharging => PackIconMaterialKind.BatteryCharging10,
                < 20 => PackIconMaterialKind.Battery10,
                < 30 when isCharging => PackIconMaterialKind.BatteryCharging20,
                < 30 => PackIconMaterialKind.Battery20,
                < 40 when isCharging => PackIconMaterialKind.BatteryCharging30,
                < 40 => PackIconMaterialKind.Battery30,
                < 50 when isCharging => PackIconMaterialKind.BatteryCharging40,
                < 50 => PackIconMaterialKind.Battery40,
                < 60 when isCharging => PackIconMaterialKind.BatteryCharging50,
                < 60 => PackIconMaterialKind.Battery50,
                < 70 when isCharging => PackIconMaterialKind.BatteryCharging60,
                < 70 => PackIconMaterialKind.Battery60,
                < 80 when isCharging => PackIconMaterialKind.BatteryCharging70,
                < 80 => PackIconMaterialKind.Battery70,
                < 90 when isCharging => PackIconMaterialKind.BatteryCharging80,
                < 90 => PackIconMaterialKind.Battery80,
                < 100 when isCharging => PackIconMaterialKind.BatteryCharging90,
                < 100 => PackIconMaterialKind.Battery90,
                _ => isCharging ? PackIconMaterialKind.BatteryCharging : PackIconMaterialKind.Battery
            };
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            // nothing here
            throw new NotImplementedException();
        }
    }
}