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
            this.InitializeComponent();
            this.TestColl = new ObservableCollection<string>(new[]
            {
                "Test 1",
                "Test 2",
                "Test 3",
            });
        }

        public static readonly DependencyProperty TestCollProperty
            = DependencyProperty.Register(
                nameof(TestColl),
                typeof(ObservableCollection<string>),
                typeof(MainWindow));

        public ObservableCollection<string> TestColl
        {
            get => (ObservableCollection<string>)GetValue(TestCollProperty);
            set => SetValue(TestCollProperty, value);
        }

        private void ButtonBase_OnClick(object sender, EventArgs e)
        {
            var w = new MetroWindow
            {
                GlowBrush = Brushes.Gray,
                BorderThickness = new Thickness(1),
                Title = "Modal",
                Width = 300,
                Height = 200,
                Owner = this,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            w.ShowDialog();
        }

        public static readonly DependencyProperty ToggleFullScreenProperty
            = DependencyProperty.Register(
                nameof(ToggleFullScreen),
                typeof(bool),
                typeof(MainWindow),
                new PropertyMetadata(default(bool), OnToggleFullScreenChanged));

        private static void OnToggleFullScreenChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && dependencyObject is MetroWindow metroWindow)
            {
                var fullScreen = (bool)e.NewValue;
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
            get => (bool)GetValue(ToggleFullScreenProperty);
            set => SetValue(ToggleFullScreenProperty, value);
        }
    }
}