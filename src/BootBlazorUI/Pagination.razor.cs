using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BootBlazorUI
{
    /// <summary>
    /// 表示分页的组件。
    /// </summary>
    partial class Pagination
    {
        /// <summary>
        /// 设置当前页码，必须大于 0。默认是 1。
        /// </summary>
        [Parameter]
        public int CurrentPage { get; set; } = 1;
        /// <summary>
        /// 设置分页的数据量。默认是 10。
        /// </summary>
        [Parameter]
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// 设置数据的总记录数。
        /// </summary>
        [Parameter]
        public int TotalCount { get; set; }

        /// <summary>
        /// 设置“首页”的文本。
        /// </summary>
        [Parameter]
        public string FirstPageText { get; set; } = "首页";

        /// <summary>
        /// 设置“上一页”的文本。
        /// </summary>
        [Parameter]
        public string PreviousPageText { get; set; } = "上一页";

        /// <summary>
        /// 设置“下一页”的文本。
        /// </summary>
        [Parameter]
        public string NextPageText { get; set; } = "下一页";

        /// <summary>
        /// 设置“最后一页”的文本。
        /// </summary>
        [Parameter]
        public string LastPageText { get; set; } = "末页";

        /// <summary>
        /// 设置一个布尔值，表示当页数在第1页或最后1页时，使用隐藏或禁用的方式呈现“首页/上一页”或“末页/下一页”。
        /// <para>
        /// <c>true</c> 表示隐藏，否则为 <c>false</c>。默认是 <c>false</c>。
        /// </para>
        /// </summary>
        [Parameter]
        public bool HideOrDisable { get; set; }

        /// <summary>
        /// 设置分页的尺寸。
        /// </summary>
        [Parameter]
        public ControlSize Size { get; set; } = ControlSize.Default;

        /// <summary>
        /// 设置当页码发生改变时触发的事件。
        /// </summary>
        [Parameter]
        public EventCallback<int> OnPageChanged { get; set; }

        /// <summary>
        /// 获取总页数。
        /// </summary>
        public int TotalPages => (TotalCount + PageSize - 1) / PageSize;

        protected override void OnInitialized()
        {
            if (CurrentPage <= 0)
            {
                throw new ArgumentException("不能小于1", nameof(CurrentPage));
            }


            base.OnInitialized();
        }

        protected override void BuildCssClass(List<string> classList)
        {
            classList.Add("pagination");


            if (Size != ControlSize.Default)
            {
                classList.Add(ComponentsHelper.GetSizeName(Size, "pagination-"));
            }
        }

        /// <summary>
        /// 导航到首页。
        /// </summary>
        public async Task NavigateToFirst()
        {
            CurrentPage = 1;
            await OnPageChanged.InvokeAsync(CurrentPage);
            StateHasChanged();
        }

        /// <summary>
        /// 导航到上一页。
        /// </summary>
        public async Task NavigateToPrevious()
        {
            if (CurrentPage <= 1)
            {
                CurrentPage = 1;
            }
            else
            {
                CurrentPage--;
            }
            await OnPageChanged.InvokeAsync(CurrentPage);
            StateHasChanged();
        }

        /// <summary>
        /// 导航到下一页。
        /// </summary>
        public async Task NavigateToNext()
        {
            if (CurrentPage >= TotalPages)
            {
                CurrentPage = TotalPages;
            }
            else
            {
                CurrentPage++;
            }
            await OnPageChanged.InvokeAsync(CurrentPage);
            StateHasChanged();
        }

        /// <summary>
        /// 导航到末页。
        /// </summary>
        public async Task NavigateToLast()
        {
            CurrentPage = TotalPages;
            await OnPageChanged.InvokeAsync(CurrentPage);
            StateHasChanged();
        }

        /// <summary>
        /// 导航到自定义页。
        /// </summary>
        /// <param name="page">要导航的页。</param>
        public async Task NavigateToPage(int page)
        {
            CurrentPage = page;
            await OnPageChanged.InvokeAsync(page);
            StateHasChanged();
        }


    }
}
