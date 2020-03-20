using System;
using System.Collections.Generic;
using System.Text;

namespace BootBlazorUI
{
    static class ComponentsHelper
    {
        internal static string GetColorName(ControlColor color,string prefix=default)
            =>$"{prefix}{color.ToString().ToLower()}";

        internal static string GetSizeName(ControlSize size, string prefix = default)
            => $"{prefix}{size.ToString().ToLower()}";
    }
}
