using System;
using System.Threading.Tasks;

namespace BootBlazorUI.Dialog
{
    /// <summary>
    /// 提供对话框的功能。
    /// </summary>
    public interface IDialogService : IDisposable
    {
        /// <summary>
        /// 显示指定类型的对话框。
        /// </summary>
        /// <param name="options">对话框选项。</param>
        void Show(DialogOptions options=default);

        /// <summary>
        /// 获取对话框。
        /// </summary>
        Dialog Dialog { get; }

        /// <summary>
        /// 定义当对话框更新时触发的事件。
        /// </summary>
        event Action OnDialogUpdate;
    }
}
