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
    partial class BootPagination
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
        public Size Size { get; set; } = Size.Default;

        /// <summary>
        /// 设置当页码发生改变时触发的事件。
        /// </summary>
        [Parameter]
        public EventCallback<int> OnPageChanged { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示是否显示分页的状态标签，例如：“当前 1/4 页 共 233 条记录”，默认是 <c>true</c>。
        /// </summary>
        [Parameter]
        public bool ShowStatusLabel { get; set; } = true;
        /// <summary>
        /// 设置一个布尔值，表示是否显示“跳转到”的组件。默认是 <c>true</c>。
        /// </summary>
        [Parameter]
        public bool ShowNavigateTo { get; set; } = true;

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


            if (Size != Size.Default)
            {
                classList.Add(ComponentUtil.GetSizeCssClass(Size, "pagination-"));
            }
        }

        /// <summary>
        /// 导航到首页。
        /// </summary>
        public async Task NavigateToFirst()
        {
            SetCurrentPage(1);
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
            SetCurrentPage(TotalPages);
            await OnPageChanged.InvokeAsync(CurrentPage);
            StateHasChanged();
        }

        /// <summary>
        /// 导航到自定义页。
        /// </summary>
        /// <param name="page">要导航的页。</param>
        public async Task NavigateToPage(int page)
        {
            SetCurrentPage(page);
            await OnPageChanged.InvokeAsync(page);
            StateHasChanged();
        }

        /// <summary>
        /// 设置当前分页的页码。
        /// </summary>
        /// <param name="page">要设置的分页页码。</param>
        public void SetCurrentPage(int page)
        {
            CurrentPage = page;
        }

        /// <summary>
        /// 设置每页的呈现的数据。
        /// </summary>
        /// <param name="size">每页呈现的数据。</param>
        public void SetPageSize(int size)
        {
            PageSize = size;
        }

        /// <summary>
        /// 设置分页的总共记录数量。
        /// </summary>
        /// <param name="count">总记录数量。</param>
        public void SetTotalCount(int count)
            => TotalCount = count;
    }
}
