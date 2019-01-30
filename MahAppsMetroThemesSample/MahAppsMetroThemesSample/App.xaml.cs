using System.Windows;
using System.Windows.Media;

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
//            ThemeManager.AddAccent("CustomAccent1", new Uri("pack://application:,,,/MahAppsMetroThemesSample;component/CustomAccents/CustomAccent1.xaml"));
//            ThemeManager.AddAccent("CustomAccent2", new Uri("pack://application:,,,/MahAppsMetroThemesSample;component/CustomAccents/CustomAccent2.xaml"));
//            ThemeManager.AddAppTheme("CustomTheme", new Uri("pack://application:,,,/MahAppsMetroThemesSample;component/CustomAccents/CustomTheme.xaml"));

            // create custom accents
            ThemeManagerHelper.CreateTheme("Dark", Colors.Red, "CustomAccentDarkRed");
            ThemeManagerHelper.CreateTheme("Light", Colors.Red, "CustomAccentLightRed");
            ThemeManagerHelper.CreateTheme("Dark", Colors.GreenYellow);
            ThemeManagerHelper.CreateTheme("Light", Colors.GreenYellow);
            ThemeManagerHelper.CreateTheme("Dark", Colors.Indigo);
            ThemeManagerHelper.CreateTheme("Light", Colors.Indigo, changeImmediately: true);

            base.OnStartup(e);
        }
    }
}