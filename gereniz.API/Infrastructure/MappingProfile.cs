using System;
using System.Collections.Generic;
using AutoMapper;
using gereniz.Database.Entities;
using gereniz.Model.Product;
using gereniz.Model.User;

namespace gereniz.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserViewModel, Users>();
            CreateMap<Users, UserViewModel>();

            CreateMap<LoginViewModel, Users>();
            CreateMap<Users, LoginViewModel>();

            CreateMap<ProductViewModel, Products>();
           
            CreateMap<Products, ProductViewModel>();

            CreateMap< List < Products >,ProductViewModel >();
        }
    }
}
