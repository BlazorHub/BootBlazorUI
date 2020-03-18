using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BootBlazorUI
{
    /// <summary>
    /// 表示一个按钮。
    /// </summary>
    public partial class Button
    {
        /// <summary>
        /// 初始化 <see cref="Button"/> 类的新实例。
        /// </summary>
        public Button()
        {

        }

        /// <summary>
        /// 设置为块状显示，独占一行。
        /// </summary>
        [Parameter]
        public bool Blocked { get; set; }

        /// <summary>
        /// 设置按钮的主题配色。默认是 <see cref="ControlColor.Primary"/>。
        /// </summary>
        [Parameter]
        public ControlColor Color { get; set; } = ControlColor.Primary;

        /// <summary>
        /// 设置按钮的尺寸。
        /// </summary>
        [Parameter]
        public ControlSize Size { get; set; } = ControlSize.Default;

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


        protected override void BuildCssClass(List<string> classList)
        {
            classList.Add("btn");

            if (Blocked)
            {
                classList.Add("btn-block");
            }

            classList.Add(string.Format(" btn{0}-{1}", (Outline ? "-outline" : string.Empty), ComponentsHelper.GetColorName(Color)));
            if (Size != ControlSize.Default)
            {
                classList.Add($"btn-{ComponentsHelper.GetSizeName(Size)}");
            }

            if (Actived)
            {
                classList.Add("active");
            }

            classList.Add($"{CssClass}");
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
