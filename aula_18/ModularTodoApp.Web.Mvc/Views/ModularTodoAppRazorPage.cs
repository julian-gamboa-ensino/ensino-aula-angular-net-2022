﻿using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace ModularTodoApp.Web.Views
{
    public abstract class ModularTodoAppRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected ModularTodoAppRazorPage()
        {
            LocalizationSourceName = ModularTodoAppConsts.LocalizationSourceName;
        }
    }
}
