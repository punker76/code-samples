using System;
using System.Globalization;
using System.Windows.Data;
using MahApps.Metro.IconPacks;

namespace IconPacksValueConverterSample
{
    public class BatteryValueConverter : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            var percentage = (value[0] as double?).GetValueOrDefault(0);
            var isCharging = (value[1] as bool?).GetValueOrDefault(false);

            if (percentage < 5)
            {
                return PackIconMaterialKind.BatteryAlert;
            }
            else if (percentage < 10)
            {
                if (isCharging)
                {
                    return PackIconMaterialKind.BatteryChargingOutline;
                }
                else
                {
                    return PackIconMaterialKind.BatteryOutline;
                }
            }
            else if (percentage < 20)
            {
                if (isCharging)
                {
                    return PackIconMaterialKind.BatteryCharging10;
                }
                else
                {
                    return PackIconMaterialKind.Battery10;
                }
            }
            else if (percentage < 30)
            {
                if (isCharging)
                {
                    return PackIconMaterialKind.BatteryCharging20;
                }
                else
                {
                    return PackIconMaterialKind.Battery20;
                }
            }
            else if (percentage < 40)
            {
                if (isCharging)
                {
                    return PackIconMaterialKind.BatteryCharging30;
                }
                else
                {
                    return PackIconMaterialKind.Battery30;
                }
            }
            else if (percentage < 50)
            {
                if (isCharging)
                {
                    return PackIconMaterialKind.BatteryCharging40;
                }
                else
                {
                    return PackIconMaterialKind.Battery40;
                }
            }
            else if (percentage < 60)
            {
                if (isCharging)
                {
                    return PackIconMaterialKind.BatteryCharging50;
                }
                else
                {
                    return PackIconMaterialKind.Battery50;
                }
            }
            else if (percentage < 70)
            {
                if (isCharging)
                {
                    return PackIconMaterialKind.BatteryCharging60;
                }
                else
                {
                    return PackIconMaterialKind.Battery60;
                }
                return PackIconMaterialKind.Battery60;
            }
            else if (percentage < 80)
            {
                if (isCharging)
                {
                    return PackIconMaterialKind.BatteryCharging70;
                }
                else
                {
                    return PackIconMaterialKind.Battery70;
                }
            }
            else if (percentage < 90)
            {
                if (isCharging)
                {
                    return PackIconMaterialKind.BatteryCharging80;
                }
                else
                {
                    return PackIconMaterialKind.Battery80;
                }
            }
            else if (percentage < 100)
            {
                if (isCharging)
                {
                    return PackIconMaterialKind.BatteryCharging90;
                }
                else
                {
                    return PackIconMaterialKind.Battery90;
                }
            }

            if (isCharging)
            {
                return PackIconMaterialKind.BatteryCharging;
            }
            return PackIconMaterialKind.Battery;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            // nothing here
            throw new NotImplementedException();
        }
    }
}