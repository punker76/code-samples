using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MahApps.Metro;
using MahApps.Metro.Controls;

namespace MahAppsMetroThemesSample
{
    /// <summary>
    /// Interaction logic for AccentStyleWindow.xaml
    /// </summary>
    public partial class AccentStyleWindow : MetroWindow
    {
        public static readonly DependencyProperty ColorsProperty
            = DependencyProperty.Register("Colors",
                typeof(List<KeyValuePair<string, Color>>),
                typeof(AccentStyleWindow),
                new PropertyMetadata(default(List<KeyValuePair<string, Color>>)));

        public List<KeyValuePair<string, Color>> Colors
        {
            get { return (List<KeyValuePair<string, Color>>) GetValue(ColorsProperty); }
            set { SetValue(ColorsProperty, value); }
        }

        public AccentStyleWindow()
        {
            InitializeComponent();

            this.DataContext = this;

            this.Colors = typeof(Colors)
                .GetProperties()
                .Where(prop => typeof(Color).IsAssignableFrom(prop.PropertyType))
                .Select(prop => new KeyValuePair<String, Color>(prop.Name, (Color) prop.GetValue(null)))
                .ToList();

            var theme = ThemeManager.DetectTheme(Application.Current);
            ThemeManager.ChangeTheme(this, theme);
        }

        private void ChangeWindowThemeButtonClick(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeThemeBaseColor(this, ((Button) sender).Content.ToString());
        }

        private void ChangeWindowAccentButtonClick(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeThemeColorScheme(this, ((Button) sender).Content.ToString());
        }

        private void ChangeAppThemeButtonClick(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeThemeBaseColor(Application.Current, ((Button) sender).Content.ToString());
            Application.Current?.MainWindow?.Activate();
        }

        private void ChangeAppAccentButtonClick(object sender, RoutedEventArgs e)
        {
            ThemeManager.ChangeThemeColorScheme(Application.Current, ((Button) sender).Content.ToString());
            Application.Current?.MainWindow?.Activate();
        }

        private void CustomThemeAppButtonClick(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectTheme(Application.Current);
//            ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, ThemeManager.GetAppTheme("CustomTheme"));
        }

        private void CustomAccent1AppButtonClick(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectTheme(Application.Current);
//            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("CustomAccent1"), theme.Item1);
        }

        private void CustomAccent2AppButtonClick(object sender, RoutedEventArgs e)
        {
            var theme = ThemeManager.DetectTheme(Application.Current);
//            ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent("CustomAccent2"), theme.Item1);
        }

        private void AccentSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedAccent = AccentSelector.SelectedItem as ColorScheme;
            if (selectedAccent != null)
            {
                ThemeManager.ChangeThemeColorScheme(Application.Current, selectedAccent.Name);
                Application.Current?.MainWindow?.Activate();
            }
        }

        private void ColorsSelectorOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedColor = this.ColorsSelector.SelectedItem as KeyValuePair<string, Color>?;
            if (selectedColor.HasValue)
            {
                var theme = ThemeManager.DetectTheme(Application.Current);
                ThemeManagerHelper.CreateTheme(theme.BaseColorScheme, selectedColor.Value.Value, changeImmediately: true);
                Application.Current?.MainWindow?.Activate();
            }
        }
    }
}