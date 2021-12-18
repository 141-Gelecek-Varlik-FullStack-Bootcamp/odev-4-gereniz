using System;
using System.Linq;
using gereniz.Database.Entities;
using gereniz.Database.Entities.DomainContext;
using gereniz.Model.User;
using gereniz.Service.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Caching.Memory;

namespace gereniz.API.Infrastructure
{
    public class LoginFilter : Attribute ,IActionFilter
    {
        private readonly IMemoryCache _memoryCache;

        public LoginFilter(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!_memoryCache.TryGetValue(CacheKeys.Login, out UserViewModel response))
            {
                context.Result = new BadRequestObjectResult("Hata");
            }
            return;
        }
    }
}
