using Microsoft.Win32;
using System;
using System.Drawing;

/// <summary>
/// author - nuk @ 1/6/2023
/// clock - 23:41 GMT+2
///</summary>

namespace HighlightColorChanger.util
{
    public static class RegistryUtil
    {
        static RegistryKey RegKey = Registry.CurrentUser.OpenSubKey(@"Control Panel\Colors\", true);

        public static void SetColorFromRegistry(Color Highlight, Color HotTracking)
        {
           RegKey.SetValue("Hilight", Highlight.R + " " + Highlight.G + " " + Highlight.B);
           RegKey.SetValue("HotTrackingColor", HotTracking.R + " " + HotTracking.G + " " + HotTracking.B);
        }
    }
}
