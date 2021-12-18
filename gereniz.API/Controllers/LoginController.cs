using System;
using gereniz.API.Infrastructure;
using gereniz.Database.Entities;
using gereniz.Model;
using gereniz.Model.User;
using gereniz.Service.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace gereniz.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IUserService _userService;

        public LoginController(IMemoryCache memoryCache, IUserService userService)
        {
            _memoryCache = memoryCache;
            _userService = userService;
        }

        [HttpPost]
        public General<bool> Login([FromBody] LoginViewModel loginViewModel)
        {
            General<bool> response = new() { Entity = false };
            General<UserViewModel> result = _userService.Login(loginViewModel);
            if (result.IsSuccess)
            {
                if (!_memoryCache.TryGetValue(CacheKeys.Login, out UserViewModel loginUser))
                {
                    var cacheOptions = new MemoryCacheEntryOptions()
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(1),
                        Priority = CacheItemPriority.Normal

                    };
                    _memoryCache.Set(CacheKeys.Login, result.Entity, cacheOptions);
                }
                response.Entity = true;
                response.IsSuccess = true;
            }
            return response;


        }
    }
}
