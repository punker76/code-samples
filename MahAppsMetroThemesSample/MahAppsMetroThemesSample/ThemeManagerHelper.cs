using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using MahApps.Metro;

namespace MahAppsMetroThemesSample
{
    public static class ThemeManagerHelper
    {
        public static void CreateAppStyleBy(Color color, bool changeImmediately = false)
        {
            // create a runtime accent resource dictionary

            var resourceDictionary = new ResourceDictionary();

            resourceDictionary.Add("HighlightColor", color);
            resourceDictionary.Add("AccentColor", Color.FromArgb((byte)(204), color.R, color.G, color.B));
            resourceDictionary.Add("AccentColor2", Color.FromArgb((byte)(153), color.R, color.G, color.B));
            resourceDictionary.Add("AccentColor3", Color.FromArgb((byte)(102), color.R, color.G, color.B));
            resourceDictionary.Add("AccentColor4", Color.FromArgb((byte)(51), color.R, color.G, color.B));

            resourceDictionary.Add("HighlightBrush", new SolidColorBrush((Color)resourceDictionary["HighlightColor"]));
            resourceDictionary.Add("AccentColorBrush", new SolidColorBrush((Color)resourceDictionary["AccentColor"]));
            resourceDictionary.Add("AccentColorBrush2", new SolidColorBrush((Color)resourceDictionary["AccentColor2"]));
            resourceDictionary.Add("AccentColorBrush3", new SolidColorBrush((Color)resourceDictionary["AccentColor3"]));
            resourceDictionary.Add("AccentColorBrush4", new SolidColorBrush((Color)resourceDictionary["AccentColor4"]));
            resourceDictionary.Add("WindowTitleColorBrush", new SolidColorBrush((Color)resourceDictionary["AccentColor"]));
            resourceDictionary.Add("AccentSelectedColorBrush", new SolidColorBrush(Colors.White));

            resourceDictionary.Add("ProgressBrush", new LinearGradientBrush(
                new GradientStopCollection(new[]
                {
                    new GradientStop((Color)resourceDictionary["HighlightColor"], 0),
                    new GradientStop((Color)resourceDictionary["AccentColor3"], 1)
                }),
                new Point(0.001, 0.5), new Point(1.002, 0.5)));

            resourceDictionary.Add("CheckmarkFill", new SolidColorBrush((Color)resourceDictionary["AccentColor"]));
            resourceDictionary.Add("RightArrowFill", new SolidColorBrush((Color)resourceDictionary["AccentColor"]));

            resourceDictionary.Add("IdealForegroundColor", Colors.White);
            resourceDictionary.Add("IdealForegroundColorBrush", new SolidColorBrush((Color)resourceDictionary["IdealForegroundColor"]));

            // applying theme to MahApps

            var resDictName = string.Format("ApplicationAccent_{0}.xaml", color.ToString().Replace("#", string.Empty));
            var fileName = Path.Combine(Path.GetTempPath(), resDictName);
            using (var writer = System.Xml.XmlWriter.Create(fileName, new System.Xml.XmlWriterSettings { Indent = true }))
            {
                System.Windows.Markup.XamlWriter.Save(resourceDictionary, writer);
                writer.Close();
            }

            resourceDictionary = new ResourceDictionary() { Source = new Uri(fileName, UriKind.Absolute) };

            var newAccent = new Accent { Name = resDictName, Resources = resourceDictionary };
            ThemeManager.AddAccent(newAccent.Name, newAccent.Resources.Source);
            
            if (changeImmediately)
            {
                var application = Application.Current;
                var applicationTheme = ThemeManager.AppThemes.First(x => string.Equals(x.Name, "BaseLight"));
                ThemeManager.ChangeAppStyle(application, newAccent, applicationTheme);
            }
        }
    }
}