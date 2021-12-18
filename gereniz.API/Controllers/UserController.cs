using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using gereniz.API.Infrastructure;
using gereniz.Database.Entities;
using gereniz.Model;
using gereniz.Model.User;
using gereniz.Service.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace gereniz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService, IMapper mapper, IMemoryCache memoryCache) : base(memoryCache)
        {
            _userService = userService;
        }


        [HttpPost]
        public General<UserViewModel> Insert([FromBody] UserViewModel user)
        {
            General<UserViewModel> response = new();
            if (CurrentUser is { Id: <= 0 })
            {
                return response;
            }
            return _userService.Insert(user);
        }

    }
}
