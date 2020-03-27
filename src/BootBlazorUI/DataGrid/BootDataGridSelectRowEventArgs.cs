using System;

namespace BootBlazorUI.DataGrid
{
    /// <summary>
    /// 表示选择行的事件参数。
    /// </summary>
    public class BootDataGridSelectedRowEventArgs:EventArgs
    {
        /// <summary>
        /// 初始化 <see cref="BootDataGridSelectedRowEventArgs"/> 类的新实例。
        /// </summary>
        /// <param name="item">选项的行数据。</param>
        /// <param name="index">选择行的索引。</param>
        public BootDataGridSelectedRowEventArgs(object item,int index)
        {
            Item = item;
            Index = index;
        }

        /// <summary>
        /// 获取选择行的数据。
        /// </summary>
        public object Item { get; }
        /// <summary>
        /// 获取选择行的索引。
        /// </summary>
        public int Index { get; }
    }
}
