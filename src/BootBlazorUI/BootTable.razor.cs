using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI
{
    /// <summary>
    /// 表示表格的部分。
    /// </summary>
    public partial class BootTable<TItem>
    {
        /// <summary>
        /// 设置表格的列头模板。
        /// </summary>
        [Parameter]
        public RenderFragment HeadTemplate { get; set; }

        /// <summary>
        /// 设置表格的行模板。
        /// </summary>
        [Parameter]
        public RenderFragment<TItem> RowTemplate { get; set; }

        /// <summary>
        /// 设置底部的模板。
        /// </summary>
        [Parameter]
        public RenderFragment FootTemplate { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示是否表格第一列使用行号。
        /// </summary>
        [Parameter]
        public bool RowNumber { get; set; }

        /// <summary>
        /// 设置行号的表格标题名称。默认是“#”
        /// </summary>
        [Parameter]
        public string RowNumberHead { get; set; } = "#";

        /// <summary>
        /// 设置行号列的宽度，单位 px。默认 10px。
        /// </summary>
        [Parameter]
        public int RowNumberWidth { get; set; } = 10;

        /// <summary>
        /// 设置一个布尔值，表示每一个 tr 是否显示间隔颜色。
        /// </summary>
        [Parameter]
        public bool Striped { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示每一个 td/th 是否显示边框。
        /// </summary>
        [Parameter]
        public bool Bordered { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示所有的 td/th 是否不显示边框。
        /// </summary>
        [Parameter]
        public bool Borderless { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示表格使用深色背景显示。
        /// </summary>
        [Parameter]
        public bool Dark { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示行在鼠标悬浮时是否有颜色高亮。
        /// </summary>
        [Parameter]
        public bool Hover { get; set; }
        /// <summary>
        /// 设置一个布尔值，表示使用小尺寸的表格。
        /// </summary>
        [Parameter]
        public bool Small { get; set; }

        /// <summary>
        /// 设置表格的数据源。
        /// </summary>
        [Parameter]
        public IReadOnlyList<TItem> DataSource { get; set; }

        /// <summary>
        /// 设置表格的主题颜色。
        /// </summary>
        [Parameter]
        public Color? TableColor { get; set; }

        /// <summary>
        /// 设置表格的背景颜色。
        /// </summary>
        [Parameter]
        public Color? BackgroundColor { get; set; }

        /// <summary>
        /// 设置表格的字体前景色。
        /// </summary>
        [Parameter]
        public Color? ForeColor { get; set; }

        protected override void BuildCssClass(List<string> classList)
        {
            classList.Add("table");

            if (Striped)
            {
                classList.Add("table-striped");
            }
            if (Bordered)
            {
                classList.Add("table-bordered");
            }
            if (Borderless)
            {
                classList.Add("table-borderless");
            }
            if (Dark)
            {
                classList.Add("table-dark");
            }
            if (Hover)
            {
                classList.Add("table-hover");
            }
            if (Small)
            {
                classList.Add("table-sm");
            }

            if (TableColor.HasValue)
            {
                classList.Add(ComponentUtil.GetColorCssClass(TableColor.Value, "table-"));
            }
            if (BackgroundColor.HasValue)
            {
                classList.Add(ComponentUtil.GetColorCssClass(BackgroundColor.Value, "bg-"));
            }
            if (ForeColor.HasValue)
            {
                classList.Add(ComponentUtil.GetColorCssClass(ForeColor.Value, "text-"));
            }
        }
    }
}
