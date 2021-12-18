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
                model.IsActive = true;
                srv.Users.Add(model);
                srv.SaveChanges();
                result.IsSuccess = true;
                result.Entity = _mapper.Map<UserViewModel>(model);
            }
            return result;
        }

        //Kullanıcı Girişi
        public General<UserViewModel> Login(LoginViewModel loginViewModel)
        {
            General<UserViewModel> result = new();
            using (var srv = new DomainContext())
            {
                var _data = srv.Users.FirstOrDefault(u => !u.IsDeleted && u.IsActive && u.Username == loginViewModel.Username && u.Password == loginViewModel.Password);
                if (_data is not null)
                {
                    result.IsSuccess = true;
                    result.Entity = _mapper.Map<UserViewModel>(_data);
                }
            }
            return result;
        }
    }
}
