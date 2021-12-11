using System;
using gereniz.Model;
using gereniz.Model.User;

namespace gereniz.Service.User
{
    public interface IUserService
    {
        public bool Login(LoginViewModel loginViewModel);
        public General<UserViewModel> Insert(UserViewModel userViewModel);
    }
}
