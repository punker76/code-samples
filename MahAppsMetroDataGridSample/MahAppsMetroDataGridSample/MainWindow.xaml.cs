using System;
using MahApps.Metro.Controls;

namespace MahAppsMetroDataGridSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new MainViewModel();
            this.DataContext = viewModel;
            this.Loaded += (sender, args) => viewModel.Start();
            this.Closed += (sender, args) => viewModel.Stop();
        }
    }
}
