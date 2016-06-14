using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using MahApps.Metro.Controls;

namespace MahAppsMetroSample
{
    public partial class MainWindow : CustomBaseMetroWindow
    {
        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();
            this.TestColl.Add("Test 1");
            this.TestColl.Add("Test 2");
            this.TestColl.Add("Test 3");
        }

        public static readonly DependencyProperty TestCollProperty = DependencyProperty.Register(
            "TestColl", typeof(ObservableCollection<string>), typeof(MainWindow), new PropertyMetadata(new ObservableCollection<string>()));

        public ObservableCollection<string> TestColl
        {
            get { return (ObservableCollection<string>) GetValue(TestCollProperty); }
            set { SetValue(TestCollProperty, value); }
        }

        private void ButtonBase_OnClick(object sender, EventArgs e)
        {
            var w = new MetroWindow();
            w.GlowBrush = Brushes.Gray;
            w.BorderThickness = new Thickness(1);
            w.Title = "Modal";
            w.Width = 300;
            w.Height = 200;
            w.Owner = this;
            w.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            w.ShowDialog();
        }

        public static readonly DependencyProperty ToggleFullScreenProperty =
            DependencyProperty.Register("ToggleFullScreen",
                typeof(bool),
                typeof(MainWindow),
                new PropertyMetadata(default(bool), ToggleFullScreenPropertyChangedCallback));

        private static void ToggleFullScreenPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var metroWindow = (MetroWindow) dependencyObject;
            if (e.OldValue != e.NewValue)
            {
                var fullScreen = (bool) e.NewValue;
                if (fullScreen)
                {
                    metroWindow.UseNoneWindowStyle = true;
                    metroWindow.IgnoreTaskbarOnMaximize = true;
                    metroWindow.ShowMinButton = false;
                    metroWindow.ShowMaxRestoreButton = false;
                    metroWindow.ShowCloseButton = false;
                    metroWindow.WindowState = WindowState.Maximized;
                }
                else
                {
                    metroWindow.UseNoneWindowStyle = false;
                    metroWindow.ShowTitleBar = true; // <-- this must be set to true
                    metroWindow.IgnoreTaskbarOnMaximize = false;
                    metroWindow.ShowMinButton = true;
                    metroWindow.ShowMaxRestoreButton = true;
                    metroWindow.ShowCloseButton = true;
                    metroWindow.WindowState = WindowState.Normal;
                }
            }
        }

        public bool ToggleFullScreen
        {
            get { return (bool) GetValue(ToggleFullScreenProperty); }
            set { SetValue(ToggleFullScreenProperty, value); }
        }
    }
}