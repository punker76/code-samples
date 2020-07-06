using System;
using System.Linq;
using System.Windows;
using System.Windows.Navigation;
using MahApps.Metro.Controls;
using MenuItem = MahAppsMetroHamburgerMenuNavigation.ViewModels.MenuItem;

namespace MahAppsMetroHamburgerMenuNavigation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private readonly Navigation.NavigationServiceEx navigationServiceEx;

        public MainWindow()
        {
            this.InitializeComponent();

            this.navigationServiceEx = new Navigation.NavigationServiceEx();
            this.navigationServiceEx.Navigated += this.SplitViewFrame_OnNavigated;
            this.HamburgerMenuControl.Content = this.navigationServiceEx.Frame;

            // Navigate to the home page.
            this.Loaded += (sender, args) => this.navigationServiceEx.Navigate(new Uri("Views/MainPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void SplitViewFrame_OnNavigated(object sender, NavigationEventArgs e)
        {
            // select the menu item
            this.HamburgerMenuControl.SelectedItem = this.HamburgerMenuControl.Items.OfType<MenuItem>().FirstOrDefault(x => x.NavigationDestination == e.Uri);
            this.HamburgerMenuControl.SelectedOptionsItem = this.HamburgerMenuControl.OptionsItems.OfType<MenuItem>().FirstOrDefault(x => x.NavigationDestination == e.Uri);

            // or
            // this.HamburgerMenuControl.SelectedItem = this.HamburgerMenuControl.Items.OfType<MenuItem>().FirstOrDefault(x => x.NavigationType == e.Content?.GetType());
            // this.HamburgerMenuControl.SelectedOptionsItem = this.HamburgerMenuControl.OptionsItems.OfType<MenuItem>().FirstOrDefault(x => x.NavigationType == e.Content?.GetType());

            // update back button
            this.GoBackButton.Visibility = this.navigationServiceEx.CanGoBack ? Visibility.Visible : Visibility.Collapsed;
        }

        private void GoBack_OnClick(object sender, RoutedEventArgs e)
        {
            this.navigationServiceEx.GoBack();
        }

        private void HamburgerMenuControl_OnItemInvoked(object sender, HamburgerMenuItemInvokedEventArgs e)
        {
            if (e.InvokedItem is MenuItem menuItem && menuItem.IsNavigation)
            {
                this.navigationServiceEx.Navigate(menuItem.NavigationDestination);
            }
        }
    }
}