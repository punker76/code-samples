using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace ToolTipAutoMoveSample
{
    public static class ToolTipHelper
    {
        public static readonly DependencyProperty AutoMoveProperty =
            DependencyProperty.RegisterAttached("AutoMove",
                                                typeof(bool),
                                                typeof(ToolTipHelper),
                                                new FrameworkPropertyMetadata(false, AutoMovePropertyChangedCallback));

        public static readonly DependencyProperty AutoMoveHorizontalOffsetProperty =
            DependencyProperty.RegisterAttached("AutoMoveHorizontalOffset",
                                                typeof(double),
                                                typeof(ToolTipHelper),
                                                new FrameworkPropertyMetadata(16d));

        public static readonly DependencyProperty AutoMoveVerticalOffsetProperty =
            DependencyProperty.RegisterAttached("AutoMoveVerticalOffset",
                                                typeof(double),
                                                typeof(ToolTipHelper),
                                                new FrameworkPropertyMetadata(16d));

        /// <summary>
        /// Enables a ToolTip to follow the mouse cursor.
        /// When set to <c>true</c>, the tool tip follows the mouse cursor.
        /// </summary>
        [AttachedPropertyBrowsableForType(typeof(ToolTip))]
        public static bool GetAutoMove(ToolTip element)
        {
            return (bool)element.GetValue(AutoMoveProperty);
        }

        public static void SetAutoMove(ToolTip element, bool value)
        {
            element.SetValue(AutoMoveProperty, value);
        }

        [AttachedPropertyBrowsableForType(typeof(ToolTip))]
        public static double GetAutoMoveHorizontalOffset(ToolTip element)
        {
            return (double)element.GetValue(AutoMoveHorizontalOffsetProperty);
        }

        public static void SetAutoMoveHorizontalOffset(ToolTip element, double value)
        {
            element.SetValue(AutoMoveHorizontalOffsetProperty, value);
        }

        [AttachedPropertyBrowsableForType(typeof(ToolTip))]
        public static double GetAutoMoveVerticalOffset(ToolTip element)
        {
            return (double)element.GetValue(AutoMoveVerticalOffsetProperty);
        }

        public static void SetAutoMoveVerticalOffset(ToolTip element, double value)
        {
            element.SetValue(AutoMoveVerticalOffsetProperty, value);
        }

        private static void AutoMovePropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {
            var toolTip = (ToolTip)dependencyObject;
            if (eventArgs.OldValue != eventArgs.NewValue && eventArgs.NewValue != null)
            {
                var autoMove = (bool)eventArgs.NewValue;
                if (autoMove)
                {
                    toolTip.Opened += ToolTip_Opened;
                    toolTip.Closed += ToolTip_Closed;
                }
                else
                {
                    toolTip.Opened -= ToolTip_Opened;
                    toolTip.Closed -= ToolTip_Closed;
                }
            }
        }

        private static void ToolTip_Opened(object sender, RoutedEventArgs e)
        {
            var toolTip = (ToolTip)sender;
            var target = toolTip.PlacementTarget as FrameworkElement;
            if (target != null)
            {
                // move the tooltip on openeing to the correct position
                MoveToolTip(target, toolTip);
                target.MouseMove += ToolTipTargetPreviewMouseMove;
                Debug.WriteLine(">>tool tip opened");
            }
        }

        private static void ToolTip_Closed(object sender, RoutedEventArgs e)
        {
            var toolTip = (ToolTip)sender;
            var target = toolTip.PlacementTarget as FrameworkElement;
            if (target != null)
            {
                target.MouseMove -= ToolTipTargetPreviewMouseMove;
                Debug.WriteLine(">>tool tip closed");
            }
        }

        private static void ToolTipTargetPreviewMouseMove(object sender, MouseEventArgs e)
        {
            var target = sender as FrameworkElement;
            var toolTip = (target != null ? target.ToolTip : null) as ToolTip;
            MoveToolTip(sender as IInputElement, toolTip);
        }

        private static void MoveToolTip(IInputElement target, ToolTip toolTip)
        {
            if (toolTip == null || target == null || toolTip.PlacementTarget == null)
            {
                return;
            }

            toolTip.Placement = PlacementMode.Relative;

            var hOffset = DpiHelper.TransformToDeviceX(GetAutoMoveHorizontalOffset(toolTip));
            var vOffset = DpiHelper.TransformToDeviceY(GetAutoMoveVerticalOffset(toolTip));

            var position = Mouse.GetPosition(toolTip.PlacementTarget);
            var horizontalOffset = position.X + hOffset;
            var verticalOffset = position.Y + vOffset;

            var topLeftFromScreen = toolTip.PlacementTarget.PointToScreen(new Point(0, 0));

            var monitorRECT = MonitorHelper.GetMonitorSizeFromPoint();
            Debug.WriteLine(">>mo {0} / {1}", monitorRECT.Width, monitorRECT.Height);

            var screenWidth = Math.Abs(monitorRECT.Width);// (int)DpiHelper.TransformToDeviceX(toolTip.PlacementTarget, SystemParameters.PrimaryScreenWidth);
            var screenHeight = Math.Abs(monitorRECT.Height);// (int)DpiHelper.TransformToDeviceY(toolTip.PlacementTarget, SystemParameters.PrimaryScreenHeight);

            var locationX = (int)topLeftFromScreen.X % screenWidth;
            var locationY = (int)topLeftFromScreen.Y % screenHeight;

            if (locationX + horizontalOffset + DpiHelper.TransformToDeviceX(toolTip.RenderSize.Width) > screenWidth)
            {
                horizontalOffset = horizontalOffset - toolTip.RenderSize.Width - 1.5 * hOffset;
            }
            if (locationY + verticalOffset + DpiHelper.TransformToDeviceY(toolTip.RenderSize.Height) > screenHeight)
            {
                verticalOffset = verticalOffset - toolTip.RenderSize.Height - 1.5 * vOffset;
            }

            toolTip.HorizontalOffset = horizontalOffset;
            toolTip.VerticalOffset = verticalOffset;

            Debug.WriteLine(">>ho {0:.2f} >> vo {1:.2f}", toolTip.HorizontalOffset, toolTip.VerticalOffset);
        }
    }
}