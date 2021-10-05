using System.Windows;

namespace MahAppsMetroStyleOnlyWindowSample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = this;
            this.InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            new CleanWindow() { Owner = this }.ShowDialog();
        }
    }
}