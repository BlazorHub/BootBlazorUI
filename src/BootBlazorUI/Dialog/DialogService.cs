using System;
using Microsoft.Extensions.Options;

namespace BootBlazorUI.Dialog
{
    /// <summary>
    /// 对话框的默认服务。
    /// </summary>
    internal class DialogService : IDialogService
    {
        private readonly DialogOptions _options;

        public DialogService(IOptions<DialogOptions> options)
        {
            this._options = options.Value;
        }

        public Dialog Dialog { get; private set; }

        public event Action OnDialogUpdate;

        public void Dispose()
        {
            Dialog = null;
        }

        public void Show(DialogOptions options=default)
        {
            Dialog = new Dialog(options ?? _options);
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
