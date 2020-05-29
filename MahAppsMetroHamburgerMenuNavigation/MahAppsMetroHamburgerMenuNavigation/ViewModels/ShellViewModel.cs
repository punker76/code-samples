using System;
using MahApps.Metro.IconPacks;
using MahAppsMetroHamburgerMenuNavigation.Views;

namespace MahAppsMetroHamburgerMenuNavigation.ViewModels
{
    internal class ShellViewModel : ViewModelBase
    {
        public ShellViewModel()
        {
            // Build the menus
            this.Menu.Add(new MenuItem() {Icon = new PackIconFontAwesome() {Kind = PackIconFontAwesomeKind.BugSolid}, Text = "Bugs", NavigationType = typeof(BugsPage), NavigationDestination = new Uri("Views/BugsPage.xaml", UriKind.RelativeOrAbsolute)});
            this.Menu.Add(new MenuItem() {Icon = new PackIconFontAwesome() {Kind = PackIconFontAwesomeKind.UserSolid}, Text = "User", NavigationType = typeof(UserPage), NavigationDestination = new Uri("Views/UserPage.xaml", UriKind.RelativeOrAbsolute)});
            this.Menu.Add(new MenuItem() {Icon = new PackIconFontAwesome() {Kind = PackIconFontAwesomeKind.CoffeeSolid}, Text = "Break", NavigationType = typeof(BreakPage), NavigationDestination = new Uri("Views/BreakPage.xaml", UriKind.RelativeOrAbsolute)});
            this.Menu.Add(new MenuItem() {Icon = new PackIconFontAwesome() {Kind = PackIconFontAwesomeKind.FontAwesomeBrands}, Text = "Awesome", NavigationType = typeof(AwesomePage), NavigationDestination = new Uri("Views/AwesomePage.xaml", UriKind.RelativeOrAbsolute)});

            this.OptionsMenu.Add(new MenuItem() {Icon = new PackIconFontAwesome() {Kind = PackIconFontAwesomeKind.CogsSolid}, Text = "Settings", NavigationType = typeof(SettingsPage), NavigationDestination = new Uri("Views/SettingsPage.xaml", UriKind.RelativeOrAbsolute)});
            this.OptionsMenu.Add(new MenuItem() {Icon = new PackIconFontAwesome() {Kind = PackIconFontAwesomeKind.InfoCircleSolid}, Text = "About", NavigationType = typeof(AboutPage), NavigationDestination = new Uri("Views/AboutPage.xaml", UriKind.RelativeOrAbsolute)});
        }
    }
}