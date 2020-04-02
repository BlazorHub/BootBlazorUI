using System;
using System.Collections.Generic;
using System.Text;

namespace BootBlazorUI.Dialog
{
    /// <summary>
    /// 表示对话框的扩展。
    /// </summary>
    public static class DialogExtensions
    {
        /// <summary>
        /// 显示提示信息(Alert)的对话框。
        /// </summary>
        /// <param name="dialogService">对话框服务。</param>
        /// <param name="message">提示信息。</param>
        /// <param name="title">对话框标题，null 表示不显示。</param>
        /// <param name="onConfirm">当点击【确认】按钮后的操作，这是一个委托。</param>
        public static void ShowAlert(this IDialogService dialogService, string message, string title = default, Action<object> onConfirm = default)
        {
            dialogService.Show(new DialogOptions
            {
                Message = message,
                Title = title,
                Type = DialogType.Alert,
                Confirm = onConfirm
            });
        }

        /// <summary>
        /// 显示确认信息(Confirm)的对话框。
        /// </summary>
        /// <param name="dialogService">对话框服务。</param>
        /// <param name="message">提示信息。</param>
        /// <param name="title">对话框标题，null 表示不显示。</param>
        /// <param name="onConfirm">当点击【确认】按钮后的操作，这是一个委托。</param>
        /// <param name="onCancel">当点击【取消】按钮后的操作，这是一个委托。</param>
        public static void ShowConfirm(this IDialogService dialogService, string message, string title = default, Action<object> onConfirm = default, Action onCancel = default)
        {
            dialogService.Show(new DialogOptions
            {
                Message = message,
                Title = title,
                Type = DialogType.Confirm,
                Confirm = onConfirm,
                Cancel = onCancel
            });
        }

        /// <summary>
        /// 显示弹出输入信息(Prompt)的对话框。
        /// </summary>
        /// <param name="dialogService">对话框服务。</param>
        /// <param name="message">提示信息。</param>
        /// <param name="title">对话框标题，null 表示不显示。</param>
        /// <param name="onConfirm">当点击【确认】按钮后的操作，这是一个委托，参数为文本框输入的值。</param>
        /// <param name="onCancel">当点击【取消】按钮后的操作，这是一个委托。</param>
        public static void ShowPropmt(this IDialogService dialogService, string message, string title = default, Action<object> onConfirm = default, Action onCancel = default)
        {
            dialogService.Show(new DialogOptions
            {
                Message = message,
                Title = title,
                Type = DialogType.Prompt,
                Confirm = onConfirm,
                Cancel = onCancel
            });
        }
    }
}
