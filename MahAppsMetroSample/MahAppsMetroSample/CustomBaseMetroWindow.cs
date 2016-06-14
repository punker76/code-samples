using System.Windows;
using MahApps.Metro.Controls;

namespace MahAppsMetroSample
{
    public class CustomBaseMetroWindow : MetroWindow
    {
        static CustomBaseMetroWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomBaseMetroWindow), new FrameworkPropertyMetadata(typeof(CustomBaseMetroWindow)));
        }
    }
}