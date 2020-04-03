using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BootBlazorUI
{
    /// <summary>
    /// 表示一个按钮。
    /// </summary>
    partial class BootButton
    {
        /// <summary>
        /// 初始化 <see cref="BootButton"/> 类的新实例。
        /// </summary>
        public BootButton()
        {

        }

        /// <summary>
        /// 设置为块状显示，独占一行。
        /// </summary>
        [Parameter]
        public bool Blocked { get; set; }

        /// <summary>
        /// 设置按钮的主题配色。默认是 <see cref="Color.Primary"/>。
        /// </summary>
        [Parameter]
        public Color Color { get; set; } = Color.Primary;

        /// <summary>
        /// 设置按钮的尺寸。
        /// </summary>
        [Parameter]
        public Size Size { get; set; } = Size.Default;

        /// <summary>
        /// 设置按钮的类型。默认是 <see cref="ButtonType.Button"/>
        /// </summary>
        [Parameter]
        public ButtonType Type { get; set; } = ButtonType.Button;

        /// <summary>
        /// 设置一个布尔值，表示呈现为边框样式。
        /// </summary>
        [Parameter]
        public bool Outline { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示按钮呈现为启用状态的样式。
        /// </summary>
        [Parameter]
        public bool Actived { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示按钮呈现为禁用状态的样式。
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; }

        /// <summary>
        /// 设置按钮的内容。
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 当点击按钮时触发的事件。
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }
        
        /// <summary>
        /// 当按钮被禁用时触发的事件。事件参数表示是否被禁用。<c>true</c> 表示禁用状态，否则是 <c>false</c>。
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnDisabled { get; set; }

        /// <summary>
        /// 当按钮被激活时触发的事件。事件参数表示是否被激活。<c>true</c> 表示禁用状态，否则是 <c>false</c>。
        /// </summary>
        [Parameter]
        public EventCallback<bool> OnActived { get; set; }

        protected override void BuildCssClass(List<string> classList)
        {
            classList.Add("btn");

            if (Blocked)
            {
                classList.Add("btn-block");
            }

            classList.Add(string.Format(" btn{0}-{1}", (Outline ? "-outline" : string.Empty), ComponentUtil.GetColorCssClass(Color)));
            if (Size != Size.Default)
            {
                classList.Add(ComponentUtil.GetSizeCssClass(Size, "btn-"));
            }

            if (Actived)
            {
                classList.Add("active");
            }
        }

        /// <summary>
        /// 禁用按钮的状态。
        /// </summary>
        /// <param name="disabled">是否禁用按钮。</param>
        public async Task Disable(bool disabled = true)
        {
            Disabled = disabled;
            await OnDisabled.InvokeAsync(disabled);
        }
        /// <summary>
        /// 激活按钮的状态。
        /// </summary>
        /// <param name="actived">是否激活按钮。</param>
        public async Task Active(bool actived = true)
        {
            Actived = actived;
            await OnActived.InvokeAsync(actived);
        }

        /// <summary>
        /// 表示按钮的类型。
        /// </summary>
        public enum ButtonType
        {
            /// <summary>
            /// 普通的按钮。
            /// </summary>
            Button,
            /// <summary>
            /// 表单提交的按钮。
            /// </summary>
            Submit,
            /// <summary>
            /// 表单重置按钮。
            /// </summary>
            Reset
        }
    }
}
