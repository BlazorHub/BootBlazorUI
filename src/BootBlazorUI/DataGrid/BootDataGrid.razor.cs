using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BootBlazorUI.DataGrid
{
    /// <summary>
    /// 表示可进行数据绑定的数据表格。
    /// </summary>
    partial class BootDataGrid
    {
        /// <summary>
        /// 设置一个布尔值，表示是否要固定标题栏。
        /// </summary>
        [Parameter]
        public bool FixHeader { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示是否表格第一列使用行号。
        /// </summary>
        [Parameter]
        public bool RowNumber { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示每一行是否显示间隔颜色。
        /// </summary>
        [Parameter]
        public bool Striped { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示每一个单元格是否显示边框。
        /// </summary>
        [Parameter]
        public bool Bordered { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示每一个单元格是否不显示边框。
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
        /// 设置一个布尔值，表示是否使用紧凑行间距。
        /// </summary>
        [Parameter]
        public bool Small { get; set; }


        /// <summary>
        /// 设置数据表格的内容。
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示是否显示分页。
        /// </summary>
        [Parameter]
        public bool ShowPagination { get; set; }

        /// <summary>
        /// 设置呈现每一次分页的数据量。默认是 <see cref="int.MaxValue"/>。
        /// </summary>
        [Parameter]
        public int PageSize { get; set; } = int.MaxValue;

        /// <summary>
        /// 设置分页所需要的总共的数据量。
        /// </summary>
        [Parameter]
        public int TotalRecordCount { get; set; }

        /// <summary>
        /// 设置数据行的固定高度。单位是 px。
        /// </summary>
        [Parameter]
        public int? FixRowHeight { get; set; }

        /// <summary>
        /// 设置数据绑定的方法。
        /// </summary>
        [Parameter]
        public Func<int,object> DataBind { get; set; }

        /// <summary>
        /// 设置当数据行被点击后触发的事件。
        /// </summary>
        [Parameter]
        public EventCallback<BootDataGridSelectedRowEventArgs> OnRowClick { get; set; }


        protected override async Task OnInitializedAsync()
        {
            if (DataBind == null)
            {
                throw new ArgumentException($"必须设置 {nameof(DataBind)} 参数");
            }

            await LoadPaginationData(1);
        }

        /// <summary>
        /// 返回一个布尔值，表示数据是否已加载完成。
        /// </summary>
        /// <returns>若已加载完成，返回 <c>true</c>；否则返回 <c>false</c>。</returns>
        public bool IsCompleted { get; private set; }

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
        }
    }

   
}
