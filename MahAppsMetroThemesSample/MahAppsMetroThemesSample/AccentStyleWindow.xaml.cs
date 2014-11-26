using System;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro;
using MahApps.Metro.Controls;

namespace MahAppsMetroThemesSample
{
    /// <summary>
    /// Interaction logic for AccentStyleWindow.xaml
    /// </summary>
    public partial class AccentStyleWindow : MetroWindow
    {
        public AccentStyleWindow()
        {
            InitializeComponent();

            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(this, theme.Item2, theme.Item1);
        }

        private void ChangeWindowThemeButtonClick(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(this);
            ThemeManager.ChangeAppStyle(this, theme.Item2, ThemeManager.GetAppTheme("Base" + ((Button)sender).Content));
        }

        private void ChangeWindowAccentButtonClick(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(this);
            ThemeManager.ChangeAppStyle(this, ThemeManager.GetAccent(((Button)sender).Content.ToString()), theme.Item1);
        }

        private void ChangeAppThemeButtonClick(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, ThemeManager.GetAppTheme("Base" + ((Button)sender).Content));
        }

        private void ChangeAppAccentButtonClick(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent(((Button)sender).Content.ToString()), theme.Item1);
        }
        
        private void CustomThemeAppButtonClick(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, ThemeManager.GetAppTheme("CustomTheme"));
        }

        private void CustomAccent1AppButtonClick(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("CustomAccent1"), theme.Item1);
        }

        private void CustomAccent2AppButtonClick(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("CustomAccent2"), theme.Item1);
        }

        private void AccentSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedAccent = AccentSelector.SelectedItem as Accent;
            if (selectedAccent != null)
            {
                var theme = ThemeManager.DetectAppStyle(Application.Current);
                ThemeManager.ChangeAppStyle(Application.Current, selectedAccent, theme.Item1);
                Application.Current.MainWindow.Activate();
            }
        }
    }
}
