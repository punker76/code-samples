using System.Windows;

namespace MahAppsMetroSample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            new CleanWindow() { Owner = this }.ShowDialog();
        }
    }
}