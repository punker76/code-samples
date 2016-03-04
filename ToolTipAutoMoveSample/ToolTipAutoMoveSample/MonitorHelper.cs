using System;
using Standard;

namespace ToolTipAutoMoveSample
{
    internal static class MonitorHelper
    {
        internal static MONITORINFO GetMonitorInfoFromPoint()
        {
            var cursorPos = NativeMethods.GetCursorPos();
            var monitor = NativeMethods.MonitorFromPoint(cursorPos, MonitorOptions.MONITOR_DEFAULTTONEAREST);
            if (monitor != IntPtr.Zero)
            {
                MONITORINFO monitorInfo = NativeMethods.GetMonitorInfo(monitor);
                return monitorInfo;
            }
            return new MONITORINFO();
        }
    }
}