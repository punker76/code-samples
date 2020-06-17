using System.Collections.ObjectModel;
using HamburgerMenuApp.Core.MVVM;
using MahApps.Metro.IconPacks;

namespace HamburgerMenuApp.V4.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private ObservableCollection<MenuItemViewModel> _menuItems;
        private ObservableCollection<MenuItemViewModel> _menuOptionItems;

        public MainViewModel()
        {
            this.CreateMenuItems();
        }

        public void CreateMenuItems()
        {
            MenuItems = new ObservableCollection<MenuItemViewModel>
            {
                new HomeViewModel(this)
                {
                    Icon = new PackIconMaterial() {Kind = PackIconMaterialKind.Home},
                    Label = "Home",
                    ToolTip = "Welcome Home"
                },
                new PrivateViewModel(this)
                {
                    Icon = new PackIconMaterial() {Kind = PackIconMaterialKind.AccountCircle},
                    Label = "Private",
                    ToolTip = "...42"
                },
                new AboutViewModel(this)
                {
                    Icon = new PackIconMaterial() {Kind = PackIconMaterialKind.Help},
                    Label = "About",
                    ToolTip = "About this one..."
                }
            };

            MenuOptionItems = new ObservableCollection<MenuItemViewModel>
            {
                new SettingsViewModel(this)
                {
                    Icon = new PackIconMaterial() {Kind = PackIconMaterialKind.Cog},
                    Label = "Settings",
                    ToolTip = "The App settings"
                }
            };
        }

        public ObservableCollection<MenuItemViewModel> MenuItems
        {
            get => _menuItems;
            set => SetProperty(ref _menuItems, value);
        }

        public ObservableCollection<MenuItemViewModel> MenuOptionItems
        {
            get => _menuOptionItems;
            set => SetProperty(ref _menuOptionItems, value);
        }
    }
}