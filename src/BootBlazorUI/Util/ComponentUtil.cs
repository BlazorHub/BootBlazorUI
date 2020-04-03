namespace BootBlazorUI
{
    /// <summary>
    /// 组件工具类。
    /// </summary>
    static class ComponentUtil
    {
        /// <summary>
        /// 获取颜色主题的 css 类名称。
        /// </summary>
        /// <param name="color">颜色主题。</param>
        /// <param name="prefix">前缀。</param>
        internal static string GetColorCssClass(Color color,string prefix=default)
            =>$"{prefix}{color.ToString().ToLower()}";

        /// <summary>
        /// 获取尺寸的 css 类名称。
        /// </summary>
        /// <param name="size">尺寸。</param>
        /// <param name="prefix">前缀。</param>
        internal static string GetSizeCssClass(Size size, string prefix = default)
            => $"{prefix}{size.ToString().ToLower()}";
    }
}
