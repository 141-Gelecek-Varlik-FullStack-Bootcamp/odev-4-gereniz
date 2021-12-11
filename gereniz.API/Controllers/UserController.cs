using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gereniz.Database.Entities;
using gereniz.Model;
using gereniz.Model.User;
using gereniz.Service.User;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace gereniz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        
        [HttpPost("add")]
        public General<UserViewModel> Insert([FromBody] UserViewModel user)
        {
            return _userService.Insert(user);
        }

        [HttpPost("login")]
        public bool Login([FromBody] LoginViewModel loginUser)
        {

            return _userService.Login(loginUser);
            
        }
    }
}
