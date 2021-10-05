using MahApps.Metro.Controls;

namespace HamburgerMenuApp
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

        private void HamburgerMenuControl_OnItemClick(object sender, ItemClickEventArgs e)
        {
            this.HamburgerMenuControl.SetCurrentValue(ContentProperty, e.ClickedItem);
            this.HamburgerMenuControl.SetCurrentValue(HamburgerMenu.IsPaneOpenProperty, false);
        }
    }
}