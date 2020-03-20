using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BootBlazorUI
{
    /// <summary>
    /// 表示一个警告消息框控件。
    /// </summary>
    public partial class Alert
    {
        /// <summary>
        /// 初始化 <see cref="Alert"/> 类的新实例。
        /// </summary>
        public Alert()
        {

        }

        /// <summary>
        /// 设置消息框的主题颜色。默认是 <see cref="ControlColor.Primary"/>。
        /// </summary>
        [Parameter]
        public ControlColor Color { get; set; } = ControlColor.Primary;

        /// <summary>
        /// 设置消息框的任意内容。
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示是否在右侧显示一个关闭的“X”按钮，点击后则会隐藏该警告框。
        /// </summary>
        [Parameter]
        public bool Closable { get; set; }

        /// <summary>
        /// 获取一个布尔值，表示消息框的是否为显示状态。默认是 <c>true</c>。
        /// </summary>
        public bool IsShown { get;private set; } = true;

        /// <summary>
        /// 设置警告消息框显示前触发的事件。
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnShown { get; set; }

        /// <summary>
        /// 设置警告消息框隐藏前触发的事件。
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnHidden { get; set; }

        /// <summary>
        /// 显示当前警告消息框。
        /// </summary>
        public async Task Show()
        {
            IsShown = true;
            await OnShown.InvokeAsync(IsShown);
            StateHasChanged();
        }

        /// <summary>
        /// 隐藏当前警告消息框。
        /// </summary>
        public async Task Hide()
        {
            IsShown = false;
            await OnHidden.InvokeAsync(IsShown);
            StateHasChanged();
        }

        protected override void BuildCssClass(List<string> classList)
        {
            classList.Add("alert");
            classList.Add(ComponentsHelper.GetColorName(Color,"alert-"));

            if (Closable)
            {
                classList.Add("alert-dismissible");
            }
        }
    }
}
