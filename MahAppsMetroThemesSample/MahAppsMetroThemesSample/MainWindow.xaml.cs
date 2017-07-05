using System;
using System.Windows;
using System.Windows.Threading;
using MahApps.Metro.Controls;

namespace MahAppsMetroThemesSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private DispatcherTimer _timer;

        public MainWindow()
        {
            InitializeComponent();
            //this.Loaded += MainWindow_Loaded;
            //this.Unloaded += MainWindow_Unloaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _timer = new DispatcherTimer(TimeSpan.FromMilliseconds(200),
                DispatcherPriority.Normal,
                (o, args) =>
                {
                    this.theProgressBar.Value = DateTime.Now.Millisecond;
                    theOtherProgressBar.Value = DateTime.Now.Millisecond;
                },
                Dispatcher);
            _timer.Start();
        }

        private void MainWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            _timer?.Stop();
        }

        private MetroWindow accentThemeTestWindow;

        private void ChangeAppStyleButtonClick(object sender, RoutedEventArgs e)
        {
            if (accentThemeTestWindow != null)
            {
                accentThemeTestWindow.Activate();
                return;
            }

            accentThemeTestWindow = new AccentStyleWindow();
            accentThemeTestWindow.Owner = this;
            accentThemeTestWindow.Closed += (o, args) => accentThemeTestWindow = null;
            accentThemeTestWindow.Left = this.Left + this.ActualWidth / 2.0;
            accentThemeTestWindow.Top = this.Top + this.ActualHeight / 2.0;
            accentThemeTestWindow.Show();
        }
    }
}