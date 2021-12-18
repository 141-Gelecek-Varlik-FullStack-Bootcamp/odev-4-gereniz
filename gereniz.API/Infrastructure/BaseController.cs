using System;
using gereniz.Model.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace gereniz.API.Infrastructure
{
    public class BaseController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;


        public BaseController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public UserViewModel CurrentUser
        {
            get
            {
                return GetCurrentUser();
            }
        }
        public UserViewModel GetCurrentUser()
        {
            var response = new UserViewModel();

            _memoryCache.TryGetValue(CacheKeys.Login, out response);

            return response;
        }

    }
}
