using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BootBlazorUI.DataGrid
{
    partial class BootDataGrid
    {
        /// <summary>
        /// 点击指定的行。
        /// </summary>
        /// <param name="item">被选择的行数据。</param>
        /// <param name="index">选择行的索引。</param>
        public async Task ClickRow(object item, int index)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (index < 0)
            {
                throw new ArgumentException($"选择行的索引必须大于0，但实际的值是'{index}'", nameof(index));
            }

            await OnRowClick.InvokeAsync(new BootDataGridSelectedRowEventArgs(item, index));
        }

        /// <summary>
        /// 向指定行追加指定的 css 类。
        /// </summary>
        /// <param name="index">指定的行索引。</param>
        /// <param name="cssClasses">css 类数组。</param>
        public void AppendRowCss(int index, params string[] cssClasses)
        {
            if (cssClasses is null)
            {
                throw new ArgumentNullException(nameof(cssClasses));
            }

            if (!RowCssList.ContainsKey(index))
            {
                RowCssList.Add(index, new List<string>(cssClasses));
            }
            else
            {
                RowCssList[index].AddRange(cssClasses);
            }
        }

        /// <summary>
        /// 向指定行追加指定的 style 自定义样式。
        /// </summary>
        /// <param name="index">指定的行索引。</param>
        /// <param name="styles">样式数组。</param>
        public void AppendRowStyle(int index, params string[] styles)
        {
            if (styles is null)
            {
                throw new ArgumentNullException(nameof(styles));
            }

            if (!RowCssList.ContainsKey(index))
            {
                RowCssList.Add(index, new List<string>(styles));
            }
            else
            {
                RowCssList[index].AddRange(styles);
            }
        }
    }
}
