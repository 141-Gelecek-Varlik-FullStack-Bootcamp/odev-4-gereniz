using System;
using System.Linq;
using AutoMapper;
using gereniz.Database.Entities;
using gereniz.Database.Entities.DomainContext;
using gereniz.Model;
using gereniz.Model.User;

namespace gereniz.Service.User
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }

        //Kullanıcı Ekleme
        public General<UserViewModel> Insert(UserViewModel userViewModel)
        {
            var result = new General<UserViewModel>() { IsSuccess = false };
            var model = _mapper.Map<Users>(userViewModel);

            using (var srv = new DomainContext())
            {
                model.IdateTime = DateTime.Now;
                srv.Users.Add(model);
                srv.SaveChanges();
                result.IsSuccess = true;
                result.Entity = _mapper.Map<UserViewModel>(model);
            }
            return result;
        }

        //Kullanıcı Girişi
        public bool Login(LoginViewModel loginViewModel)
        {
            bool result = false;
            using (var srv = new DomainContext())
            {
                result = srv.Users.Any(u => u.IsActive && !u.IsDeleted && u.Username == loginViewModel.Username && u.Password == loginViewModel.Password);
            }
            return result;
        }
    }
}
