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
        }

        private void FullClick(object sender, RoutedEventArgs e)
        {
            this.SetCurrentValue(WindowStateProperty, WindowState.Maximized);
            this.SetCurrentValue(UseNoneWindowStyleProperty, true);
            this.SetCurrentValue(IgnoreTaskbarOnMaximizeProperty, true);
        }

        private void NormalClick(object sender, RoutedEventArgs e)
        {
            this.SetCurrentValue(WindowStateProperty, WindowState.Normal);
            this.SetCurrentValue(UseNoneWindowStyleProperty, false);
            this.SetCurrentValue(ShowTitleBarProperty, true); // <-- this must be set to true
            this.SetCurrentValue(IgnoreTaskbarOnMaximizeProperty, false);
        }
    }
}