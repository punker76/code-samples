using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ControlzEx.Theming;
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
            get { return (List<KeyValuePair<string, Color>>)GetValue(ColorsProperty); }
            set { SetValue(ColorsProperty, value); }
        }

        public AccentStyleWindow()
        {
            InitializeComponent();

            this.DataContext = this;

            this.Colors = typeof(Colors)
                          .GetProperties()
                          .Where(prop => typeof(Color).IsAssignableFrom(prop.PropertyType))
                          .Select(prop => new KeyValuePair<String, Color>(prop.Name, (Color)prop.GetValue(null)))
                          .ToList();

            var appTheme = ThemeManager.Current.DetectTheme(Application.Current);
            ThemeManager.Current.ChangeTheme(this, appTheme);
        }

        private void ChangeWindowThemeButtonClick(object sender, RoutedEventArgs e)
        {
            ThemeManager.Current.ChangeThemeBaseColor(this, ((Button)sender).Content.ToString());
        }

        private void ChangeWindowAccentButtonClick(object sender, RoutedEventArgs e)
        {
            ThemeManager.Current.ChangeThemeColorScheme(this, ((Button)sender).Content.ToString());
        }

        private void ChangeAppThemeButtonClick(object sender, RoutedEventArgs e)
        {
            ThemeManager.Current.ChangeThemeBaseColor(Application.Current, ((Button)sender).Content.ToString());
            Application.Current?.MainWindow?.Activate();
        }

        private void ChangeAppAccentButtonClick(object sender, RoutedEventArgs e)
        {
            ThemeManager.Current.ChangeThemeColorScheme(Application.Current, ((Button)sender).Content.ToString());
            Application.Current?.MainWindow?.Activate();
        }

        private void LightAccent1AppButtonClick(object sender, RoutedEventArgs e)
        {
            ThemeManager.Current.ChangeTheme(Application.Current, "Light.Accent1");
            Application.Current?.MainWindow?.Activate();
        }

        private void DarkAccent1AppButtonClick(object sender, RoutedEventArgs e)
        {
            ThemeManager.Current.ChangeTheme(Application.Current, "Dark.Accent1");
            Application.Current?.MainWindow?.Activate();
        }

        private void LightAccent2AppButtonClick(object sender, RoutedEventArgs e)
        {
            ThemeManager.Current.ChangeTheme(Application.Current, "Light.Accent2");
            Application.Current?.MainWindow?.Activate();
        }

        private void DarkAccent2AppButtonClick(object sender, RoutedEventArgs e)

        {
            ThemeManager.Current.ChangeTheme(Application.Current, "Dark.Accent2");
            Application.Current?.MainWindow?.Activate();
        }

        private void AccentSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedTheme = e.AddedItems.OfType<Theme>().FirstOrDefault();
            if (selectedTheme != null)
            {
                ThemeManager.Current.ChangeTheme(Application.Current, selectedTheme);
                Application.Current?.MainWindow?.Activate();
            }
        }

        private void ColorsSelectorOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedColor = e.AddedItems.OfType<KeyValuePair<string, Color>?>().FirstOrDefault();
            if (selectedColor != null)
            {
                var theme = ThemeManager.Current.DetectTheme(Application.Current);
                var inverseTheme = ThemeManager.Current.GetInverseTheme(theme);
                ThemeManager.Current.AddTheme(RuntimeThemeGenerator.Current.GenerateRuntimeTheme(inverseTheme.BaseColorScheme, selectedColor.Value.Value));
                ThemeManager.Current.ChangeTheme(Application.Current, ThemeManager.Current.AddTheme(RuntimeThemeGenerator.Current.GenerateRuntimeTheme(theme.BaseColorScheme, selectedColor.Value.Value)));
                Application.Current?.MainWindow?.Activate();
            }
        }
    }
}