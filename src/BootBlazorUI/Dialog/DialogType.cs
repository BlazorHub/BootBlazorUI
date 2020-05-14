namespace BootBlazorUI.Dialog
{
    /// <summary>
    /// 对话框类型。
    /// </summary>
    public enum DialogType
    {
        /// <summary>
        /// 提示框。显示【确认】按钮。
        /// </summary>
        Alert,
        /// <summary>
        /// 确认框。显示【确定】和【取消】两个按钮。
        /// </summary>
        Confirm,
        /// <summary>
        /// 输入框。显示一个文本框和【确定】【取消】两个按钮。
        /// </summary>
        Prompt,
    }
}
