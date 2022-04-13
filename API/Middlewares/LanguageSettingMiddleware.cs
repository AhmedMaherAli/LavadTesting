using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LavadTesting.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LanguageSettingMiddleware
    {
        private readonly RequestDelegate _next;

        public LanguageSettingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            string languageValue= "";
            
            if(httpContext.Request.Headers.TryGetValue("languageKey", out var lang))
                languageValue = lang;

            if(languageValue!="")
            {
                var cultureInfo = new CultureInfo(languageValue);
                CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            }
            if(string.IsNullOrEmpty(CultureInfo.DefaultThreadCurrentCulture.Name))
            {
                var cultureInfo = new CultureInfo("ar");
                CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            }

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LanguageSettingMiddlewareExtensions
    {
        public static IApplicationBuilder UseLanguageSettingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LanguageSettingMiddleware>();
        }
    }
}
