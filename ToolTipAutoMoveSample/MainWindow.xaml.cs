using System.Windows;
using System.Windows.Input;

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
            tt.SetCurrentValue(System.Windows.Controls.ToolTip.PlacementProperty, System.Windows.Controls.Primitives.PlacementMode.Relative);
            tt.SetCurrentValue(System.Windows.Controls.ToolTip.HorizontalOffsetProperty, e.GetPosition((IInputElement)sender).X + 16);
            tt.SetCurrentValue(System.Windows.Controls.ToolTip.VerticalOffsetProperty, e.GetPosition((IInputElement)sender).Y + 16);
        }
    }
}