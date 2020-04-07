using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace BootBlazorUI
{
    /// <summary>
    /// 表示组件的基类。
    /// </summary>
    public abstract class BaseComponent : ComponentBase
    {
        /// <summary>
        /// 初始化 <see cref="BaseComponent"/> 类的新实例。
        /// </summary>
        protected BaseComponent()
        {
            Id = $"{GetType().Name}_{Guid.NewGuid()}";
        }

        /// <summary>
        /// 设置元素或控件的 class 的值。
        /// </summary>
        [Parameter]
        public virtual string CssClass { get; set; }

        /// <summary>
        /// 设置元素或控件的 style 属性的值。
        /// </summary>
        [Parameter]
        public virtual string Styles { get; set; }

        /// <summary>
        /// 设置组件的唯一 Id。默认会自动生成一个随机 Id。
        /// </summary>
        [Parameter]
        public virtual string Id { get; set; }

        /// <summary>
        /// 设置将该控件或元素中出现的属性进行合并。
        /// </summary>
        [Parameter]
        public virtual IReadOnlyDictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// 构建组件内置的 class 样式。
        /// </summary>
        protected virtual void BuildCssClass(List<string> classList) { }

        /// <summary>
        /// 构建组件内置的 style 样式。
        /// </summary>
        protected virtual void BuildStyles(List<string> styleList) { }

        /// <summary>
        /// 获取用空格分割的 class 样式。
        /// </summary>
        /// <returns>用空格分割的样式字符串。</returns>
        public string GetCssClass()
        {
            var classList = new List<string>();
            if (!string.IsNullOrWhiteSpace(CssClass))
            {
                classList.Add(CssClass);
            }
            BuildCssClass(classList);
            return string.Join(" ", classList);
        }

        /// <summary>
        /// 获取用“;”分割的 style 样式。
        /// </summary>
        /// <returns>用分号隔开的 style 样式。</returns>
        public string GetStyles()
        {
            var styleList = new List<string>();
            if (!string.IsNullOrWhiteSpace(Styles))
            {
                styleList.Add(Styles);
            }
            BuildStyles(styleList);
            return string.Join(";", styleList);
        }
    }
}
