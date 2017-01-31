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
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            HamburgerMenuControl.SelectedIndex = -1;
            HamburgerMenuControl.SelectedOptionsIndex = -1;
        }
    }
}
