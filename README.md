# BootBlazorUI
BootBlazorUI 是基于 Bootstrap 4.x 版本并构建于 ASP.NET CORE 3.1 的 UI 库，不依赖于 JQuery 和 Bootstrap.js 实现所有交互，可应用于 Mvc / Razor Page / Blazor 等 Web 应用程序。

# 特性
* 依托于 VS 的强大 IDE，如同使用 HTML 组件一样容易使用这些组件；
* 简单易用，让那些对 UI 并不擅长的程序员也能轻而易举的构建出想要的组件功能，再也不用去记那些 Bootstrap 组件的样式；
* 教科书般的注释，每一个参数都有很清晰的注释，形成注释即文档（Code As A Document）的风格；
* 开源、免费，并且不断更新丰富内容；

# 支持环境
* .NET CORE 3.1+ SDK
* .NET Standard 2.0+

# 最新版本（v0.2.0）
> Install-Package BootBlazorUI

# 快速上手
* 使用 Nuget Package Manager 安装包：`> Install-Package BootBlazorUI`；
* 引入内置的 bootstrap 样式 `<link href=_content/BootBlazorUI/bootstrap.min.css"" rel=""stylesheet/>` ，或你也可以自己引入 bootstrap 的样式；
* 引入所需的脚本：`<script src="_content/BootBlazorUI/components.js></script>`；
* 使用 `@using BootBlazorUI` 引入命名空间，你可以在 `_Import.cshtml`(Mvc/Razor Page) | `_Import.razor`(Blazor) 中引入全局命名空间，或在某个页面中引入命名空间；


**使用 VS 打开 docs 下的解决方案，即可看到完整文档**

# 先睹为快

## 按钮（Buttons）
![按钮](img/demo-button.png)
```html
<Button Color="ControlColor.Primary">Primary</Button>
<Button Color="ControlColor.Secondary">Secondary</Button>
<Button Color="ControlColor.Info">Info</Button>
<Button Color="ControlColor.Warning">Warning</Button>
<Button Color="ControlColor.Success">Success</Button>
<Button Color="ControlColor.Danger">Danger</Button>
<Button Color="ControlColor.Light">Light</Button>
<Button Color="ControlColor.Dark">Dark</Button>
```
## 进度条（Progress Bar）
![进度条](img/demo-progress-bar.png)
```html
<ProgressBar Value="80" Color="ControlColor.Primary" />
<ProgressBar Value="65" Color="ControlColor.Secondary" />
<ProgressBar Value="30" Color="ControlColor.Info" />
<ProgressBar Value="77" Color="ControlColor.Warning" />
<ProgressBar Value="100" Color="ControlColor.Success" />
<ProgressBar Value="40" Color="ControlColor.Danger" />
<ProgressBar Value="92" Color="ControlColor.Light" />
<ProgressBar Value="50" Color="ControlColor.Dark" />
```

## 对话框
![对话框](img/demo-modal.png)
```
<Button OnClick="@(() => modal.Open())"/>
弹出模态框
</Button>

<Modal @ref="modal">
    <HeaderTemplate>
        对话框标题
    </HeaderTemplate>
    <BodyTemplate>
        显示了一个对话框的内容
    </BodyTemplate>
</Modal>

@code{
Modal modal = new Modal();
}
```

## 徽章
![徽章](img/demo-badge.png)
```html
<Badge Color="ControlColor.Primary">Primary</Badge>
<Badge Color="ControlColor.Secondary">Secondary</Badge>
<Badge Color="ControlColor.Info">Info</Badge>
<Badge Color="ControlColor.Success">Success</Badge>
<Badge Color="ControlColor.Warning">Warning</Badge>
<Badge Color="ControlColor.Danger">Danger</Badge>
<Badge Color="ControlColor.Light">Light</Badge>
<Badge Color="ControlColor.Dark">Dark</Badge>
```