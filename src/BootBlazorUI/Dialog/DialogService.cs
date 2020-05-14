using System;
using Microsoft.Extensions.Options;

namespace BootBlazorUI.Dialog
{
    /// <summary>
    /// 对话框的默认服务。
    /// </summary>
    internal class DialogService : IDialogService
    {
        private readonly DialogConfiguration _options;

        /// <summary>
        /// 初始化 <see cref="DialogService"/> 类的新实例。
        /// </summary>
        /// <param name="options"></param>
        public DialogService(IOptions<DialogConfiguration> options)
        {
            this._options = options.Value;
        }

        public Dialog Dialog { get; private set; }

        public event Action OnDialogUpdate;

        public void Dispose()
        {
            Dialog = null;
        }

        /// <summary>
        /// 显示对话框。
        /// </summary>
        /// <param name="configure">对话框配置。</param>
        public void Show(Action<DialogOptions> configure=default)
        {
            var options = new DialogOptions
            {
                CancelColor = _options.CancelColor,
                CancelSize = _options.CancelSize,
                CancelText = _options.CancelText,
                ConfirmColor = _options.ConfirmColor,
                ConfirmSize = _options.ConfirmSize,
                ConfirmText = _options.ConfirmText,
            };
            configure?.Invoke(options);

            Dialog = new Dialog(options);
            Dialog.OnClose += Close;
            OnDialogUpdate?.Invoke();
        }

        private void Close()
        {
            Dialog.Options.Cancel?.Invoke();
            Dispose();
            OnDialogUpdate?.Invoke();
        }
    }
}
