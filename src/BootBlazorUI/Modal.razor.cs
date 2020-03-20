using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BootBlazorUI
{
    /// <summary>
    /// 表示模态对话框。
    /// </summary>
    partial class Modal
    {
        /// <summary>
        /// 初始化 <see cref="Modal"/> 类的新实例
        /// </summary>
        public Modal()
        {

        }

        /// <summary>
        /// 设置模态框的头部模板。
        /// </summary>
        [Parameter]
        public RenderFragment HeaderTemplate { get; set; }
        /// <summary>
        /// 设置模态框的正文模板。
        /// </summary>
        [Parameter]
        public RenderFragment BodyTemplate { get; set; }
        /// <summary>
        /// 设置模态框的底部模板。
        /// </summary>
        [Parameter]
        public RenderFragment FooterTemplate { get; set; }

        /// <summary>
        /// 设置右上角是否有关闭的“X”，点击后可以关闭模态框。默认是 <c>true</c>。
        /// <para>
        /// 如果不定义 <see cref="HeaderTemplate"/> 则无法看见该按钮。
        /// </para>
        /// </summary>
        [Parameter]
        public bool Closable { get; set; } = true;

        /// <summary>
        /// 设置模态框显示在屏幕正中间的位置。
        /// </summary>
        [Parameter]
        public bool Centered { get; set; }

        /// <summary>
        /// 设置 <see cref="BodyTemplate"/> 内容超过屏幕一定高度时是否出现滚动条。
        /// </summary>
        [Parameter]
        public bool Scrollable { get; set; }

        /// <summary>
        /// 设置模态框的尺寸。仅 <see cref="ControlSize.SM"/> 和 <see cref="ControlSize.LG"/> 有效。
        /// <para>
        /// 默认为 <see cref="ControlSize.Default"/> 。
        /// </para>
        /// </summary>
        [Parameter]
        public ControlSize Size { get; set; }

        /// <summary>
        /// 获取一个布尔值，表示模态框是否已经显示。
        /// </summary>
        public bool IsShown { get;private set; }

        /// <summary>
        /// 设置模态框显示时触发的事件。事件参数表示模态框是否已显示。
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnShown { get; set; }

        /// <summary>
        /// 设置模态框隐藏时触发的事件。事件参数表示模态框是否已隐藏。
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnHidden { get; set; }

        protected override void BuildCssClass(List<string> classList)
        {
            if (Centered)
            {
                classList.Add("modal-dialog-centered");
            }

            if (Size != ControlSize.Default)
            {
                classList.Add(ComponentsHelper.GetSizeName(Size,"modal-"));
            }

            if (Scrollable)
            {
                classList.Add("modal-dialog-scrollable");
            }
        }


        /// <summary>
        /// 显示模态对话框。
        /// </summary>
        public async Task Show()
        {
            IsShown = true;
            StateHasChanged();
            await OnShown.InvokeAsync(IsShown);
        }

        /// <summary>
        /// 隐藏模态对话框。
        /// </summary>
        public async Task Hide()
        {
            IsShown = false;
            StateHasChanged();
            await OnHidden.InvokeAsync(IsShown);
        }
    }
}
