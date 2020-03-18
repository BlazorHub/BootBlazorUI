using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace BootBlazorUI
{
    /// <summary>
    /// 表示进度条。
    /// </summary>
    public partial class ProgressBar
    {
        /// <summary>
        /// 初始化 <see cref="ProgressBar"/> 类的新实例。
        /// </summary>
        public ProgressBar()
        {

        }

        /// <summary>
        /// 设置进度条的主题颜色。默认是 <see cref="ControlColor.Primary"/> 。
        /// </summary>
        [Parameter]
        public ControlColor Color { get; set; } = ControlColor.Primary;

        /// <summary>
        /// 设置进度条的最大值，默认是 100。
        /// </summary>
        [Parameter]
        public decimal Max { get; set; } = 100;

        /// <summary>
        /// 设置进度条的最小值，默认是 0，不能小于 0。
        /// </summary>
        [Parameter]
        public decimal Min { get; set; }
        /// <summary>
        /// 设置进度条当前的值，必须在 <see cref="Min"/> 和 <see cref="Max"/> 之间。
        /// </summary>
        [Parameter]
        public decimal Value { get; set; }

        /// <summary>
        /// 设置进度条的内容。
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 设置进度条自定义模板。
        /// </summary>
        [Parameter]
        public RenderFragment<ProgressBar> Template { get; set; }
        /// <summary>
        /// 设置一个布尔值，表示进度条是否呈现花纹状。
        /// </summary>
        [Parameter]
        public bool Striped { get; set; }

        /// <summary>
        /// 设置进度条的高度。单位是px。
        /// </summary>
        [Parameter]
        public int? Height { get; set; }

        /// <summary>
        /// 获取根据设置的 <see cref="Min"/> 和 <see cref="Max"/> 以及当前的 <see cref="Value"/> 计算进度条的百分比。
        /// </summary>
        public decimal Percentage => Math.Round((Value / (Max - Min)) * 100, 0);

        protected override void OnInitialized()
        {
            if (Min < 0 || Max < 0)
            {
                throw new ArgumentException($"{Min}和{Max}的值必须大于0");
            }
            if (Min >= Max)
            {
                throw new ArgumentException($"{Min}的值必须小于{Max}的值");
            }
            if (Value < Min || Value > Max)
            {
                throw new ArgumentException($"{Value}的值不能小于{Min}，且不能大于{Max}");
            }
        }

        protected override void BuildCssClass(List<string> classList)
        {
            classList.Add(ComponentsHelper.GetColorName(Color,"bg-"));
            classList.Add("progress-bar");
            if (Striped)
            {
                classList.Add("progress-bar-striped");
            }
        }

        protected override void BuildStyles(List<string> styleList)
        {
            var width = Percentage;
            if (width < 5)
            {
                width = 5;
            }

            styleList.Add($"width:{width}%");
        }
    }
}
