using System;
using gereniz.Model;
using gereniz.Model.User;

namespace gereniz.Service.User
{
    public interface IUserService
    {
        public General<UserViewModel> Login(LoginViewModel loginViewModel);
        public General<UserViewModel> Insert(UserViewModel userViewModel);
    }
}
