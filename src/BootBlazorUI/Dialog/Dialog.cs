using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BootBlazorUI.Dialog
{
    public class Dialog
    {
        internal Dialog(DialogOptions options)
        {
            Options = options;
        }

        public DialogOptions Options { get; }

        public Action OnClose;
    }
}
