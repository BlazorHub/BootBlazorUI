using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI.Forms
{
    /// <summary>
    /// 表示 Bootstrap 的 Input 组件的基类。并且自动集成了带有级联参数的 <see cref="EditContext"/>  实例。
    /// </summary>
    /// <typeparam name="TValue">组件值的类型。</typeparam>
    public abstract class BootInputBase<TValue>:InputBase<TValue>
    {
        /// <summary>
        /// 初始化 <see cref="BootInputBase{TValue}"/> 类的新实例。
        /// </summary>
        protected BootInputBase()
        {
            Id = $"{GetType().FullName}_{Guid.NewGuid()}";
            Name = $"{GetType().Name}";
        }

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
        /// 设置组件的 name 属性的值。
        /// </summary>
        [Parameter]
        public string Name { get; set; }

        /// <summary>
        /// 设置一个布尔值，表示是否为只读状态。
        /// </summary>
        [Parameter]
        public bool ReadOnly { get; set; }

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


        /// <summary>
        /// 设置当字段无法被转换的错误信息。
        /// </summary>
        [Parameter] 
        public string ParsingErrorMessage { get; set; } = "字段 {0} 的数据类型不正确。";

        /// <summary>
        /// 定义组件的元素名称。
        /// </summary>
        /// <returns>组件元素的名称字符串。</returns>
        protected abstract string OpenElement();

        /// <summary>
        /// 构造输入组件的渲染树。
        /// </summary>
        /// <param name="builder">渲染构造器。</param>
        /// <param name="sequence">系列。</param>
        protected abstract void BuildInputRenderTree(RenderTreeBuilder builder, int sequence);

        /// <summary>
        /// 构造输入组件公共的渲染树。
        /// </summary>
        /// <param name="builder"></param>
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            var sequence = 0;
            builder.OpenElement(0, OpenElement());

            builder.AddAttribute(sequence++, "id", Id);
            builder.AddAttribute(sequence++, "name", Name);
            builder.AddMultipleAttributes(sequence++, AdditionalAttributes);
            builder.AddAttribute(sequence++, "bind", CurrentValue);
            builder.AddAttribute(sequence++, "onchange", EventCallback.Factory.CreateBinder<string>(this, value => CurrentValueAsString = value, CurrentValueAsString));
            builder.AddAttribute(sequence++, "class", GetCssClass());
            builder.AddAttribute(sequence++, "style", GetStyles());

            if (ReadOnly)
            {
                builder.AddAttribute(sequence++, "readonly", ReadOnly);
            }

            BuildInputRenderTree(builder, sequence);
            builder.CloseElement();
        }

        /// <summary>
        /// 格式化指定值成字符串。
        /// </summary>
        /// <param name="value">要格式化的值。</param>
        /// <returns>格式化后的字符串。</returns>
        protected override string FormatValueAsString(TValue value)
        {
            return value?.ToString();
        }


        /// <summary>
        /// 尝试转换指定值为字符串。
        /// </summary>
        /// <param name="value">输入控件的值。</param>
        /// <param name="result">转换后的值。</param>
        /// <param name="validationErrorMessage">转换失败时的错误字符串。</param>
        /// <returns>转换成功返回 <c>true</c>；否则返回 <c>false</c>。</returns>
        protected override bool TryParseValueFromString(string value, out TValue result, out string validationErrorMessage)
        {
            if (BindConverter.TryConvertTo(value, CultureInfo.InvariantCulture, out result))
            {
                validationErrorMessage = null;
                return true;
            }

            validationErrorMessage = string.Format(ParsingErrorMessage, FieldIdentifier.FieldName);
            return false;
        }
    }
}
