using System.Globalization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace BootBlazorUI.Forms
{
    /// <summary>
    /// 呈现 type="radio" 的 input 元素的组件。
    /// </summary>
    public class BootInputRadio<TValue> : BootInputBase<TValue>
    {
        [Parameter]
        public TValue SelectedValue { get; set; }

        /// <summary>
        /// 设置跟随单选框的文本。不设置，则不显示文本。
        /// </summary>
        [Parameter]
        public string Label { get; set; }

        /// <summary>
        /// 设置单选框文本的 class 名称。
        /// </summary>
        [Parameter]
        public string LabelCssClass { get; set; } = "form-check-label";

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            if (!string.IsNullOrEmpty(Label))
            {
                builder.OpenElement(50, "label");
                builder.AddAttribute(51, "class", LabelCssClass);
                builder.AddAttribute(53, "for", Id);
                builder.AddContent(52, (MarkupString)Label);
                builder.CloseElement();
            }
        }
        protected override void BuildInputRenderTree(RenderTreeBuilder builder, int sequence)
        {
            builder.AddAttribute(sequence++, "type", "radio");
            builder.AddAttribute(sequence++, "value", SelectedValue);
        }

        /// <summary>
        /// 使用 bool 类型构造复选框的改变事件。
        /// </summary>
        protected override EventCallback<ChangeEventArgs> BuildChangeEventCallback()
        => EventCallback.Factory.Create<ChangeEventArgs>(this, (e) => {
            CurrentValueAsString = e.Value.ToString();
            });

        protected override void BuildValueBindingAttribute(RenderTreeBuilder builder, int sequence)
        {
            builder.AddAttribute(sequence++, "checked", SelectedValue?.Equals(CurrentValue));
        }

        protected override string OpenElement() => "input";
    }
}
