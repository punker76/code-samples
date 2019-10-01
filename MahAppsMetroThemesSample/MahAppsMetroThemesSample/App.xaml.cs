using System;
using System.Windows;
using System.Windows.Media;
using MahApps.Metro;

namespace MahAppsMetroThemesSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // add custom accent and theme resource dictionaries
            ThemeManager.AddTheme(new Uri("pack://application:,,,/MahAppsMetroThemesSample;component/CustomAccents/Dark.Accent1.xaml"));
            ThemeManager.AddTheme(new Uri("pack://application:,,,/MahAppsMetroThemesSample;component/CustomAccents/Dark.Accent2.xaml"));
            ThemeManager.AddTheme(new Uri("pack://application:,,,/MahAppsMetroThemesSample;component/CustomAccents/Light.Accent1.xaml"));
            ThemeManager.AddTheme(new Uri("pack://application:,,,/MahAppsMetroThemesSample;component/CustomAccents/Light.Accent2.xaml"));

            base.OnStartup(e);

            MahApps.Metro.ThemeManager.IsAutomaticWindowsAppModeSettingSyncEnabled = true;
            MahApps.Metro.ThemeManager.SyncThemeWithWindowsAppModeSetting();

            // create custom accents
            ThemeManagerHelper.CreateTheme("Dark", Colors.Red, "CustomAccentDarkRed");
            ThemeManagerHelper.CreateTheme("Light", Colors.Red, "CustomAccentLightRed");
            ThemeManagerHelper.CreateTheme("Dark", Colors.GreenYellow);
            ThemeManagerHelper.CreateTheme("Light", Colors.GreenYellow);
            ThemeManagerHelper.CreateTheme("Dark", Colors.Indigo);
            ThemeManagerHelper.CreateTheme("Light", Colors.Indigo, changeImmediately: true);
        }
    }
}