using System;
using System.Collections.Generic;
using System.Text;
using BootBlazorUI.Dialog;
using Microsoft.Extensions.DependencyInjection;

namespace BootBlazorUI
{
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// 添加对话框的服务。
        /// </summary>
        /// <param name="services"></param>
        /// <param name="optionAction"></param>
        /// <returns></returns>
        public static IServiceCollection AddDialog(this IServiceCollection services, Action<DialogOptions> optionAction = default)
        {
            services.AddScoped<IDialogService, DialogService>();

            var instance = new DialogOptions();
            if (optionAction == null)
            {
                optionAction = (e) => e = instance;
            }
            optionAction.Invoke(instance);
            services.Configure(optionAction);
            return services;
        }
    }
}
