//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Components;

//namespace BootBlazorUI
//{
//    /// <summary>
//    /// 呈现具有 style="position:absolute" 样式的 Loading 遮罩层。
//    /// </summary>
//    public partial class BootLoading
//    {
//        /// <summary>
//        /// 初始化 <see cref="BootLoading"/> 类的新实例。
//        /// </summary>
//        public BootLoading()
//        {

//        }

//        /// <summary>
//        /// 设置遮罩层呈现的文本。
//        /// </summary>
//        [Parameter] public string Text { get; set; } = "正在拼命加载...";
//        /// <summary>
//        /// 设置要呈现在遮罩层的内容。
//        /// </summary>
//        [Parameter] public RenderFragment ChildContent { get; set; }

//        /// <summary>
//        /// 设置遮罩层的背景颜色。默认是 <see cref="Color.Light"/> 。
//        /// </summary>
//        [Parameter] public Color BackgroundColor { get; set; } = Color.Light;
//        /// <summary>
//        /// 设置遮罩层默认文字的前景色。默认是 <see cref="Color.Dark"/>。当设置了子内容 <see cref="ChildContent"/> 时该属性无效。
//        /// </summary>
//        [Parameter] public Color FontColor { get; set; } = Color.Dark;
//        /// <summary>
//        /// 设置遮罩层的透明度。默认 0.5。值在0-1之间。
//        /// </summary>
//        [Parameter] public double Opacity { get; set; } = 0.5;
//        /// <summary>
//        /// 设置遮罩层显示内容的纵向对齐方式。默认是 <see cref="Flex.Center"/> 居中显示。
//        /// </summary>
//        [Parameter] public Flex HorizontalAlign { get; set; } = Flex.Center;
//        /// <summary>
//        /// 设置当组件显示后触发的事件。
//        /// </summary>
//        [Parameter] public EventCallback<bool> OnShown { get; set; }
//        /// <summary>
//        /// 设置当组件隐藏后触发的事件。
//        /// </summary>
//        [Parameter] public EventCallback<bool> OnHidden { get; set; }

//        [Parameter] public bool Display { get; set; }
//        [Parameter] public EventCallback<bool> DisplayChanged { get; set; }

//        /// <summary>
//        /// 显示遮罩层。
//        /// </summary>
//        public async Task Show()
//        {
//            Display = true;
//            await DisplayChanged.InvokeAsync(true);
//        }

//        /// <summary>
//        /// 隐藏遮罩层。
//        /// </summary>
//        public async Task Hide()
//        {
//            Display = false;
//            await DisplayChanged.InvokeAsync(false);
//        }

//        protected override void CreateComponentCssClass(ICollection<string> collection)
//        {
//            collection.Add("position-absolute");
//            collection.Add(ComponentUtil.GetColorCssClass(BackgroundColor, "bg-"));
//            collection.Add("w-100");
//            collection.Add("overflow-hidden");
//            collection.Add(Display ? "d-flex" : "d-none");
//            collection.Add("flex-column flex-fill");
//            collection.Add(ComponentUtil.GetFlexAlignCssClass(HorizontalAlign, "align-items-"));
//        }

//        protected override void CreateComponentStyle(ICollection<string> collection)
//        {
//            collection.Add("height:100%");
//            collection.Add("line-height:100%");
//            collection.Add($"opacity:{Math.Round(Opacity, 1)}");
//            collection.Add("top:0");
//            collection.Add("left:0");
//            //collection.Add($"display:{(IsShown ? "block" : "none")}");
//        }
//    }
//}
