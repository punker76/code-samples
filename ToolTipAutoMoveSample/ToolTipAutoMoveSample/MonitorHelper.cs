using System;
using Standard;

namespace ToolTipAutoMoveSample
{
    internal static class MonitorHelper
    {
        internal static RECT GetMonitorSizeFromPoint()
        {
            var cursorPos = NativeMethods.GetCursorPos();
            var monitor = NativeMethods.MonitorFromPoint(cursorPos, MonitorOptions.MONITOR_DEFAULTTONEAREST);
            if (monitor != IntPtr.Zero)
            {
                var monitorInfo = NativeMethods.GetMonitorInfo(monitor);
                var rcWorkArea = monitorInfo.rcWork;
                var rcMonitorArea = monitorInfo.rcMonitor;
                return rcWorkArea;
            }
            return new RECT();
        }
    }
}