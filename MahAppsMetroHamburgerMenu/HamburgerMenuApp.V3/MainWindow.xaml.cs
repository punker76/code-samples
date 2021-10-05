using System.Windows;
using MahApps.Metro.Controls;

namespace HamburgerMenuApp.V3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ((MainViewModel)this.DataContext).CreateMenuItems();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            HamburgerMenuControl.SetCurrentValue(HamburgerMenu.SelectedIndexProperty, -1);
            HamburgerMenuControl.SetCurrentValue(HamburgerMenu.SelectedOptionsIndexProperty, -1);
        }
    }
}