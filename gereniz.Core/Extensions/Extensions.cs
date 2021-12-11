using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using gereniz.Database.Entities.DomainContext;
using gereniz.Model.Product;

namespace gereniz.Core.Extensions
{
    public static class Extensions
    {

        public static List<ProductViewModel> ChangeView(this IMapper _mapper)
        {
            //Productsları ProductViewModel e çevirdik
            List<ProductViewModel> products = new List<ProductViewModel>();
            using (var srv = new DomainContext())
            {
                var list = srv.Products.ToList();
                foreach (var l in list)
                {
                    products.Add(_mapper.Map<ProductViewModel>(l));
                }

            }
            return products;
        }
    }
}
