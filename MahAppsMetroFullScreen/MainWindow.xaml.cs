using System.Windows;
using MahApps.Metro.Controls;

namespace MahAppsMetroFullScreen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.SetCurrentValue(WindowStateProperty, WindowState.Maximized);
            this.SetCurrentValue(IgnoreTaskbarOnMaximizeProperty, true);
        }

        private void FullClick(object sender, RoutedEventArgs e)
        {
            this.SetCurrentValue(WindowStateProperty, WindowState.Maximized);
            this.SetCurrentValue(IgnoreTaskbarOnMaximizeProperty, true);
        }

        private void NormalClick(object sender, RoutedEventArgs e)
        {
            this.SetCurrentValue(WindowStateProperty, WindowState.Normal);
            this.SetCurrentValue(IgnoreTaskbarOnMaximizeProperty, false);
        }
    }
}