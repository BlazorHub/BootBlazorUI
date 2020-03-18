using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BootBlazorUI
{
    /// <summary>
    /// 表示模态对话框。
    /// </summary>
    public partial class Modal: ComponentBase
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
        /// 设置其他未定义的属性。
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> AdditianalAttributes { get; set; }

        /// <summary>
        /// 获取一个布尔值，表示模态框是否已经显示。
        /// </summary>
        public bool IsShown { get;private set; }

        /// <summary>
        /// 设置模态框显示之前触发的事件。
        /// </summary>
        [Parameter]
        public EventCallback OnShowing { get; set; }

        /// <summary>
        /// 设置模态框隐藏之前触发的事件。
        /// </summary>
        [Parameter]
        public EventCallback OnHiding { get; set; }

        /// <summary>
        /// 根据配置构造 css 样式。
        /// </summary>
        /// <returns></returns>
        string BuildModalClass()
        {
            var cssList = new List<string>();

            if (Centered)
            {
                cssList.Add("modal-dialog-centered");
            }

            if (Size != ControlSize.Default)
            {
                cssList.Add($"modal-{Size.ToString().ToLower()}");
            }

            if (Scrollable)
            {
                cssList.Add("modal-dialog-scrollable");
            }

            return string.Join(" ", cssList);
        }

        /// <summary>
        /// 显示模态对话框。
        /// </summary>
        public async Task Show()
        {
            await OnShowing.InvokeAsync(this);
            IsShown = true;
            StateHasChanged();
        }

        /// <summary>
        /// 隐藏模态对话框。
        /// </summary>
        public async Task Hide()
        {
            await OnHiding.InvokeAsync(this);
            IsShown = false;
            StateHasChanged();
        }
    }
}
