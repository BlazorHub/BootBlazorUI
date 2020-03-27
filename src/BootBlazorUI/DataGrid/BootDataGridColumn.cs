using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace BootBlazorUI.DataGrid
{
    /// <summary>
    /// 可对 <see cref="BootDataGrid"/> 进行数据绑定的列。
    /// </summary>
    public class BootDataGridColumn : BaseComponent
    {
        /// <summary>
        /// 设置数据源绑定的字段。
        /// </summary>
        [Parameter]
        public string Field { get; set; }

        /// <summary>
        /// 设置列的标题。不设置，则取 <see cref="Field"/> 的值。
        /// </summary>
        [Parameter]
        public string Title { get; set; }

        /// <summary>
        /// 设置绑定字段的显示格式。
        /// </summary>
        [Parameter]
        public string Format { get; set; }

        /// <summary>
        /// 设置单元格的宽度。
        /// </summary>
        [Parameter]
        public string Width { get; set; }

        /// <summary>
        /// 设置列的对齐方式。
        /// </summary>
        [Parameter]
        public HorizontalAlignment Align { get; set; } = HorizontalAlignment.Center;

        /// <summary>
        /// 父组件。
        /// </summary>
        [CascadingParameter]
        internal BootDataGrid Parent { get; set; }

        

        /// <summary>
        /// 获取列的宽度 style 字符串，即 width:xxx
        /// </summary>
        /// <returns></returns>
        internal string GetWidthStyleString()
            => !string.IsNullOrWhiteSpace(Width) ? $"width:{Width}" :$"width:{Parent.GetAutoColumnWidth()}%";
        

        protected override void OnInitialized()
        {
            if (Parent == null)
            {
                throw new ArgumentException($"{nameof(BootDataGridColumn)} 只能在 {nameof(BootDataGrid)} 中使用");
            }

            if (string.IsNullOrWhiteSpace(Field))
            {
                throw new ArgumentException($"没有设置要绑定的 {Field} 字段");
            }
        }

        protected override void BuildCssClass(List<string> classList)
        {

        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                Parent.AddColumn(this);
            }
        }

        /// <summary>
        /// 获取指定行的绑定字段的值。
        /// </summary>
        /// <param name="row">要获取的行。</param>
        /// <returns></returns>
        internal object GetValue(object row)
        {
            var rowType = row.GetType();
            object value = default;
            if (rowType.IsClass)//实体
            {
                var property = rowType.GetProperty(Field);
                if (property == null)
                {
                    throw new InvalidOperationException($"没有在数据源中找到“{Field}”字段");
                }
                value = property.GetValue(row);
            }

            if (value == null)
            {
                return value;
            }

            if (!string.IsNullOrWhiteSpace(Format))
            {
                return string.Format(Format, value);
            }
            return value;
        }

        /// <summary>
        /// 获取列标题。
        /// </summary>
        internal string GetTitle()
        {
            if (!string.IsNullOrWhiteSpace(Title))
            {
                return Title;
            }

            return Field;
        }
    }
}
