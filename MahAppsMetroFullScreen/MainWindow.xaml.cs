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
            this.FullClick(null, null);
        }

        private void FullClick(object sender, RoutedEventArgs e)
        {
            this.SetCurrentValue(WindowStateProperty, WindowState.Maximized);
            this.SetCurrentValue(ShowTitleBarProperty, false); // <-- this must be set to false
            this.SetCurrentValue(WindowButtonCommandsOverlayBehaviorProperty, OverlayBehavior.Never); // We don't want the overlay
            this.SetCurrentValue(IgnoreTaskbarOnMaximizeProperty, true);
        }

        private void NormalClick(object sender, RoutedEventArgs e)
        {
            this.SetCurrentValue(WindowStateProperty, WindowState.Normal);
            this.SetCurrentValue(ShowTitleBarProperty, true); // <-- this must be set to true
            this.SetCurrentValue(WindowButtonCommandsOverlayBehaviorProperty, OverlayBehavior.Always); // Set to Always to show the overlay
            this.SetCurrentValue(IgnoreTaskbarOnMaximizeProperty, false);
        }
    }
}