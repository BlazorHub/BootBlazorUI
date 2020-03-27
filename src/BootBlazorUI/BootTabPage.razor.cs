using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace BootBlazorUI
{
    /// <summary>
    /// 表示标签控件的页面。
    /// </summary>
    partial class BootTabPage
    {
        /// <summary>
        /// 标签控件。
        /// </summary>
        [CascadingParameter]
        private BootTabControl Parent { get; set; }

        /// <summary>
        /// 设置标签页内容。
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 设置标签页面标题。
        /// </summary>
        [Parameter]
        public string Title { get; set; }

        /// <summary>
        /// 设置当标签页被激活时触发的事件。
        /// </summary>
        [Parameter]
        public EventCallback<BootTabPage> OnActived { get; set; }

        protected override void OnInitialized()
        {
            if (Parent == null)
            {
                throw new ArgumentNullException(nameof(Parent), "TabPage 必须在 TabControl 内部创建");
            }
            base.OnInitialized();
            Parent.AddPage(this);
        }

        protected override void BuildCssClass(List<string> classList)
        {
            classList.Add("tab-pane");

            if (Parent.ActivedPage == this)
            {
                classList.Add("active");
            }
        }
    }
}
