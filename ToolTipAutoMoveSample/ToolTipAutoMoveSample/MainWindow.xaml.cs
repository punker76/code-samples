using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToolTipAutoMoveSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            tt.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
            tt.HorizontalOffset = e.GetPosition((IInputElement)sender).X + 16;
            tt.VerticalOffset = e.GetPosition((IInputElement)sender).Y + 16;
        }
    }
}
